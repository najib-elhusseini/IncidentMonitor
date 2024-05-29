using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.RemedyForce
{
    public class IncidentHistoryEntry : RemedyForceObject
    {
        public string? Name { get; set; }

        //public string? CreatedDate { get;set; }

        [JsonPropertyName("BMCServiceDesk__description__c")]
        public string? Description { get; set; }

        [JsonPropertyName("BMCServiceDesk__note__c")]
        public string? Note { get; set; }

        [JsonPropertyName("BMCServiceDesk__RichTextNote__c")]
        public string? RichTextNote { get; set; }


        [JsonPropertyName("CreatedBy")]
        public User? CreatedBy { get; set; }
    }
}
