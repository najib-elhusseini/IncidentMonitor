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
    public class AssystEventCompanyNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var @event = value as EventDto;
            if(@event == null)
            {
                return "N/A";
            }

            return @event.Department?.Section?.Name ?? @event.Department?.SectionDepartmentName ?? "N/A";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
