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
}
