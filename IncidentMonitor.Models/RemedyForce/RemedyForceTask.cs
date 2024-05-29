using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.RemedyForce
{
    public class RemedyForceTask : RemedyForceObject
    {

        public string? Name { get; set; }


        public string? BMCServiceDesk__Client_Account__c { get; set; }

        public string? BMCServiceDesk__Client_ID__c { get; set; }

        public string? BMCServiceDesk__taskDescription__c { get; set; }

        public string? BMCServiceDesk__shortDescription__c { get; set; }

        public string? Incident_Title__c { get; set; }

        public string? Incident_Account__c { get; set; }

        public string? BA_Responsible_Incident_Staff__c { get; set; }


        public RemedyForceQuerySet<TaskHistory>? BMCServiceDesk__Task_History__r { get; set; }

        public IEnumerable<TaskHistory> TaskHistories => BMCServiceDesk__Task_History__r?.Records ?? new List<TaskHistory>();


        public Incident? BMCServiceDesk__FKIncident__r { get; set; }


        [JsonPropertyName("BMCServiceDesk__FKOpenBy__r")]
        public User? Staff { get; set; }

        [JsonPropertyName("BMCServiceDesk__FKStatus__r")]
        public Status? Status { get; set; }

        [JsonPropertyName("BMCServiceDesk__FKUrgency__r")]
        public Urgency? Urgency { get; set; }

        [JsonPropertyName("BMCServiceDesk__FKImpact__r")]
        public Impact? Impact { get; set; }

    }

    public class TaskHistory : RemedyForceObject
    {


        public string? BMCServiceDesk__note__c { get; set; }

    }
}
