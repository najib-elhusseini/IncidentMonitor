using IncidentMonitor.Models;
using Microsoft.AspNetCore.Identity;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.DataLayer.Models
{
    public class ApplicationUser : IdentityUser, IHelpDeskObject
    {

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public bool? IsActive { get; set; }

        public int? CompanySiteId { get; set; }

        [ForeignKey(nameof(CompanySiteId))]
        public CompanySite? CompanySite { get; set; }


        [JsonPropertyName("tzOffset")]
        public int? TimeZoneOffset { get; set; }

        [JsonPropertyName("shiftStartHours")]
        public int ShiftStartHours { get; set; }

        [JsonPropertyName("shiftStartMinutes")]
        public int ShiftStartMinutes { get; set; }

        [JsonPropertyName("shiftEndHours")]
        public int ShiftEndHours { get; set; }

        [JsonPropertyName("shiftEndMinutes")]
        public int ShiftEndMinutes { get; set; }

        [JsonPropertyName("enableEmailNotifications")]
        public bool? EnableEmailNotifications { get; set; } = true;

        [JsonPropertyName("externalId")]
        public string? ExternalId { get; set; }


        /// <summary>
        /// Quick and dirty email validation that only checks for nullability and looks for an @ char to be present         
        /// A regex validation is due for a more solid approach
        /// </summary>        
        public bool CanReceiveEmailNotifications
        {
            get
            {
                if (EnableEmailNotifications == false) return false;
                if (string.IsNullOrWhiteSpace(Email))
                {
                    return false;
                }
                if (!Email.Any(c => c == '@'))
                {
                    return false;
                }

                return true;
            }
        }

        public bool CanLogin => !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(PasswordHash) && IsActive == true;

        [NotMapped]
        public bool IsSelected
        {
            get; set;
        } = false;

        [NotMapped]
        public string FullName
        {
            get
            {
                var fullName = $"{FirstName} {LastName}".Trim();
                if (string.IsNullOrWhiteSpace(fullName))
                {
                    return UserName ?? fullName;
                }
                return fullName;
            }
        }

        [NotMapped]
        public bool IsAdmin { get; set; } = false;

        [NotMapped]
        public string RoleName
        {
            get
            {
                return IsAdmin ? "Admin" : "User";
            }
        }

        [NotMapped]
        [JsonPropertyName("companySiteName")]
        public string CompanySiteName => CompanySite?.CompanyName ?? "";

    }

    public class ApplicationUserViewModel
    {
        public ApplicationUserViewModel()
        {
            Id = string.Empty;
        }
        public ApplicationUserViewModel(ApplicationUser u)
        {
            Id = u.Id;
            FirstName = u.FirstName;
            LastName = u.LastName;
            Email = u.Email;
            UserName = u.UserName ?? "";
            FullName = u.FullName;
            Token = "";
            IsAdmin = u.IsAdmin;
            RoleName = u.RoleName;
            IsActive = u.IsActive;
            EnableEmailNotifications = u.EnableEmailNotifications;
            CompanySiteId = u.CompanySiteId;
            ShiftStartHours = u.ShiftStartHours;
            ShiftStartMinutes = u.ShiftStartMinutes;
            ShiftEndHours = u.ShiftEndHours;
            ShiftEndMinutes = u.ShiftEndMinutes;
            TzOffset = u.TimeZoneOffset;
            CompanySiteName = u.CompanySiteName;
        }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string? LastName { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("userName")]
        public string? UserName { get; set; }

        [JsonPropertyName("fullName")]
        public string? FullName { get; set; }

        [JsonPropertyName("token")]
        public string? Token { get; set; }

        [JsonPropertyName("isAdmin")]
        public bool? IsAdmin { get; set; }

        [JsonPropertyName("roleName")]
        public string? RoleName { get; set; }

        [JsonPropertyName("lastLoginDate")]
        public DateTime? LastLoginDate { get; set; }

        [JsonPropertyName("loginValidUntil")]
        public DateTime? LoginValidUntil { get; set; }

        [JsonPropertyName("companySiteId")]
        public int? CompanySiteId { get; set; }

        [JsonPropertyName("isActive")]
        public bool? IsActive { get; set; }

        [JsonPropertyName("enableEmailNotifications")]
        public bool? EnableEmailNotifications { get; set; }

        [JsonPropertyName("shiftStartHours")]
        public int? ShiftStartHours { get; set; }

        [JsonPropertyName("shiftEndHours")]
        public int? ShiftEndHours { get; set; }

        [JsonPropertyName("shiftStartMinutes")]
        public int? ShiftStartMinutes { get; set; }

        [JsonPropertyName("shiftEndMinutes")]
        public int? ShiftEndMinutes { get; set; }

        [JsonPropertyName("tzOffset")]
        public int? TzOffset { get; set; }

        [JsonPropertyName("companySiteName")]
        public string? CompanySiteName { get; set; }




    }
}
