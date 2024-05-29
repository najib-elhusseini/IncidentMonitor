using IncidentMonitor.DataLayer.Data;
using IncidentMonitor.DataLayer.Helpers.AssystHelpers;
using IncidentMonitor.DataLayer.Helpers.EntityFrameworkHelpers;
using IncidentMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor.DataLayer.Helpers
{
    public class DataLayerHelperEntity : IDataLayerHelperEntity
    {

        public DataLayerHelperEntity(ApplicationDbContext context)
        {
            Context = context;
            UsersHelper = new UsersHelper(context);
            CompanySitesHelper = new(context);
            RemedyForceSettingsHelper = new(context);
            SmtpConfigHelper = new(context);

            RemedyForceSetting rfSettings = RemedyForceSettingsHelper.Get();
            RemedyForceIncidentsHelper = new RemedyForceIncidentsHelper(rfSettings);
            RemedyForceTaskHelper = new RemedyForceTaskHelper(rfSettings);
            AssystSettingsHelper = new(context);
            FreshServiceHelper = new();
            IntegrationsHelper = new(context);

            var assystSettings = AssystSettingsHelper.Get();
            if (assystSettings != null)
            {
                AssystEventsHelper = new AssystEventsHelper(assystSettings);
                AssystUsersHelper = new AssystUsersHelper(assystSettings);
                AssystInfrastructureHelper = new AssystInfrastructureHelper(assystSettings);
            }

            CarrixServiceNowHelper = new CarrixServiceNowHelper();

        }

        #region Save context implementation

        public void Save()
        {
            Context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
        #endregion

        public ApplicationDbContext Context { get; private set; }

        public UsersHelper UsersHelper { get; private set; }

        public CompanySitesHelper CompanySitesHelper { get; private set; }

        public RemedyForceSettingsHelperEntity RemedyForceSettingsHelper { get; private set; }

        public SmtpConfigHelper SmtpConfigHelper { get; private set; }

        public RemedyForceIncidentsHelper? RemedyForceIncidentsHelper { get; private set; }

        public RemedyForceTaskHelper? RemedyForceTaskHelper { get; private set; }

        public AssystSettingsHelper AssystSettingsHelper { get; private set; }


        public AssystEventsHelper? AssystEventsHelper { get; private set; }

        public AssystUsersHelper? AssystUsersHelper { get; private set; }

        public AssystInfrastructureHelper? AssystInfrastructureHelper { get; private set; }

        public CarrixServiceNowHelper CarrixServiceNowHelper { get; private set; }

        public FreshServiceHelper FreshServiceHelper { get; private set; }

        public IntegrationsHelper IntegrationsHelper { get; private set; }
    }
}
