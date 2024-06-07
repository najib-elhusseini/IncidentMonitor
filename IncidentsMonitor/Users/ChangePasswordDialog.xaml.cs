using IncidentMonitor.DataLayer.Helpers;
using IncidentMonitor.DataLayer.Models;
using IncidentMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IncidentMonitor
{
    /// <summary>
    /// Interaction logic for ChangePasswordDialog.xaml
    /// </summary>
    public partial class ChangePasswordDialog : Window
    {


        private ApplicationUserViewModel LoggedInUser { get; set; }



        public ChangePasswordDialog(ApplicationUserViewModel loggedInUser)
        {
            LoggedInUser = loggedInUser;
            InitializeComponent();
            UserNameTextBlock.Text = loggedInUser.Email;
        }



        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            TryChangePassword();

        }

        async void TryChangePassword()
        {
            var url = $"{MainWindow.InstanceBaseUrl}/users/ChangePassword";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", LoggedInUser.Token);
            var content = new FormUrlEncodedContent(new[]
           {
                new KeyValuePair<string, string>("id",LoggedInUser.Id),
                new KeyValuePair<string, string>("password",OldPasswordBox.Password),
                new KeyValuePair<string, string>("newPassword",NewPasswordBox.Password)
            });
            ConfirmButton.IsEnabled = false;
            var response = await client.PostAsync(url, content);
            var responseText = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                DialogResult = true;
                return;
            }
            else
            {
                ErrorTextBlock.Text = "Password change failed";
            }
            ConfirmButton.IsEnabled = true;
        }

        private void OldPasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                NewPasswordBox.Focus();
            }

        }


        private void NewPasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ConfirmPasswordBox.Focus();
            }
        }

        private void ConfirmPasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TryChangePassword();
            }
        }
    }
}
