
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.ServiceNow
{
    public class ServiceNowSettings : IApiSettings
    {

        public string BaseUrl { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
