using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor.Converters
{
    internal class IncidentStateToBackgroundColorConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var mainPage = parameter as MainPage;
            var app = Application.Current;
            Color color = app.GetColor(ApplicationExtensions.Orange400Key);
            // unlikely, but early return to avoid null pointers nevertheless
            if (value == null)
            {
                return color;
            }

            var defaultCompany = mainPage.DefaultCompany;
            var incident = mainPage.Incidents.First(i => i.Id == value.ToString());


            // If incident date is from a previous period, we are not concerned about it
            // But we may still need a visual clue so green for responded and orange for non responded.           
            // If incident is within shift, we need some sort of an indicator
            // Red for non responded and green for responded
            if (defaultCompany.IsWithinShift(incident.IncidentCreationDate.Value)
                &&
                incident.IncidentCreationDate.Value >= mainPage.Today
                )
            {
                color = incident.RespondedDateTime != null ?
                   app.GetColor(ApplicationExtensions.Blue300Key) :
                    app.GetColor(ApplicationExtensions.Red500Key);
            }
            else
            {
                color = incident.RespondedDateTime != null ?
                   app.GetColor(ApplicationExtensions.Green200Key) :
                   app.GetColor(ApplicationExtensions.Orange400Key);
            }

            return color;


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
