
using IncidentMonitor.Models;
using System.Collections.ObjectModel;

namespace IncidentMonitor;

public partial class Companies : ContentPage
{
    ObservableCollection<AppCompany> CompaniesList { get; set; } = new ObservableCollection<AppCompany>();
    DataLayer.Helpers.CompaniesHelper CompaniesHelper { get; set; }

    private AppCompany? SelectedCompany;

    public AppCompany? MyProperty
    {
        get { return SelectedCompany; }
        set
        {
            SelectedCompany = value;
            OnPropertyChanged(nameof(SelectedCompany));
        }
    }


    public Companies()
    {
        InitializeComponent();
        CompaniesHelper = new DataLayer.Helpers.CompaniesHelper(this.GetDataContext());
        GetCompanies();
    }



    private async void GetCompanies()
    {
        CompaniesList.Clear();
        var companies = await CompaniesHelper.GetAllAsync();
        foreach (var company in companies)
        {
            CompaniesList.Add(company);
        }
        CompaniesCollectionView.ItemsSource = CompaniesList;
    }

    private async void AddNewButton_Clicked(object sender, EventArgs e)
    {
        var company = new AppCompany()
        {
            CompanyName = "New Company",
        };
        await CompaniesHelper.InsertAsync(company);
        GetCompanies();
        SelectedCompany = company;
    }

    private void RefreshButton_Clicked(object sender, EventArgs e)
    {
        GetCompanies();
    }


    private void SelectButton_Clicked(object sender, EventArgs e)
    {
        var btn = sender as Button;
        var company = btn.BindingContext as AppCompany;
        SelectedCompany = company;
        SelectedCompanyLayout.BindingContext = company;


    }

    private async void BtnSave_Clicked(object sender, EventArgs e)
    {
        if (SelectedCompany != null)
        {
            await CompaniesHelper.UpdateAsync(SelectedCompany);
        }
    }

    private async void BtnDelete_Clicked(object sender, EventArgs e)
    {
        if (SelectedCompany == null)
        {
            return;
        }
        var result = await DisplayAlert("Confirm Delete", "Delete Record?", "Ok", "Cancel");
        if(!result)
        {
            return;
        }
        await CompaniesHelper.DeleteAsync(SelectedCompany);
        SelectedCompany = null;
        GetCompanies(); 
    }
}