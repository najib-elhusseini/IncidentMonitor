using IncidentMonitor.DataLayer.Helpers;
using IncidentMonitor.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for RemedyForceSettingsWindow.xaml
    /// </summary>
    public partial class RemedyForceSettingsWindow : Window
    {




        public bool IsBusy
        {
            get { return (bool)GetValue(IsBusyProperty); }
            set { SetValue(IsBusyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsBusy.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsBusyProperty =
            DependencyProperty.Register("IsBusy", typeof(bool),
                typeof(RemedyForceSettingsWindow), new PropertyMetadata(false));





        public RemedyForceSetting RemedyForceSetting
        {
            get { return (RemedyForceSetting)GetValue(RemedyForceSettingProperty); }
            set { SetValue(RemedyForceSettingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RemedyForceSetting.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RemedyForceSettingProperty =
            DependencyProperty.Register("RemedyForceSetting",
                typeof(RemedyForceSetting), typeof(RemedyForceSettingsWindow));







        RemedyForceSettingsHelper RemedyForceSettingsHelper { get; set; }

        public RemedyForceSettingsWindow(RemedyForceSettingsHelper helper)
        {
            InitializeComponent();
            RemedyForceSettingsHelper = helper;
            GetSettings();
        }

        private async void GetSettings()
        {
            var rfSettings = await RemedyForceSettingsHelper.GetRemedyForceSettingsAsync();
            if (rfSettings == null)
            {
                rfSettings = new RemedyForceSetting()
                {
                    InstanceUrl = "https://hgts.my.salesforce.com",
                    TokenEndpoint = "services/oauth2/token",
                    UserName = "integrations@hoist.tech",

                };

                _ = await RemedyForceSettingsHelper.InsertAsync(rfSettings);
            }

            RemedyForceSetting = rfSettings;
        }

        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            await RemedyForceSettingsHelper.UpdateAsync(RemedyForceSetting);
        }


        private async void BtnGetToken_Click(object sender, RoutedEventArgs e)
        {
            if (!RemedyForceSetting.ValidateSettings())
            {
                MessageBox.Show("Error", "One ore more required fields are not present");
                return;
            }
            IsBusy = true;
            await RemedyForceSettingsHelper.UpdateTokenAsync(RemedyForceSetting);
            GetSettings();
            IsBusy = false;
        }
    }
}
