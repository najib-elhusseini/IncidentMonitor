using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models
{
    public struct SearchResultCount
    {
        [JsonPropertyName("value")]
        public int Value { get; set; }
    }
}
