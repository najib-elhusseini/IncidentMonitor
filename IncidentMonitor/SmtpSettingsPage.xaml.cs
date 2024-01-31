using IncidentMonitor.DataLayer.Helpers;
using IncidentMonitor.Models;
using System.Runtime.CompilerServices;

namespace IncidentMonitor;

public partial class SmtpSettingsPage : ContentPage
{
    private bool _isLoading = false;
    SmtpSettingsHelper Helper { get; set; }
    public EmailConfiguration EmailConfiguration { get; set; }

    public bool IsLoading
    {
        get { return _isLoading; }
        set
        {
            _isLoading = value;
            OnPropertyChanged(nameof(IsLoading));
        }
    }

    public SmtpSettingsPage()
    {
        InitializeComponent();
        InitSmtpSettings();
    }

    private async void InitSmtpSettings()
    {
        //var appDataDir = FileSystem.AppDataDirectory;
        //var context = new DataLayer.Data.DataContext(appDataDir);
        Helper = new SmtpSettingsHelper(this.GetDataContext());
        var emailConfig = await Helper.GetEmailConfigurationAsync();
        if (emailConfig == null)
        {
            emailConfig = new EmailConfiguration()
            {
                EnableSsl = true,
                SmtpPort = 465,
            };
            await Helper.InsertAsync(emailConfig);
        }
        EmailConfiguration = emailConfig;
        OnPropertyChanged(nameof(EmailConfiguration));

    }

    private async void TestSmtpConfigButton_Clicked(object sender, EventArgs e)
    {
        IsLoading = true;
        EmailHelper helper = new EmailHelper(EmailConfiguration);
        var receiverEmailAddress = EmailConfiguration.UserName;
        await helper.SendEmailAsync("Test email", "Email sent with success", null, receiverEmailAddress);
        await DisplayAlert("Email Sent", $"Email sent to {receiverEmailAddress}", "Ok");
        IsLoading = false;


    }

    private async void SaveSmtpConfigButton_Clicked(object sender, EventArgs e)
    {
        await Helper.UpdateAsync(EmailConfiguration);
        //Close
    }
}