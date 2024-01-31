using IncidentMonitor.DataLayer.Helpers;
using IncidentMonitor.Models;
using System.Collections.ObjectModel;

namespace IncidentMonitor;

public partial class UsersToNotifyPage : ContentPage
{

    public ObservableCollection<NotificationUser> Users { get; set; }

    public NotificationUser? SelectedUser
    {
        get => _selectedUser;
        set
        {
            
            _selectedUser = value;
            foreach (var user in Users)
            {
                user.IsSelected = false;
            }           
            if (_selectedUser != null)
            {
                _selectedUser.IsSelected = true;
            }

            UsersCollectionView.ItemsSource = null;
            OnPropertyChanged(nameof(SelectedUser));
            UsersCollectionView.ItemsSource = Users;
        }
    }

    NotificationUsersHelper _notificationUsersHelper;
    NotificationUser? _selectedUser;

    public UsersToNotifyPage()
    {
        Users = new ObservableCollection<NotificationUser>();
        _notificationUsersHelper = new NotificationUsersHelper(this.GetDataContext());
        InitializeComponent();
        GetNotificationUsers();

    }

    private async void GetNotificationUsers()
    {
        var users = await _notificationUsersHelper.GetAllAsync();
        users = users.OrderByDescending(u => u.Id).ToList();
        Users.Clear();
        UsersCollectionView.ItemsSource = users;
        foreach (var user in users)
        {
            Users.Add(user);
        }
        UsersCollectionView.ItemsSource = users;

    }

    private async void AddNewButton_Clicked(object sender, EventArgs e)
    {
        var user = new NotificationUser()
        {
            FirstName = "New",
            LastName = "User",
            Email = "email@domain.com",
            IsActive = true,
        };

        await _notificationUsersHelper.InsertAsync(user);
        Users.Insert(0, user);
        SelectedUser = user;


    }

    private async void BtnSave_Clicked(object sender, EventArgs e)
    {
        if (SelectedUser == null)
        {
            return;
        }
        await _notificationUsersHelper.UpdateAsync(SelectedUser);
        GetNotificationUsers();


    }



    private async void BtnDelete_Clicked(object sender, EventArgs e)
    {
        if (SelectedUser == null)
        {
            return;
        }

        var result = await DisplayAlert("Confirm Delete", "Delete Record?", "Ok", "Cancel");
        if (result)
        {
            Users.Remove(SelectedUser);
            await _notificationUsersHelper.DeleteAsync(SelectedUser);
            SelectedUser = null;

            //GetNotificationUsers();
        }

    }

    private void RefreshButton_Clicked(object sender, EventArgs e)
    {
        GetNotificationUsers();
    }

    private void OnNotificationUserTapped(object sender, TappedEventArgs e)
    {
        var layout = sender as Grid;
        if (layout == null)
        {
            return;
        }
        var user = layout.BindingContext as NotificationUser;
        if (user == null)
        {
            return;
        }

        SelectedUser = user;

    }

    private void NotificationUserListItem_PointerEntered(object sender, PointerEventArgs e)
    {
        var layout = sender as Grid;
        if (layout != null)
        {
            //layout.BackgroundColor = new Color(0, 0, 0, 0.1f);
        }

#if WINDOWS
    var handler = layout.Handler.PlatformView as Microsoft.Maui.Platform.LayoutPanel;
    IncidentMonitor.Platforms.Windows.WindowsUIElementExtensions.ChangeCursor(handler);

#endif

    }

    private void NotificationUserListItem_PointerExited(object sender, PointerEventArgs e)
    {
        //var layout = sender as Grid;
        //if (layout != null)
        //{
        //    layout.BackgroundColor = null;
        //}
    }
}