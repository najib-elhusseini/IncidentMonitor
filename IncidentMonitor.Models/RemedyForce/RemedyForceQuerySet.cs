using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.RemedyForce
{
    public class RemedyForceQuerySet<T> where T : RemedyForceObject
    {
        [JsonPropertyName("totalSize")]
        public int TotalSize { get; set; }

        [JsonPropertyName("done")]
        public bool Done { get; set; }

        [JsonPropertyName("nextRecordsUrl")]
        public string? NextRecordsUrl { get; set; }

        [JsonPropertyName("records")]
        public List<T> Records { get; set; }

    }
}
