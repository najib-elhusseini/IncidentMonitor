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
        private NotificationUsersHelper usersHelper;

        public NotificationUser? LoggedInUser { get; set; } = null;



        //public LoginDialogWindow(NotificationUsersHelper helper)
        //{
        //    usersHelper = helper;
        //    InitializeComponent();
        //}

        public LoginDialogWindow(NotificationUsersHelper helper, NotificationUser? user)
        {
            usersHelper = helper;
            LoggedInUser = user;
            InitializeComponent();
            if (LoggedInUser != null)
            {
                UsernameTextBox.Text = LoggedInUser.Email;
            }
        }



        private void CloseDialogButton_Clicked(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            Login();

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

            var result = await usersHelper.GetUserByEmailAsync(UsernameTextBox.Text, true);

            if (result != null && result.AppPassword == PasswordTextBox.Password)
            {
                LoggedInUser = result;
                DialogResult = true;

                return;
            }


            ResultsTextBlock.Text = "Invalid user name or password";
        }
    }
}
