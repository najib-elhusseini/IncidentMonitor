
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor.Models
{
    public class NotificationUser : IDatabaseObject<int>
    {
        [AutoIncrement]
        [PrimaryKey]
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public bool? IsActive { get; set; }

        public bool? ReceivesNotifications { get; set; } = false;

        public int? ShiftStartTime { get; set; }

        public int? ShiftEndTime { get; set; }

        public bool IsSuperUser { get; set; }

        public string? AppPassword { get; set; }


        /// <summary>
        /// Quick and dirty email validation that only checks for nullability and looks for an @ char to be present         
        /// A regex validation is due for a more solid approach
        /// </summary>
        [Ignore]
        public bool CanReceiveEmailNotifications
        {
            get
            {
                if (ReceivesNotifications == false) return false;
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

        [Ignore]
        public bool CanLogin => !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(AppPassword) && IsActive == true;

        //SQLite.IgnoreAttribute
        [Ignore]
        public bool IsSelected
        {
            get; set;
        } = false;

        [Ignore]
        public string FullName => $"{FirstName} {LastName}".Trim();


    }


}
