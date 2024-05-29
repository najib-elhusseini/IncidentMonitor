using IncidentMonitor.DataLayer.Data;
using IncidentMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor.DataLayer.Helpers
{
    public class SmtpConfigHelper : EntityHelperEntity<EmailConfiguration, int>
    {
        public SmtpConfigHelper(ApplicationDbContext context) : base(context)
        {
        }

        public EmailConfiguration Get()
        {
            var emailConfiguration = Context.EmailConfigurations.FirstOrDefault();
            if (emailConfiguration == null)
            {
                emailConfiguration = new EmailConfiguration() { EnableSsl = true };
                Context.EmailConfigurations.Add(emailConfiguration);
                Context.SaveChanges();
            }
            return emailConfiguration;
        }

        public override void Update(EmailConfiguration entity)
        {
            throw new NotImplementedException();
        }

        
    }
}
