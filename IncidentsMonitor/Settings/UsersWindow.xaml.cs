using IncidentMonitor.DataLayer.Helpers;
using IncidentMonitor.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.Xml;
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
    /// Interaction logic for UsersWindow.xaml
    /// </summary>
    public partial class UsersWindow : Window
    {

        public ObservableCollection<NotificationUser> Users { get; set; } = new();

        readonly NotificationUsersHelper _helper;
        public UsersWindow(NotificationUsersHelper helper)
        {
            _helper = helper;
            InitializeComponent();
            GetUsers();
        }

        async void GetUsers()
        {
            Users.Clear();
            var users = await _helper.GetAllAsync();
            foreach (var user in users)
            {
                if (user.AppPassword != null)
                {
                    try
                    {
                        var converted = Convert.FromBase64String(user.AppPassword);
                        user.AppPassword = await _helper.DecryptAsync(converted);
                    }
                    catch (Exception ex)
                    {
                        user.AppPassword = "Error";
                    }

                }
                Users.Add(user);
            }
            if (Users.Any())
            {
                UsersListBox.SelectedItem = Users.FirstOrDefault();
            }
        }

        private async void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            var user = new NotificationUser()
            {
                FirstName = "New",
                LastName = "user",
                Email = "",
                IsActive = true,
            };
            var result = await _helper.InsertAsync(user);
            Users.Insert(0, user);
            UsersListBox.SelectedItem = Users.ElementAt(0);
        }

        private async void BtnRemoveUser_Click(object sender, RoutedEventArgs e)
        {
            if (UsersListBox.SelectedItem == null)
            {
                return;
            }
            var user = UsersListBox.SelectedItem as NotificationUser;
            await _helper.DeleteAsync(user!);
            GetUsers();

        }

        private async void SaveAll_Click(object sender, RoutedEventArgs e)
        {
            foreach (var user in Users)
            {
                if (!string.IsNullOrEmpty(user.AppPassword))
                {
                    var encryptedBytes = await _helper.EncryptAsync(user.AppPassword);
                    var encrypted = Convert.ToBase64String(encryptedBytes);
                    user.AppPassword = encrypted;                   
                }
                await _helper.UpdateAsync(user);
            }
            GetUsers();
        }

        private  void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            GetUsers();
        }
    }
}
