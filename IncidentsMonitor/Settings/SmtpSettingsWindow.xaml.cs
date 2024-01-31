using IncidentMonitor.DataLayer.Helpers;
using IncidentMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IncidentMonitor.Settings
{
    /// <summary>
    /// Interaction logic for SmtpSettingsWindow.xaml
    /// </summary>
    public partial class SmtpSettingsWindow : Window
    {



        public bool IsLoading
        {
            get { return (bool)GetValue(IsLoadingProperty); }
            set { SetValue(IsLoadingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsLoading.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsLoadingProperty =
            DependencyProperty.Register("IsLoading", typeof(bool), typeof(SmtpSettingsWindow), new PropertyMetadata(false));



        public EmailConfiguration EmailConfiguration
        {
            get { return (EmailConfiguration)GetValue(EmailConfigurationProperty); }
            set { SetValue(EmailConfigurationProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EmailConfiguration.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EmailConfigurationProperty =
            DependencyProperty.Register("EmailConfiguration", typeof(EmailConfiguration), typeof(SmtpSettingsWindow));
        
        private readonly SmtpSettingsHelper _settingsHelper;
        public SmtpSettingsWindow(SmtpSettingsHelper settingsHelper)
        {
            _settingsHelper = settingsHelper;
            InitializeComponent();
            GetSmtpSettings();
        }

        private async void GetSmtpSettings()
        {
            var settings = await _settingsHelper.GetEmailConfigurationAsync();
            if (settings == null)
            {
                settings = new Models.EmailConfiguration()
                {
                    EnableSsl = true,
                };
                await _settingsHelper.InsertAsync(settings);
            }
            EmailConfiguration = settings!;

        }

        private async void BtnTestSettings_Click(object sender, RoutedEventArgs e)
        {
            IsLoading = true;
            EmailHelper helper = new EmailHelper(EmailConfiguration);
            var receiverEmailAddress = EmailConfiguration.UserName;
            await helper.SendEmailAsync("Test email", "Email sent with success", null, receiverEmailAddress);
            //await DisplayAlert("Email Sent", $"Email sent to {receiverEmailAddress}", "Ok");
            IsLoading = false;
        }

        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            //IsLoading = true;
            await _settingsHelper.UpdateAsync(EmailConfiguration);
            this.Close();
        }
    }
}
