using IncidentMonitor.DataLayer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor.DataLayer.Data
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private const string _adminUserName = "admin";
        private const string _adminDefaultPassword = "123456";

        readonly UserManager<ApplicationUser> userManager;
        readonly RoleManager<ApplicationRole> roleManager;
        public DatabaseInitializer(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task Initialize()
        {
            foreach (var roleName in ApplicationRole.IdentityRoleNames)
            {
                var exists = await roleManager.RoleExistsAsync(roleName);
                if (!exists)
                {
                    await roleManager.CreateAsync(new ApplicationRole(roleName));
                }
            }

            var adminUser = await userManager.FindByNameAsync(_adminUserName);

            string adminRole = ApplicationRole._adminRoleName;
            if (adminUser == null)
            {
                adminUser = new ApplicationUser()
                {
                    UserName = _adminUserName,
                };
                var result = await userManager.CreateAsync(adminUser, _adminDefaultPassword);

            }

            var isAdmin = await userManager.IsInRoleAsync(adminUser, adminRole);
            if (!isAdmin)
            {
                await userManager.AddToRoleAsync(adminUser, adminRole);
            }



        }
    }
}
