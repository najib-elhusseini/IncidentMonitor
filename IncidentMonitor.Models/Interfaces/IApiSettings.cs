using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor.Models
{
    public interface IApiSettings
    {
        public string BaseUrl { get; }

        public string UserName { get; }

        public string Password { get; }
        
    }
}
