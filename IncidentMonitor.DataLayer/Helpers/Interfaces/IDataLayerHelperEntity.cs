using IncidentMonitor.DataLayer.Data;
using IncidentMonitor.DataLayer.Helpers.AssystHelpers;
using IncidentMonitor.DataLayer.Helpers.EntityFrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor.DataLayer.Helpers
{
    public interface IDataLayerHelperEntity
    {
        public ApplicationDbContext Context { get; }

        public void Save();

        public Task SaveAsync();


        public UsersHelper UsersHelper { get; }

        public CompanySitesHelper CompanySitesHelper { get; }

        public RemedyForceSettingsHelperEntity RemedyForceSettingsHelper { get; }

        public SmtpConfigHelper SmtpConfigHelper { get; }

        public RemedyForceIncidentsHelper? RemedyForceIncidentsHelper { get; }

        public RemedyForceTaskHelper? RemedyForceTaskHelper { get; }

        public AssystSettingsHelper AssystSettingsHelper { get; }

        public AssystEventsHelper? AssystEventsHelper { get; }

        public AssystUsersHelper? AssystUsersHelper { get; }

        public AssystInfrastructureHelper? AssystInfrastructureHelper { get; }

        public CarrixServiceNowHelper CarrixServiceNowHelper { get; }

        public FreshServiceHelper FreshServiceHelper { get; }

        public IntegrationsHelper IntegrationsHelper { get; }





    }
}
