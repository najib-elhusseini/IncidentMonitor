using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models
{
    public enum IntegratedSystems
    {
        Carrix,
        DiamondVogel,
        DHC
    }

    public class Integration
    {
        [Key]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("dateCreated")]
        public DateTime DateCreated { get; set; }

        [JsonPropertyName("lastUpdated")]
        public DateTime LastUpdated { get; set; }

        [JsonPropertyName("eventId")]
        public ulong EventId { get; set; }

        [JsonPropertyName("integratedTicketId")]
        public string IntegratedTicketId { get; set; }

        [JsonPropertyName("integratedSystem")]
        public IntegratedSystems IntegratedSystem { get; set; }

        [JsonPropertyName("eventData")]
        public string EventData { get; set; }

        [JsonPropertyName("integratedTickedData")]
        public string IntegratedTickedData { get; set; }

    }
}
