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
    /// Interaction logic for NotificationSettings.xaml
    /// </summary>
    public partial class NotificationSettingsWindow : Window
    {


        public CompanySettings CompanySettings
        {
            get { return (CompanySettings)GetValue(CompanySettingsProperty); }
            set { SetValue(CompanySettingsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CompanySettings.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CompanySettingsProperty =
            DependencyProperty.Register("CompanySettings", typeof(CompanySettings), typeof(NotificationSettingsWindow));

        private AppCompany Company { get; set; }
        private CompaniesHelper CompaniesHelper { get; set; }

        public NotificationSettingsWindow(AppCompany company,
            CompaniesHelper companiesHelper)
        {
            Company = company;
            CompanySettings = company.Settings;
            CompaniesHelper = companiesHelper;

            InitializeComponent();
        }

        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            Company.Settings = CompanySettings;
            await CompaniesHelper.UpdateAsync(Company);
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
