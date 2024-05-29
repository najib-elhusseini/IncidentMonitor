using IncidentMonitor.DataLayer.Data;
using IncidentMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor.DataLayer.Helpers
{
    public class CompanySitesHelper : EntityHelperEntity<CompanySite, int>
    {
        public CompanySitesHelper(ApplicationDbContext context) : base(context)
        {

        }

        public override IEnumerable<CompanySite> GetAll(Expression<Func<CompanySite, bool>>? filter = null, IEnumerable<string>? includedProperties = null)
        {
            var result = base.GetAll(filter, includedProperties).OrderBy(s => s.CompanyName);
            return result;

        }

        public override void Update(CompanySite entity)
        {
            throw new NotImplementedException();
        }
    }
}
