using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.FreshService
{
    public class Requester
    {
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("id")]
        public ulong? Id { get; set; }

        [JsonPropertyName("mobile")]
        public string? Mobile { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("phone")]
        public string? Phone { get; set; }
    }

  

}
