using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor.Converters
{
    public class UtcDateStringToDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return "N/A";
            
            if (DateTime.TryParse(value.ToString(), out DateTime date))
            {                
                return $"{date.ToString("dd/MM/yyyy")} {date.ToShortTimeString()}";
            }

            return "N/A";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
