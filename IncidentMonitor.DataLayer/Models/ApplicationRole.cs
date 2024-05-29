using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor.DataLayer.Models
{
    public class ApplicationRole : IdentityRole
    {
        public const string _adminRoleName = "role_admin";
        public const string _userRoleName = "role_user";

        private const string _adminDisplayName = "Admin";
        private const string _userDisplayName = "User";

        public static IEnumerable<string> IdentityRoleNames => new List<string>()
        {
            _adminRoleName, _userRoleName,
        };

        public ApplicationRole()
        {
            
        }

        public ApplicationRole(string roleName) : base(roleName) { }
    }
}
