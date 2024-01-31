using IncidentMonitor.DataLayer.Data;
using IncidentMonitor.DataLayer.Helpers;
using IncidentMonitor.Models;
using IncidentMonitor.Models.RemedyForce;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace IncidentMonitor
{
    public partial class MainPage : ContentPage
    {
        private const int _timerInterval = 4;
        private bool _isLoading = false;
        private bool _hasLoadingErrors = false;
        private bool _settingsValid = true;
        private IDispatcherTimer? _timer;

        private string _errorMessage = string.Empty;
        private readonly DateTime _today;





        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        public bool HasLoadingErrors
        {
            get => _hasLoadingErrors;
            set
            {
                _hasLoadingErrors = value;
                OnPropertyChanged(nameof(HasLoadingErrors));
            }
        }

        public bool SettingsValid
        {
            get => _settingsValid;
            set
            {
                _settingsValid = value;
                OnPropertyChanged(nameof(SettingsValid));
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage; set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        DataLayerHelper DataLayerHelper { get; set; }


        internal DateTime Today { get => _today; }

        internal ObservableCollection<Incident> Incidents { get; set; } = new();

        internal AppCompany DefaultCompany { get; set; }

        [UnconditionalSuppressMessage("SingleFile", "IL3002:Avoid calling members marked with 'RequiresAssemblyFilesAttribute' when publishing as a single-file", Justification = "<Pending>")]
        public MainPage()
        {

            var now = DateTime.Now;
            _today = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59).AddDays(-1);


            InitializeComponent();
            LastCheckedDateLabel.Text = $"Date : {Today.ToShortDateString()}";

            DataLayerHelper = new DataLayerHelper( this.GetAppDirectory());
            DataLayerHelper.OnHelpersInitialized += InitializePageData;

        }

        private async void InitializePageData()
        {
            if (
                DataLayerHelper.RemedyForceSettings == null
                ||
                DataLayerHelper.RemedyForceSettingsHelper == null
                )
            {
                SettingsValid = false;
                return;
            }

            if (!DataLayerHelper.RemedyForceSettings.ValidateSettings())
            {
                SettingsValid = false;
                return;

            }
            DefaultCompany = await DataLayerHelper.CompaniesHelper.GetDefaultCompanyAsync();


            await CheckIncidents();

            _timer = Dispatcher.CreateTimer();
            _timer.Interval = TimeSpan.FromMinutes(_timerInterval);
            _timer.Tick += TimerTicked;
            _timer.Start();


        }

        private async void TimerTicked(object sender, EventArgs e)
        {
            //var diff = DateTime.Now - LastCheckedDate;
            //TimerLabel.Text = $"Last checked {diff.Seconds} Seconds ago";
            if (IsLoading)
            {
                return;
            }
            _timer.Stop();
            await CheckIncidents();
            _timer.Start();
        }


        private async Task CheckIncidents()
        {
            if (IsLoading)
            {
                return;
            }

            if (DataLayerHelper.RemdyForceIncidentsHelper == null)
            {
                SettingsValid = false;
                return;
            }

            IsLoading = true;
            Incidents.Clear();

            try
            {
                var incidents = await DataLayerHelper
                               .RemdyForceIncidentsHelper
                               .GetIncidents(Today.ToUniversalTime());

                foreach (var incident in incidents)
                {
                    Incidents.Add(incident);
                }
                IncidentsListView.ItemsSource = Incidents;
                NotifyUnresponded();
            }
            catch (Exception ex)
            {
                HasLoadingErrors = true;
                ErrorMessage = ex.ToString();
                if (_timer != null && _timer.IsRunning)
                {
                    _timer.Stop();
                }
            }
            finally
            {
                IsLoading = false;
            }

        }

        private async void RefreshButton_Clicked(object sender, EventArgs e)
        {

            await CheckIncidents();

        }

        private async void NotifyUnresponded()
        {
#if DEBUG
            Debug.WriteLine("Checking for unseen notifications");
#endif
            var unseenNotifications = Incidents
                .Where(i =>
                i.RespondedDateTime == null &&
                i.IncidentCreationDate != null &&
                i.IncidentCreationDate >= _today &&
                DefaultCompany.IsWithinShift(i.IncidentCreationDate.Value)
                );
            Debug.WriteLine($"Unseen notifications count ({unseenNotifications.Count()})");
            if (unseenNotifications.Any())
            {
                await NotifyUnresponded(unseenNotifications);
            }

        }


        private async void NotifyAll(object sender, EventArgs e)
        {

            var notifications = Incidents
                .Where(i => i.IncidentCreationDate >= _today);
            if (!notifications.Any())
            {
                return;
            }

            IsLoading = true;

            var smtpHelper = new SmtpSettingsHelper(this.GetDataContext());

            var emailConfig = await smtpHelper.GetEmailConfigurationAsync() ?? throw new NotImplementedException();
            var emailHelper = new EmailHelper(emailConfig);

            var usersToNotifyHelper = new NotificationUsersHelper(this.GetDataContext());
            var usersToNotify = await usersToNotifyHelper.GetUsersToNotifyAsync();


            await emailHelper.SendIncidentsNotificationEmailAsync(notifications, usersToNotify);

            IsLoading = false;



        }

        private async Task NotifyUnresponded(IEnumerable<Models.RemedyForce.Incident> incidents)
        {
            IsLoading = true;

            var smtpHelper = new SmtpSettingsHelper(this.GetDataContext());
            // TODO : handle null case exception
            var emailConfig = await smtpHelper.GetEmailConfigurationAsync() ?? throw new NotImplementedException();
            var emailHelper = new EmailHelper(emailConfig);

            var usersToNotifyHelper = new NotificationUsersHelper(this.GetDataContext());
            var usersToNotify = await usersToNotifyHelper.GetUsersToNotifyAsync();


            await emailHelper.SendUnrespondedNotificationEmailsAsync(incidents, usersToNotify);

            IsLoading = false;

        }


    }
}