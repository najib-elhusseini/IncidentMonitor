using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.ServiceNow
{
    public class ServiceNowObject
    {
        [JsonPropertyName("sys_id")]
        public string SysId { get; set; }
    }
}
