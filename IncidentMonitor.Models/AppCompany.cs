using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IncidentMonitor.Models
{
    public class AppCompany : IDatabaseObject<int>
    {
        [AutoIncrement]
        [PrimaryKey]
        [Key]
        public int Id { get; set; }

        public string? CompanyName { get; set; }

        public int ShiftStartHours { get; set; }

        public int ShiftStartMinutes { get; set; }

        public int ShiftEndHours { get; set; }

        public int ShiftEndMinutes { get; set; }

        public string CompanySettingsData { get; set; } = "";


        [Ignore]
        [NotMapped]
        public CompanySettings Settings
        {
            get
            {
                var defaultSettings = new CompanySettings()
                {
                    EnableAlarmNotifications = true,
                    EnableEmailNotifications = true,
                    AlarmInterval = 3000,
                    RefreshInterval = 4,
                };
                if (string.IsNullOrWhiteSpace(CompanySettingsData))
                {
                    return defaultSettings;
                }
                var settings = JsonSerializer.Deserialize<CompanySettings>(CompanySettingsData) ?? defaultSettings;
                return settings;
            }
            set
            {
                CompanySettingsData = JsonSerializer.Serialize(value);
            }
        }

        [Ignore]
        [NotMapped]
        public TimeOnly ShiftStartTime
        {
            get
            {
                return new TimeOnly(ShiftStartHours, ShiftStartMinutes);
            }
        }

        [Ignore]
        [NotMapped]
        public TimeOnly ShiftEndTime
        {
            get
            {
                return new TimeOnly(ShiftEndHours, ShiftEndMinutes);
            }
        }

        public bool IsWithinShift(TimeOnly timeOfDay) => timeOfDay >= ShiftStartTime && timeOfDay <= ShiftEndTime;

        public bool IsWithinShift(DateTime date)
        {
            var time = new TimeOnly(date.Hour, date.Minute);
            return IsWithinShift(time);
        }

        public bool IsDefaultCompany { get; set; } = false;

    }

    public class CompanySettings
    {
        public bool? EnableEmailNotifications { get; set; } = true;

        public bool? EnableAlarmNotifications { get; set; } = false;

        /// <summary>
        /// Gets or sets the interval of sound alarm in milliseconds
        /// </summary>
        public int? AlarmInterval { get; set; }

        public int? AlarmIntervalSeconds
        {
            get
            {
                return AlarmInterval / 1000;
            }
            set
            {
                AlarmInterval = value * 1000;
            }
        }

        /// <summary>
        /// Gets or sets the incidents refresh rate in seconds
        /// </summary>
        public int? RefreshInterval { get; set; }



    }
}
