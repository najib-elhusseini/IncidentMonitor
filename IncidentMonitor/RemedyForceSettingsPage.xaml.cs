using IncidentMonitor.DataLayer.Helpers;
using IncidentMonitor.Models;
using System.Reflection;

namespace IncidentMonitor;

public partial class RemedyForceSettingsPage : ContentPage
{
    public RemedyForceSetting RemedyForceSetting { get; set; }

    private RemedyForceSettingsHelper SettingsHelper { get; set; }

    public RemedyForceSettingsPage()
    {
        InitializeComponent();
        try
        {


            GetSettings();
        }
        catch (Exception ex)
        {
            //DisplayAlert("Error", ex.Message, "Cancel");
        }

    }

    private async void GetSettings()
    {
        var helper = new RemedyForceSettingsHelper(this.GetDataContext());
        SettingsHelper = helper;
        RemedyForceSetting setting = await helper.GetRemedyForceSettingsAsync();


        if (setting == null)
        {
            setting = new RemedyForceSetting()
            {
                InstanceUrl = "https://hgts.my.salesforce.com",
                TokenEndpoint = "services/oauth2/token",
                UserName = "integrations@hoist.tech",
            };
            await helper.InsertAsync(setting);
        }

        RemedyForceSetting = setting;
        OnPropertyChanged(nameof(RemedyForceSetting));

    }

    private async void BtnSave_Clicked(object sender, EventArgs e)
    {

        var result = await SettingsHelper.UpdateAsync(RemedyForceSetting);

    }

    private async void GetTokenButton_Clicked(object sender, EventArgs e)
    {
        if (!RemedyForceSetting.ValidateSettings())
        {
            await DisplayAlert("Error", "One ore more required fields are not present", "Ok");
            return;
        }

        await SettingsHelper.UpdateTokenAsync(RemedyForceSetting);
        OnPropertyChanged(nameof(RemedyForceSetting));


    }
}