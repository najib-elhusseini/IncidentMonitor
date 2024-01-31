using IncidentMonitor.DataLayer.Data;
using IncidentMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor.DataLayer.Helpers
{
    public class SmtpSettingsHelper : EntityHelper<EmailConfiguration, int>
    {
        public SmtpSettingsHelper(DataContext context) : base(context)
        {
        }

        public async Task<EmailConfiguration> GetEmailConfigurationAsync()
        {
            var emailConfig = await Connection.Table<EmailConfiguration>().FirstOrDefaultAsync();
            
            return emailConfig;
        }



    }
}
