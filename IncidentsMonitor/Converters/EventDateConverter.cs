using IncidentMonitor.Models.Assyst;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace IncidentMonitor.Converters
{
    internal class EventDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not EventDto eventDto)
            {
                return "N/A";
            }
            if (eventDto.DateLogged == null)
            {
                return "N/A";
            }

            var localDateTime = eventDto.DateLogged.Value.ToLocalTime();

            return localDateTime.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
