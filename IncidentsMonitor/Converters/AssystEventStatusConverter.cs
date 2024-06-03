using IncidentMonitor.Models.Assyst;
using IncidentMonitor.Models.RemedyForce;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace IncidentMonitor.Converters
{
    public class AssystEventStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var eventDto = value as EventDto;
            if (eventDto == null)
            {
                return "N/A";
            }
            var status = eventDto.EventStatusEnum switch
            {
                EventStatusTypesEnum.CLOSED => "Closed",
                EventStatusTypesEnum.PENDING => "Resolved",
                EventStatusTypesEnum.OPEN => eventDto.LastSlaClockStop != null ? "On Hold" : "Open",
                _ => "N/A"
            };
            return status;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
