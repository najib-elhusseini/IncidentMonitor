using IncidentMonitor.DataLayer.Data;
using IncidentMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor.DataLayer.Helpers.EntityFrameworkHelpers
{
    public class IntegrationsHelper : EntityHelperEntity<Integration, int>
    {
        public IntegrationsHelper(ApplicationDbContext context) : base(context)
        {
        }


    }
}
