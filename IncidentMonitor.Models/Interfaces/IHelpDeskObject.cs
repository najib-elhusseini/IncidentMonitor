using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models
{
    public interface IHelpDeskObject
    {

        [JsonPropertyName("shiftStartHours")]
        public int ShiftStartHours { get; set; }

        [JsonPropertyName("shiftStartMinutes")]
        public int ShiftStartMinutes { get; set; }

        [JsonPropertyName("shiftEndHours")]
        public int ShiftEndHours { get; set; }

        [JsonPropertyName("shiftEndMinutes")]
        public int ShiftEndMinutes { get; set; }

        [JsonPropertyName("enableEmailNotifications")]
        public bool? EnableEmailNotifications { get; set; }

        [JsonPropertyName("tzOffset")]
        public int? TimeZoneOffset { get; set; }


        [NotMapped]
        [JsonPropertyName("shiftStartTime")]
        public TimeOnly ShiftStartTime
        {
            get
            {
                return new TimeOnly(ShiftStartHours, ShiftStartMinutes);
            }
        }

        [NotMapped]
        [JsonPropertyName("shiftEndTime")]
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
    }
}
