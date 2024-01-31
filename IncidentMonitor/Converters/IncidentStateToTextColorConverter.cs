using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor.Converters
{
    internal class IncidentStateToTextColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var app = Application.Current;
            var mainPage = parameter as MainPage;
            Color color = app.GetColor(ApplicationExtensions.Black);
            // unlikely, but early return to avoid null pointers nevertheless
            if (value == null)
            {
                return color;
            }


            var incident = mainPage.Incidents.First(i => i.Id == value.ToString());
            var withinShift = mainPage.DefaultCompany.IsWithinShift(incident.IncidentCreationDate.Value);
            if (withinShift && incident.RespondedDateTime == null)
            {
                color = app.GetColor("Red50");
            }

            return color;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
