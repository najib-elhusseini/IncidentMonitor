


namespace IncidentMonitor;

public partial class BackupAndRestorePage : ContentPage
{
    private string _selectedValue = "backup";
    const string _databaseName = "event_monitor.db";

    private bool IsBackup => _selectedValue == "backup";

    public BackupAndRestorePage()
    {
        InitializeComponent();
    }
     
    private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        var radio = sender as RadioButton;
        if (radio != null && radio.IsChecked)
        {
            var value = radio.Value.ToString();
            _selectedValue = value;
            //DatabasePathEntry.Text = value;
        }
    }

    private async void PickFileButton_Clicked(object sender, EventArgs e)
    {

        if (IsBackup)
        {
            await BackupAsync();
        }
        else
        {
            await RestoreAsync();
        }



    }

    private async Task BackupAsync()
    {
        
        //var token = new CancellationToken();
        //var result = await FolderPicker.Default.PickAsync(token);
        //if (result == null || !result.IsSuccessful)
        //{
        //    return;
        //}
        //var restoreFrom = this.GetAppDirectory();
        //var source = Path.Combine(restoreFrom, _databaseName);
        //var destination = Path.Combine(result.Folder.Path, _databaseName);

        //File.Copy(source, destination, true);
        //ResultsLabel.Text = $"Backed up to : {destination}";
    }

    private async Task RestoreAsync()
    {
        //var fileTypes = new[] { ".db" };
        //var dictionay = new Dictionary<DevicePlatform, IEnumerable<string>>()
        //{
        //    {
        //        DevicePlatform.WinUI, fileTypes
        //    }
        //};
        //PickOptions pickOptions = new()
        //{
        //    FileTypes = new FilePickerFileType(dictionay),
        //    PickerTitle = "Database location",            
        //};
        //var result = await FilePicker.Default.PickAsync(pickOptions);

        //if (result == null)
        //{
        //    return;
        //}

        //var path = result.FullPath;
        //var copyTo = this.GetAppDirectory();
        //var destination = Path.Combine(copyTo, _databaseName);
        //File.Copy(path, destination, true);
        
        //ResultsLabel.Text = $"Restored From  : {path}";
    }
}