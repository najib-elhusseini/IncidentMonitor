using IncidentMonitor.DataLayer.Helpers;
using IncidentMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for Company.xaml
    /// </summary>
    public partial class Company : Window
    {

        private CompaniesHelper CompaniesHelper { get; set; }


        #region Dependency Property for AppCompany

        public AppCompany AppCompany
        {
            get { return (AppCompany)GetValue(AppCompanyProperty); }
            set { SetValue(AppCompanyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AppCompany.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AppCompanyProperty =
            DependencyProperty.Register("AppCompany", typeof(AppCompany), typeof(Company));

        #endregion




#pragma warning disable CS8618
        public Company(CompaniesHelper companiesHelper)
#pragma warning restore CS8618
        {
            CompaniesHelper = companiesHelper;
            InitializeComponent();
            GetDefaultCompany();
        }

        private async void GetDefaultCompany()
        {
            AppCompany company = await CompaniesHelper.GetDefaultCompanyAsync();
            AppCompany = company;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var result = await CompaniesHelper.UpdateAsync(AppCompany);
            

        }
    }
}
