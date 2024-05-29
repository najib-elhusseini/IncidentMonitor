using IncidentMonitor.DataLayer.Data;
using IncidentMonitor.DataLayer.Models;
using IncidentMonitor.Models.Assyst;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor.DataLayer.Helpers
{
    public class UsersHelper : EntityHelperEntity<ApplicationUser, string>
    {
        public UsersHelper(ApplicationDbContext context) : base(context) { }

        public IEnumerable<ApplicationRole> GetUserRoles(ApplicationUser user)
        {
            var identityUserRoles = Context.UserRoles.Where(ur => ur.UserId == user.Id).ToList();
            var identityRoles = Context.ApplicationRoles.ToList();
            var rolesToReturn = new List<ApplicationRole>();
            foreach (var identityUserRole in identityUserRoles)
            {
                var identityRole = identityRoles.FirstOrDefault(r => r.Id == identityUserRole.RoleId);
                if (identityRole != null)
                {
                    rolesToReturn.Add(identityRole);
                    if (identityRole.Name == ApplicationRole._adminRoleName)
                    {
                        user.IsAdmin = true;
                    }
                }
            }

            return rolesToReturn;
        }

        public override ApplicationUser? Get(string id, IEnumerable<string>? includedProperties = null)
        {
            var user = base.Get(id, includedProperties);
            if (user != null)
            {
                GetUserRoles(user);
            }
            return user;
        }

        public override async Task<ApplicationUser?> GetAsync(string id, IEnumerable<string>? includedProperties = null)
        {
            var user = await Context.Users
                .FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public override IEnumerable<ApplicationUser> GetAll(Expression<Func<ApplicationUser, bool>>? filter = null, IEnumerable<string>? includedProperties = null)
        {
            var sites = Context.CompanySites.ToList();
            var users = base.GetAll(filter, includedProperties);

            foreach (var user in users)
            {
                var site = sites.FirstOrDefault(s => s.Id == user.CompanySiteId);
                user.CompanySite = site;
                var roles = GetUserRoles(user);
                //if (roles != null && roles.Any(r => r.Name == ApplicationRole._adminRoleName))
                //{
                //    user.IsAdmin = true;
                //}
            }


            return users;
        }

        public IEnumerable<ApplicationUser> GetHelpDeskUsers()
        {
            var users = GetAll().Where(u => u.CanReceiveEmailNotifications);
            return users;
        }

        public IEnumerable<ApplicationUser> GetAssystHelpDeskUsers()
        {
            var users = GetAll().Where(u => !string.IsNullOrWhiteSpace(u.ExternalId));
            return users;
        }

        public override void Update(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser?> FindByEmailAsync(string? email)
        {
            var user = await Context.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }

        private (string firstName, string lastName) SplitFullName(string? fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                return ("", "");
            }
            string firstName = "", lastName = "";
            fullName = fullName.Trim();
            var splitted = fullName.Split(' ');

            if (splitted.Length > 0)
            {
                firstName = splitted[0];
                lastName = fullName.Substring(firstName.Length).Trim();

            }
            return (firstName, lastName);

        }

        public async Task<ApplicationUser> Add(AssystUserDto userDto)
        {
            var user = await FindByEmailAsync(userDto.Email);
            var company = Context.CompanySites.FirstOrDefault();

            if (user != null)
            {
                user.ExternalId = $"{userDto.Id}";
            }
            var (firstName, lastName) = SplitFullName(userDto.Name);
            if (string.IsNullOrEmpty(firstName))
            {
                firstName = userDto.Email ?? "";
            }
            if (user == null)
            {
                user = new ApplicationUser()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = userDto.Email,
                    UserName = userDto.Email,
                    ExternalId = userDto.Id.ToString(),
                    IsActive = true,
                    EnableEmailNotifications = !string.IsNullOrWhiteSpace(userDto.Email),
                };
                Context.Users.Add(user);
            }

            if (company != null && user.CompanySiteId == null)
            {
                user.TimeZoneOffset = company.TimeZoneOffset;
                user.ShiftStartHours = company.ShiftStartHours;
                user.ShiftEndHours = company.ShiftEndHours;
                user.ShiftStartMinutes = company.ShiftStartMinutes;
                user.ShiftEndMinutes = company.ShiftEndMinutes;
                user.CompanySiteId = company.Id;
            }
            return user;
        }



    }
}
