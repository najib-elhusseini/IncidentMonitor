using IncidentMonitor.DataLayer.Data;
using IncidentMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor.DataLayer.Helpers
{
    public interface IDataLayerHelper
    {
        public DataContext Context { get; }

        public RemedyForceSettingsHelper RemedyForceSettingsHelper { get; }

        public NotificationUsersHelper NotificationUsersHelper { get; }

        public SmtpSettingsHelper SmtpSettingsHelper { get; }

        public CompaniesHelper CompaniesHelper { get; }

        public RemedyForceIncidentsHelper? RemdyForceIncidentsHelper { get; }

        public RemedyForceSetting? RemedyForceSettings { get; }

        public bool RemedyForceSettingsValid
        {
            get
            {
                return RemedyForceSettings != null && RemedyForceSettings.ValidateSettings();
            }
        }
    }
}
