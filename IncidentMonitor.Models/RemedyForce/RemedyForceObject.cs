using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.RemedyForce
{
    public class RemedyForceObject
    {
        [JsonPropertyName("attributes")]
        public RemedyForceAttributes? Attributes { get; set; }

        [JsonPropertyName("Id")]
        public string? Id { get; set; }

        [JsonPropertyName("CreatedDate")]
        public string? CreatedDate { get; set; }


        


    }

    

    public class RemedyForceAttributes
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }

    }
}
