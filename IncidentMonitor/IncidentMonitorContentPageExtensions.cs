using IncidentMonitor.DataLayer.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor
{
    public static class IncidentMonitorContentPageExtensions
    {
        [RequiresAssemblyFiles()]
        public static DataContext GetDataContext(this ContentPage page)
        {
            

            var appDataDir = GetAppDirectory(page);
            var context = new DataContext(appDataDir);
            return context;
        }

        [RequiresAssemblyFiles()]
        public static string GetAppDirectory(this ContentPage page)
        {
            var location = Assembly.GetExecutingAssembly().Location;

            var appDataDir = Path.GetDirectoryName(location);
            return appDataDir;
        }
    }
}
