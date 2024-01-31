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
    internal class IncidentStateToBackgroundColorConverter : IValueConverter
    {

        public static string Green200Key => "Green200Brush";

        public static string Blue300Key => "Blue300Brush";

        public static string Blue400Key => "Blue400Brush";

        public static string Blue500Key => "Blue500Brush";
        public static string Red500Key => "Red500Brush";
        public static string Orange400Key => "Orange400Brush";

        public static string Black => "Black";


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var incident = value as Incident;
            if (incident == null)
            {
                return new SolidColorBrush(Colors.White);
            }

            
            var brush = Application.Current.FindResource(Orange400Key) as SolidColorBrush;
            

            

            if (incident.IncidentCreationDate == null)
            {
                return brush;
            }
            if (MainWindow.Instance == null)
            {
                return brush;
            }

            var defaultCompany = MainWindow.Instance.DefaultCompany;
            var today = MainWindow.Instance.Today;
            string key = Orange400Key;


            //var defaultCompany = mainPage.DefaultCompany;
            //var incident = mainPage.Incidents.First(i => i.Id == value.ToString());


            // If incident date is from a previous period, we are not concerned about it
            // But we may still need a visual clue so green for responded and orange for non responded.           
            // If incident is within shift, we need some sort of an indicator
            // Red for non responded and green for responded
            if (defaultCompany.IsWithinShift(incident.IncidentCreationDate.Value)
                &&
                incident.IncidentCreationDate.Value >= today
                )
            {
                key = incident.RespondedDateTime != null ?
                   Blue500Key : Red500Key;
                    
            }
            else
            {
                key = incident.RespondedDateTime != null ?
                   "Green600Brush" : Orange400Key;
                   
            }
            var b = Application.Current.TryFindResource(key) as SolidColorBrush;
            return b!;
            
            //return color;


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
