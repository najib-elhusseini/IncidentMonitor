using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor.Models
{
    public class AppCompany : IDatabaseObject<int>
    {
        [AutoIncrement]
        [PrimaryKey]
        public int Id { get; set; }

        public string? CompanyName { get; set; }


        public int ShiftStartHours { get; set; }

        public int ShiftStartMinutes { get; set; }

        public int ShiftEndHours { get; set; }

        public int ShiftEndMinutes { get; set; }


        [Ignore]
        public TimeOnly ShiftStartTime
        {
            get
            {
                return new TimeOnly(ShiftStartHours, ShiftStartMinutes);
            }
        }

        [Ignore]
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
}
