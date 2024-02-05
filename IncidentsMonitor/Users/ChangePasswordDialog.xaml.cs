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

namespace IncidentMonitor
{
    /// <summary>
    /// Interaction logic for ChangePasswordDialog.xaml
    /// </summary>
    public partial class ChangePasswordDialog : Window
    {
        private NotificationUsersHelper Helper { get; set; }

        private NotificationUser LoggedInUser { get; set; }
        public ChangePasswordDialog(NotificationUsersHelper helper, NotificationUser loggedInUser)
        {
            Helper = helper;
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
            var user = await Helper.Find(LoggedInUser.Id) ?? throw new NotImplementedException();

            if (string.IsNullOrEmpty(OldPasswordBox.Password) || user.AppPassword != OldPasswordBox.Password)
            {
                ErrorTextBlock.Text = "Please provide the current password and try again";
                return;
            }

            if (NewPasswordBox.Password != ConfirmPasswordBox.Password)
            {
                ErrorTextBlock.Text = "The 'New Password' and 'Confirm Password' fields do not match";
                return;
            }
            var encrypted = await Helper.EncryptAsync(NewPasswordBox.Password);
            user.AppPassword = Convert.ToBase64String(encrypted);
            await Helper.UpdateAsync(user);
            DialogResult = true;
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
