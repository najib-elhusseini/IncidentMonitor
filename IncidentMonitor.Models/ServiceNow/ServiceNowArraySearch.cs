using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models
{
    public class ServiceNowArraySearch<T> where T : ServiceNow.ServiceNowObject
    {
        [JsonPropertyName("result")]
        public IEnumerable<T>? Result { get; set; }
    }

    public class ServiceNowObjectSearch<T> where T: ServiceNow.ServiceNowObject
    {
        [JsonPropertyName("result")]
        public T? Result { get; set; }
    }
}
