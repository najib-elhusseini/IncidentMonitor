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

        [JsonPropertyName("OwnerId")]
        public string? OwnerId { get; set; }

        [JsonPropertyName("IsDeleted")]
        public bool? IsDeleted { get; set; }

        [JsonPropertyName("Name")]
        public string? Name { get; set; }

        [JsonPropertyName("Title__c")]
        public string? Title { get; set; }

        [JsonPropertyName("CreatedById")]
        public string? CreatedById { get; set; }

        [JsonPropertyName("CreatedBy")]
        public User? CreatedBy { get; set; }

        [JsonPropertyName("BMCServiceDesk__FKClient__r")]
        public User? Client { get; set; }

        [JsonPropertyName("BMCServiceDesk__FKOpenBy__r")]
        public User? Staff { get; set; }


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

        [JsonPropertyName("BMCServiceDesk__Queue__c")]
        public string? Queue { get; set;}


        [JsonPropertyName("BMCServiceDesk__Client_Account__c")]
        public string? ClientAccountName { get; set; }

        [JsonPropertyName("BMCServiceDesk__Incident_Histories__r")]
        public RemedyForceQuerySet<IncidentHistoryEntry>? IncidentHistories { get; set; }

        [JsonPropertyName("Attachments")]
        public RemedyForceQuerySet<Attachment>? Attachments { get; set; }

        [JsonPropertyName("BMCServiceDesk__respondedDateTime__c")]
        public string? RespondedDateTime { get; set; }

        [JsonPropertyName("BMCServiceDesk__Launch_console__c")]
        public string? ConsoleUrl { get; set; }

        public string? InstanceUrl { get; set; }

        [JsonIgnore]
        public string RespondedStatus
        {
            get
            {
                return RespondedDateTime == null ? "NO" : "YES";
            }
        }


        public bool IsSeen { get; set; } = false;

        public EventAcknowledgedStatus? IncidentStatus { get; set; }


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



        [JsonPropertyName("BMCServiceDesk__closeDateTime__c")]
        public string? ClosedDateTime { get; set; }

        [JsonPropertyName("BMCServiceDesk__dueDateTime__c")]
        public string? BMCServiceDesk__dueDateTime__c { get; set; }

        [JsonPropertyName("BMCServiceDesk__openDateTime__c")]
        public string? OpenDateTime { get; set; }

        [JsonPropertyName("BMCServiceDesk__Closed_By__c")]
        public string? ClosedBy { get; set; }

        [JsonPropertyName("BMCServiceDesk__TotalWorkTime__c")]
        public double? TotalWorkTime { get; set; }

        [JsonPropertyName("System_Category_del__c")]
        public string? SystemCategory { get; set; }

        [JsonPropertyName("IFS_Functional_Flow__c")]
        public string? IfsFunctionalFlow { get; set; }

        [JsonPropertyName("Customer_Case_ID__c")]
        public string? CustomerCaseId { get; set; }

        [JsonPropertyName("Environment__c")]
        public string? Environment { get; set; }

        [JsonPropertyName("Track__c")]
        public string? Track { get; set; }

        [JsonPropertyName("Customer_Request_Type__c")]
        public string? CustomerRequestType { get; set; }

        [JsonPropertyName("Cost_Center__c")]
        public string? CostCenter { get; set; }

        [JsonPropertyName("IFS_Case_ID__c")]
        public string? IfsCaseId { get; set; }

        [JsonPropertyName("Total_Billable_Time__c")]
        public double? TotalBillableTime { get; set; }

        [JsonPropertyName("CRIM__c")]
        public bool? IsCrim { get; set; }

        [JsonPropertyName("BMCServiceDesk__Status_ID__c")]
        public string? StatusId { get; set; }

        

    }

    
}
