using IncidentMonitor.DataLayer.Data;
using IncidentMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor.DataLayer.Helpers
{
    public delegate void SettingsLoadedDelegate();
    public class DataLayerHelper : IDataLayerHelper
    {

        public SettingsLoadedDelegate OnHelpersInitialized { get; set; }


        public DataLayerHelper(string databseFolderPath)
        {
            Context = new DataContext(databseFolderPath);
            RemedyForceSettingsHelper = new RemedyForceSettingsHelper(Context);
            NotificationUsersHelper = new(context: Context);
            SmtpSettingsHelper = new SmtpSettingsHelper(context: Context);
            CompaniesHelper = new CompaniesHelper(context: Context);

            InitiateHelpersAsync();
        }

        private async void InitiateHelpersAsync()
        {
            var setting = await RemedyForceSettingsHelper.GetRemedyForceSettingsAsync();           
            RemedyForceSettings = setting;
            if (setting != null)
            {
                RemdyForceIncidentsHelper = new RemedyForceIncidentsHelper(setting);
            }

            if (OnHelpersInitialized != null)
            {
                OnHelpersInitialized();
            }

        }

        public DataContext Context { get; protected set; }





        public NotificationUsersHelper NotificationUsersHelper { get; protected set; }

        public SmtpSettingsHelper SmtpSettingsHelper { get; protected set; }

        public CompaniesHelper CompaniesHelper { get; protected set; }

        public string GetAccessToken(RemedyForceSetting setting)
        {


            if (!setting.ValidateSettings())
            {
                throw new Exception("One or more required fields is missing");
            }

            var password = setting.GetCompletePassword();
            var url = $"{setting.InstanceUrl}/{setting.TokenEndpoint}";

            throw new NotImplementedException();
        }


        public RemedyForceSettingsHelper RemedyForceSettingsHelper { get; protected set; }

        public RemedyForceIncidentsHelper? RemdyForceIncidentsHelper { get; protected set; }

        public RemedyForceSetting? RemedyForceSettings { get; protected set; }



    }
}
