using IncidentMonitor.DataLayer.Helpers;
using IncidentMonitor.DataLayer.Models;
using IncidentMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IncidentMonitor
{
    /// <summary>
    /// Interaction logic for LoginDialogWindow.xaml
    /// </summary>
    public partial class LoginDialogWindow : Window
    {
        //private NotificationUsersHelper usersHelper;

        public ApplicationUserViewModel? LoggedInUser { get; set; } = null;
        



        public LoginDialogWindow(ApplicationUserViewModel? user)
        {
            LoggedInUser = user;
            InitializeComponent();
            if (LoggedInUser != null)
            {
                UsernameTextBox.Text = LoggedInUser.Email;
            }
            UsernameTextBox.Focus();
        }



        private void CloseDialogButton_Clicked(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            BtnLogin.IsEnabled = false;
            Login();
            BtnLogin.IsEnabled = true;

        }

        private void PasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Login();
            }
        }

        async void Login()
        {

            if (string.IsNullOrEmpty(PasswordTextBox.Password) || string.IsNullOrEmpty(UsernameTextBox.Text))
            {
                ResultsTextBlock.Text = "Please enter a user name and password";
                return;
            }

            var url = $"{MainWindow.InstanceBaseUrl}/users/login";
            var client = new HttpClient();
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username",UsernameTextBox.Text),
                new KeyValuePair<string, string>("password",PasswordTextBox.Password)
            });
         
            var response = await client.PostAsync(url, content);
            var responseText = await response.Content.ReadAsStringAsync();
            if(response.IsSuccessStatusCode)
            {
                LoggedInUser = JsonSerializer.Deserialize<ApplicationUserViewModel>(responseText);
                DialogResult = true;
                return;
            }




            ResultsTextBlock.Text = "Invalid user name or password";
        }

        private void UsernameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                PasswordTextBox.Focus();
            }
        }
    }
}
