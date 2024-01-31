using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IncidentMonitor.Models.RemedyForce
{

    /// <summary>
    /// Data Model for BMCServiceDesk__Incident__c
    /// </summary>
    public class Incident : RemedyForceObject
    {

        public string OwnerId { get; set; }

        public bool? IsDeleted { get; set; }

        public string Name { get; set; }

        [JsonPropertyName("Title__c")]
        public string Title { get; set; }



        public string CreatedById { get; set; }

        public User? CreatedBy { get; set; }

        [JsonPropertyName("BMCServiceDesk__FKClient__r")]
        public User? Client { get; set; }

        [JsonPropertyName("BMCServiceDesk__FKAccount__r")]
        public Account? Account { get; set; }


        [JsonPropertyName("BMCServiceDesk__FKStatus__r")]
        public Status? Status { get; set; }

        [JsonPropertyName("BMCServiceDesk__FKUrgency__r")]
        public Urgency? Urgency { get; set; }

        [JsonPropertyName("BMCServiceDesk__FKImpact__r")]
        public Impact? Impact { get; set; }


        [JsonPropertyName("BMCServiceDesk__shortDescription__c")]
        public string? ShortDescription { get; set; }


        [JsonPropertyName("BMCServiceDesk__incidentDescription__c")]
        public string? IncidentDescription { get; set; }

        [JsonPropertyName("BMCServiceDesk__incidentResolution__c")]
        public string? IncidentResolution { get; set; }


        [JsonPropertyName("BMCServiceDesk__queueName__c")]
        public string? QueueName { get; set; }

        [JsonPropertyName("BMCServiceDesk__Client_Account__c")]
        public string? ClientAccountName { get; set; }

        [JsonPropertyName("BMCServiceDesk__Incident_Histories__r")]
        public RemedyForceQuerySet<IncidentHistoryEntry>? IncidentHistories { get; set; }

        [JsonPropertyName("Attachments")]
        public RemedyForceQuerySet<Attachment>? Attachments { get; set; }

        [JsonPropertyName("BMCServiceDesk__respondedDateTime__c")]
        public string? RespondedDateTime { get; set; }

        [JsonIgnore]
        public string RespondedStatus
        {
            get
            {
                return RespondedDateTime == null ? "NO" : "YES";
            }
        }




        public bool IsSeen { get; set; } = false;


        #region Calculated properties


        [JsonIgnore]
        public DateTime? IncidentCreationDate
        {
            get
            {
                if (CreatedDate == null)
                {
                    return null;
                }

                if (DateTime.TryParse(CreatedDate.ToString(), out DateTime date))
                {
                    return date;
                }
                return null;
            }
        }

        [JsonIgnore]
        public string IncidentName => $"IN{Name}";
        #endregion
    }
}
