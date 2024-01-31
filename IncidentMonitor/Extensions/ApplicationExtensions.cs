using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor
{
    public static class ApplicationExtensions
    {
        public static string Green200Key => "Green200";

        public static string Blue300Key => "Blue300";

        public static string Blue400Key => "Blue400";
        
        public static string Blue500Key => "Blue500";
        public static string Red500Key => "Red500";
        public static string Orange400Key => "Orange400";

        public static string Black => "Black";



        public static Color GetColor(this Application application, string key)
        {
            var result = application.Resources.TryGetValue(key, out object color);
            if (result && color is Color)
            {
                return color as Color;
            }
            //orange400 background as default
            return new Color(253, 186, 116);
        }
    }
}
