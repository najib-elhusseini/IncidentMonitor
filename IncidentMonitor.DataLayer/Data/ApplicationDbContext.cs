using IncidentMonitor.DataLayer.Models;
using IncidentMonitor.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor.DataLayer.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }

        public DbSet<ApplicationRole> ApplicationRoles { get; set; }

        public DbSet<CompanySite> CompanySites { get; set; }

        public DbSet<RemedyForceSetting> RemedyForceSettings { get; set; }

        public DbSet<AssystSettings> AssystSettings { get; set; }

        public DbSet<EmailConfiguration> EmailConfigurations { get; set; }

        public DbSet<Integration> Integrations { get; set; }



    }
}
