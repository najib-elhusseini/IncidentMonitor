using IncidentMonitor.DataLayer.Data;
using IncidentMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor.DataLayer.Helpers
{
    public class CompaniesHelper : EntityHelper<AppCompany, int>
    {
        public CompaniesHelper(DataContext context) : base(context)
        {
        }

        public async Task<AppCompany> GetDefaultCompanyAsync()
        {
            var all = await GetAllAsync();
            var company = all.FirstOrDefault();
            if (company == null)
            {
                company = new()
                {
                    ShiftStartHours = 10,
                    ShiftEndHours = 18,
                    ShiftStartMinutes = 30,
                    ShiftEndMinutes = 30,
                };
                var success = await InsertAsync(company);
            }

            return company;
        }

        public override async Task<List<AppCompany>> GetAllAsync()
        {
            var result = await base.GetAllAsync();
            return result.OrderByDescending(c => c.IsDefaultCompany).ToList();
        }
    }
}
