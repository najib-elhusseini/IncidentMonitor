using IncidentMonitor.DataLayer.Helpers;
using IncidentMonitor.Models;
using IncidentMonitor.Models.RemedyForce;
using IncidentMonitor.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace IncidentMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool _firstRun = true;
        NotificationUser? _loggedInUser;
        internal static MainWindow? Instance { get; private set; }

        #region Dependency Props



        public bool HasLoadingErrors
        {
            get { return (bool)GetValue(HasLoadingErrorsProperty); }
            set { SetValue(HasLoadingErrorsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HasLoadingErrors.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HasLoadingErrorsProperty =
            DependencyProperty.Register("HasLoadingErrors", typeof(bool), typeof(MainWindow), new PropertyMetadata(false));



        public string ErrorMessage
        {
            get { return (string)GetValue(ErrorMessageProperty); }
            set { SetValue(ErrorMessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ErrorMessage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ErrorMessageProperty =
            DependencyProperty.Register("ErrorMessage", typeof(string), typeof(MainWindow), new PropertyMetadata(""));




        public bool IsLoading
        {
            get { return (bool)GetValue(IsLoadingProperty); }
            set { SetValue(IsLoadingProperty, value); }
        }

        public static readonly DependencyProperty IsLoadingProperty =
            DependencyProperty.Register("IsLoading", typeof(bool), typeof(MainWindow), new PropertyMetadata(false));

        public bool SettingsValid
        {
            get { return (bool)GetValue(SettingsValidProperty); }
            set { SetValue(SettingsValidProperty, value); }
        }

        public static readonly DependencyProperty SettingsValidProperty =
            DependencyProperty.Register("SettingsValid", typeof(bool), typeof(MainWindow), new PropertyMetadata(true));

        public DateTime Today
        {
            get { return (DateTime)GetValue(TodayProperty); }
            set { SetValue(TodayProperty, value); }
        }

        public static readonly DependencyProperty TodayProperty =
            DependencyProperty.Register("Today", typeof(DateTime), typeof(MainWindow));



        public int TimerInterval
        {
            get { return (int)GetValue(TimerIntervalProperty); }
            set { SetValue(TimerIntervalProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TimerInterval.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TimerIntervalProperty =
            DependencyProperty.Register("TimerInterval", typeof(int), typeof(MainWindow), new PropertyMetadata(3));



        #endregion

        public AppCompany DefaultCompany { get; set; }

        private ObservableCollection<Incident> Incidents { get; set; } = new ObservableCollection<Incident>();

        DataLayerHelper DataLayerHelper { get; set; }

        NotificationUser? LoggedInUser
        {
            get => _loggedInUser; set
            {
                _loggedInUser = value;
                //SettingsMenuItem.IsEnabled = _loggedInUser?.IsSuperUser == true;
                SettingsMenuItem.IsEnabled = true;// _loggedInUser?.IsSuperUser == true;
            }
        }

        private DispatcherTimer Timer { get; set; }

        #region Ctor

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public MainWindow()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            Instance = this;
            var now = DateTime.Now;
            Today = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59).AddDays(-1);
            Timer = new DispatcherTimer();
            InitializeComponent();

        }
        #endregion

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            if (_firstRun)
            {
                // For readability, do not use the new new() , that was readable :)
                DataLayerHelper = new DataLayerHelper(GetAppDirectory())
                {
                    OnHelpersInitialized = InitializePageData
                };

                _firstRun = false;
            }

        }

        private async void InitializePageData()
        {
            var loginDialog = new LoginDialogWindow(DataLayerHelper.NotificationUsersHelper, LoggedInUser)
            {
                Owner = this,
                LoggedInUser = this.LoggedInUser
            };
            var result = loginDialog.ShowDialog();
            if (!result == true) // result !=true :) stupid not
            {
                Application.Current.Shutdown(-1);
                return;
            }
            LoggedInUser = loginDialog.LoggedInUser;

            if (
                DataLayerHelper.RemedyForceSettings == null
                ||
                DataLayerHelper.RemedyForceSettingsHelper == null
                )
            {
                //SettingsValid = false;
                return;
            }

            if (!DataLayerHelper.RemedyForceSettings.ValidateSettings())
            {
                //SettingsValid = false;
                return;

            }
            DefaultCompany = await DataLayerHelper.CompaniesHelper.GetDefaultCompanyAsync();


            await CheckIncidents();
            Timer.Interval = TimeSpan.FromMinutes(TimerInterval);
            Timer.Tick += TimerTicked;
            Timer.Start();



        }


        private async void TimerTicked(object? sender, EventArgs e)
        {
            if (IsLoading)
            {
                return;
            }
            Timer.Stop();
            await CheckIncidents();
            Timer.Start();
        }


        /// <summary>
        /// Checks for RemedyForce Incidents
        /// </summary>
        /// <returns>Task</returns>
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
                IncidentsGrid.ItemsSource = Incidents;

                NotifyUnresponded();
            }
            catch (Exception ex)
            {
                HasLoadingErrors = true;
                ErrorMessage = $"{ex.ToString()}";
                if (Timer != null)
                {
                    Timer.Stop();
                }
            }
            finally
            {
                IsLoading = false;
            }

        }

        #region Notification Methods

        /// <summary>
        /// This method notifies SVD users of unresponded Remedy Force Tickets
        /// </summary>
        private void NotifyUnresponded()
        {
            var unseenNotifications = Incidents
                .Where(i =>
                i.RespondedDateTime == null &&
                i.IncidentCreationDate != null &&
                i.IncidentCreationDate >= Today &&
                DefaultCompany.IsWithinShift(i.IncidentCreationDate.Value)
                );

            if (unseenNotifications.Any())
            {
                if (DefaultCompany.Settings.EnableEmailNotifications == true)
                {
                    _ = EmailUnrespondedIncidents(unseenNotifications);
                }
                if (DefaultCompany.Settings.EnableAlarmNotifications == true)
                {
                    PlayAlarm();
                }
            }

        }

        private async void NotifyAll()
        {

            var notifications = Incidents
                .Where(i => i.IncidentCreationDate >= Today);
            if (!notifications.Any())
            {
                return;
            }

            IsLoading = true;
            if (DefaultCompany.Settings.EnableAlarmNotifications == true)
            {
                PlayAlarm();
            }
            if (DefaultCompany.Settings.EnableEmailNotifications == true)
            {
                var smtpHelper = DataLayerHelper.SmtpSettingsHelper;

                var emailConfig = await smtpHelper.GetEmailConfigurationAsync() ?? throw new NotImplementedException();
                var emailHelper = new EmailHelper(emailConfig);

                var usersToNotifyHelper = DataLayerHelper.NotificationUsersHelper;
                var usersToNotify = await usersToNotifyHelper.GetUsersToNotifyAsync();

                await emailHelper.SendIncidentsNotificationEmailAsync(notifications, usersToNotify);
            }

            IsLoading = false;



        }

        private async Task EmailUnrespondedIncidents(IEnumerable<Incident> incidents)
        {
            IsLoading = true;

            var smtpHelper = DataLayerHelper.SmtpSettingsHelper;
            // TODO : handle null case exception
            var emailConfig = await smtpHelper.GetEmailConfigurationAsync() ?? throw new NotImplementedException();
            var emailHelper = new EmailHelper(emailConfig);

            var usersToNotifyHelper = DataLayerHelper.NotificationUsersHelper;
            var usersToNotify = await usersToNotifyHelper.GetUsersToNotifyAsync();
            await emailHelper.SendUnrespondedNotificationEmailsAsync(incidents, usersToNotify);

            IsLoading = false;

        }


        #endregion

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            TimerTicked(sender, e);
        }

        private void BtnNotifyAll_Click(object sender, RoutedEventArgs e)
        {
            NotifyAll();
        }

        private static string GetAppDirectory()
        {
            var location = Assembly.GetExecutingAssembly().Location;

            var appDataDir = Path.GetDirectoryName(location) ?? "";
            return appDataDir;
        }

        #region Menu Events
        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }
        private void CompanyMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var companyWindow = new Settings.Company(DataLayerHelper.CompaniesHelper)
            {
                Owner = this,
            };
            companyWindow.ShowDialog();
        }

        private void RemedyForceMenuItem_Clicked(object sender, RoutedEventArgs e)
        {
            var rfWindow = new Settings.RemedyForceSettingsWindow(DataLayerHelper.RemedyForceSettingsHelper)
            {
                Owner = this,
            };
            rfWindow.ShowDialog();
        }

        private void UsersMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var usersWindow = new UsersWindow(DataLayerHelper.NotificationUsersHelper)
            {
                Owner = this
            };
            usersWindow.ShowDialog();
        }

        private void SmtpSettingsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var smtpWindow = new SmtpSettingsWindow(DataLayerHelper.SmtpSettingsHelper) { Owner = this, };
            smtpWindow.ShowDialog();

        }

        private void LogoutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Incidents.Clear();
            Timer.Stop();
            InitializePageData();
        }

        private void ChangePasswordMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // This should never occur, but better be safe than sorry
            if (LoggedInUser == null)
            {
                throw new NotImplementedException();
            }

            var dialog = new ChangePasswordDialog(DataLayerHelper.NotificationUsersHelper, LoggedInUser)
            {
                Owner = this,
            };
            dialog.ShowDialog();

        }

        private void NotificationSettingsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new NotificationSettingsWindow(DefaultCompany, DataLayerHelper.CompaniesHelper)
            {
                Owner = this,
            };
            dialog.ShowDialog();



        }





        #endregion

        private async void PlayAlarm()
        {
            var intervalMilliSeconds = DefaultCompany.Settings.AlarmInterval ?? 1000;

            var appDir = GetAppDirectory();
            var alarmFilePath = Path.Combine(appDir, "Resources", "Sounds", "classic-alarm.wav");
            SoundPlayer soundPlayer = new SoundPlayer(alarmFilePath);
            soundPlayer.Load();
            for (int i = 0; i < 3; i++)
            {
                await Task.Factory.StartNew(() =>
                {
                    soundPlayer.PlaySync();
                    System.Threading.Thread.Sleep(intervalMilliSeconds);
                });
            }
        }

    }
}
