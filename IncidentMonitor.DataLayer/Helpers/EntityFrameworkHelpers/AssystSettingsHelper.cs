using IncidentMonitor.DataLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor.DataLayer.Helpers.EntityFrameworkHelpers
{
    public class AssystSettingsHelper : EntityHelperEntity<AssystSettings, int>
    {
        public AssystSettingsHelper(ApplicationDbContext context) : base(context)
        {
        }

        public AssystSettings Get()
        {
            var settings = Context.AssystSettings.SingleOrDefault();
            if (settings == null)
            {
                settings = new AssystSettings()
                {
                    UserName = "",
                    Password = "",
                    BaseUrl = "https://assyst.hoist.tech/"
                };

                Context.AssystSettings.Add(settings);
                Context.SaveChanges();
            }
            return settings;
        }
    }
}
