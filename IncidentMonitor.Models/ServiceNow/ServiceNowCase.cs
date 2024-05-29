using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.ServiceNow
{
    public class ServiceNowCase : ServiceNowObject, IHelpDeskTicket
    {


        public struct States
        {
            public static int StateNew => 1;
            public static int Open => 10;
            public static int OnHold => 18;
            public static int SolutionProposed => 6;
            public static int Closed => 3;
            public static int Cancelled => 7;
        }

        public static class HoistIntegrationStatuses
        {
            public static string Pending => "pending";
            public static string Active => "active";

            public static string Closed => "closed";

        }

        [JsonPropertyName("number")]
        public string Number { get; set; }

        [JsonPropertyName("sys_created_by")]
        public string? SysCreatedBy { get; set; }

        [JsonPropertyName("sys_created_on")]
        public string? SysCreatedOn { get; set; }

        [JsonPropertyName("state")]
        public string? State { get; set; }

        [JsonPropertyName("u_hoist_number")]
        public string? HoistNumber { get; set; }

        [JsonPropertyName("u_hoist_integration_status")]
        public string? HoistIntegrationStatus { get; set; }

        [JsonPropertyName("short_description")]
        public string? ShortDescription { get; set; }

        [JsonPropertyName("u_description")]
        public string? HtmlDescription { get; set; }

        [JsonPropertyName("assigned_to")]
        public object? AssignedTo { get; set; }

        [JsonPropertyName("u_caller")]
        public string? CallerId { get; set; }

        [JsonPropertyName("impact")]
        public string? Impact { get; set; }

        [JsonPropertyName("urgency")]
        public string? Urgency { get; set; }


        public string? TicketId => SysId;

        public string? TicketCreatedBy => SysCreatedBy;

        public string? TicketNumber => Number;

        public string? TicketShortDescription => ShortDescription;

        public string? TicketFullDescription => HtmlDescription;

        public DateTime? TicketCreationDate
        {
            get
            {
                if (SysCreatedOn == null) return null;
                var createdOn = SysCreatedOn.Replace(" ", "T");
                createdOn = createdOn + "Z";
                if (DateTime.TryParse(createdOn, out DateTime dateTime))
                {
                    return dateTime;
                }
                return null;
            }
        }

        public IEnumerable<IHelpDeskComment> Comments { get; set; } = new List<ServiceNowActivity>();



        /**
         * 1 - High
         * 2 - Medium
         * 3 - Low
         */

        public HelpDeskSeriousness? HelpDeskImpact
        {
            get
            {
                return Impact switch
                {
                    "1" => HelpDeskSeriousness.Major,
                    "2" => HelpDeskSeriousness.Moderate,
                    _ => HelpDeskSeriousness.Minor,
                };
            }
            set
            {
                Impact = value switch
                {
                    HelpDeskSeriousness.Critical => "1",
                    HelpDeskSeriousness.Major => "1",
                    HelpDeskSeriousness.Moderate => "2",
                    _ => "3"
                };
            }
        }
        public HelpDeskSeriousness? HelpDeskUrgency
        {
            get
            {
                return Urgency switch
                {
                    "1" => HelpDeskSeriousness.Major,
                    "2" => HelpDeskSeriousness.Moderate,
                    _ => HelpDeskSeriousness.Minor,
                };
            }
            set
            {
                Urgency = value switch
                {
                    HelpDeskSeriousness.Critical => "1",
                    HelpDeskSeriousness.Major => "1",
                    HelpDeskSeriousness.Moderate => "2",
                    _ => "3"
                };
            }
        }

        public string? TicketAffectedUserId => CallerId;

        public string? TicketAffectedUserEmail => "Not implemented yet";

        public string? TicketAssignedUser => $"{AssignedTo}";
    }



}
