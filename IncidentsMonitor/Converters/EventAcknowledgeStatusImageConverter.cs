using IncidentMonitor.Models.Assyst;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace IncidentMonitor.Converters
{
    public class EventAcknowledgeStatusImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not EventDto @event)
            {
                return "";
            }
            var path = @event.EventAcknowledgedStatus switch
            {
                Models.EventAcknowledgedStatus.RespondedInShift => "check-circle-green.png",
                Models.EventAcknowledgedStatus.RespondedNotInShift => "check-circle-green.png",
                Models.EventAcknowledgedStatus.UnrespondedInShift => "x-circle-red.png",
                Models.EventAcknowledgedStatus.UnsrespondedNotInShift => "x-circle-orange.png",
                _ => "x-circle-orange.png",
            };
            var uri = new Uri($"pack://application:,,,/IncidentsMonitor;component/Resources/Images/{path}");
            var imageSource = new BitmapImage(uri);
            return imageSource;
            //throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
