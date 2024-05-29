using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models
{
    public class CompanySite : IHelpDeskObject
    {
        [Key]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("companyName")]
        public string? CompanyName { get; set; }

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

        [JsonPropertyName("enableAlarmNotifications")]
        public bool? EnableAlarmNotifications { get; set; } = false;

        /// <summary>
        /// Gets or sets the interval of sound alarm in milliseconds
        /// </summary>

        [JsonPropertyName("alarmInterval")]
        public int? AlarmInterval { get; set; }

        [JsonPropertyName("alarmIntervalSeconds")]
        public int? AlarmIntervalSeconds
        {
            get
            {
                if (AlarmInterval == null || AlarmInterval == 0)
                {
                    return null;
                }
                return AlarmInterval / 1000;
            }
            set
            {
                AlarmInterval = value * 1000;
            }
        }

        [Obsolete]
        public int? RefreshInterval { get; set; }



    }
}
