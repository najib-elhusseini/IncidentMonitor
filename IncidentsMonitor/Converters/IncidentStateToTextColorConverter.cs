using IncidentMonitor.Models.RemedyForce;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace IncidentMonitor.Converters
{
    [Obsolete]
    internal class IncidentStateToTextColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var incident = value as Incident;

            var mainWindow = MainWindow.Instance;
            string brushKey = "Slate700Brush";
            // unlikely, but early return to avoid null pointers nevertheless
            if (mainWindow == null ||
                incident == null ||
                incident.IncidentCreationDate == null
                )
            {
                return Application.Current.TryFindResource(brushKey);
            }


            //var incident = mainWindow.Incidents.First(i => i.Id == value.ToString());
            var withinShift = mainWindow.DefaultCompany.IsWithinShift(incident.IncidentCreationDate.Value);
            if (incident.IncidentCreationDate >= mainWindow.Today && withinShift)
            {
                brushKey = incident.RespondedDateTime == null ? "Red50Brush" : "Blue50Brush";
            }
            else
            {
                brushKey = incident.RespondedDateTime == null ? "Orange50Brush" : "Green50Brush";
            }
            //else
            //{
            //    brushKey = "Orange400Brush";
            //}

            return Application.Current.TryFindResource(brushKey);

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
