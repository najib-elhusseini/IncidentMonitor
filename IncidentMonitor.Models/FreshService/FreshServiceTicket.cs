using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.FreshService
{
    public class FreshServiceTicket : IHelpDeskTicket
    {
        [JsonPropertyName("subject")]
        public string? Subject { get; set; }

        [JsonPropertyName("group_id")]
        public long? GroupId { get; set; }

        [JsonPropertyName("department_id")]
        public object? Department_id { get; set; }

        [JsonPropertyName("category")]
        public object? Category { get; set; }

        [JsonPropertyName("sub_category")]
        public object? Sub_category { get; set; }

        [JsonPropertyName("item_category")]
        public object? Item_category { get; set; }

        [JsonPropertyName("requester_id")]
        public long? Requester_id { get; set; }



        [JsonPropertyName("responder_id")]
        public ulong? Responder_id { get; set; }

        [JsonPropertyName("responder")]
        public Agent? Responder { get; set; }

        [JsonPropertyName("due_by")]
        public string? Due_by { get; set; }

        [JsonPropertyName("fr_escalated")]
        public bool? Fr_escalated { get; set; }

        [JsonPropertyName("deleted")]
        public bool? Deleted { get; set; }

        [JsonPropertyName("spam")]
        public bool? Spam { get; set; }

        [JsonPropertyName("email_config_id")]
        public object? Email_config_id { get; set; }

        [JsonPropertyName("fwd_emails")]
        public object? Fwd_emails { get; set; }

        [JsonPropertyName("reply_cc_emails")]
        public object? Reply_cc_emails { get; set; }

        [JsonPropertyName("cc_emails")]
        public object? Cc_emails { get; set; }

        [JsonPropertyName("is_escalated")]
        public bool? Is_escalated { get; set; }

        [JsonPropertyName("fr_due_by")]
        public string? Fr_due_by { get; set; }

        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("priority")]
        public int? Priority { get; set; }

        [JsonPropertyName("status")]
        public int? Status { get; set; }

        [JsonPropertyName("source")]
        public int? Source { get; set; }

        [JsonPropertyName("created_at")]
        public string? Created_at { get; set; }

        [JsonPropertyName("updated_at")]
        public string? Updated_at { get; set; }

        [JsonPropertyName("requested_for_id")]
        public long? RequestedForId { get; set; }

        [JsonPropertyName("to_emails")]
        public object? ToEmails { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("description_text")]
        public string? Description_text { get; set; }

        [JsonPropertyName("workspace_id")]
        public int? Workspace_id { get; set; }

        [JsonPropertyName("tasks_dependency_type")]
        public int? Tasks_dependency_type { get; set; }

        [JsonPropertyName("sla_policy_id")]
        public long? Sla_policy_id { get; set; }

        [JsonPropertyName("impact")]
        public int? Impact { get; set; }

        [JsonPropertyName("urgency")]
        public int? Urgency { get; set; }

        [JsonPropertyName("bcc_emails")]
        public object? Bcc_emails { get; set; }

        [JsonPropertyName("applied_business_hours")]
        public long? Applied_business_hours { get; set; }

        [JsonPropertyName("created_within_business_hours")]
        public bool? Created_within_business_hours { get; set; }

        [JsonPropertyName("resolution_notes")]
        public object? Resolution_notes { get; set; }

        [JsonPropertyName("resolution_notes_html")]
        public object? Resolution_notes_html { get; set; }

        [JsonPropertyName("attachments")]
        public List<FreshServiceAttachment>? Attachments { get; set; }

        [JsonPropertyName("custom_fields")]
        public CustomFields? CustomFields { get; set; }

        [JsonPropertyName("conversations")]
        public List<FreshServiceConversation>? Conversations { get; set; }

        [JsonPropertyName("requester")]
        public Requester? Requester { get; set; }

        public string? TicketId => $"{Id}";

        public string? TicketNumber
        {
            get
            {
                if (Type == "Service Request")
                {
                    return $"SR-{Id}";
                }

                return $"INC-{Id}";

            }
        }

        
        public string? TicketCreatedBy => null;

        public string? TicketAffectedUserId => $"{Requester_id}";

        public string? TicketAffectedUserEmail => Requester?.Email ?? "";

        public string? TicketAssignedUser
        {
            get
            {
                if (Responder != null)
                {
                    return Responder.Email;
                }
                return null;
            }
        }

        public string? TicketShortDescription => Subject;

        public string? TicketFullDescription => Description ?? Description_text;

        public DateTime? TicketCreationDate
        {
            get
            {
                if (Created_at != null && DateTime.TryParse(Created_at, out DateTime created_))
                {
                    return created_;
                }
                return null;
            }
        }

        public IEnumerable<IHelpDeskComment> Comments
        {
            get
            {
                if (Conversations == null)
                {
                    return Enumerable.Empty<IHelpDeskComment>();
                }

                return Conversations;
            }
        }

        public HelpDeskSeriousness? HelpDeskImpact
        {
            get
            {
                HelpDeskSeriousness impact = Impact switch
                {
                    3 => HelpDeskSeriousness.Major,
                    2 => HelpDeskSeriousness.Moderate,
                    1 => Type == "Service Request" ? HelpDeskSeriousness.Request : HelpDeskSeriousness.Minor,
                    _ => HelpDeskSeriousness.Request,
                };

                return impact;
            }
        }


        public HelpDeskSeriousness? HelpDeskUrgency
        {
            get
            {
                HelpDeskSeriousness impact = Urgency switch
                {
                    3 => HelpDeskSeriousness.Major,
                    2 => HelpDeskSeriousness.Moderate,
                    1 => Type == "Service Request" ? HelpDeskSeriousness.Request : HelpDeskSeriousness.Minor,
                    _ => HelpDeskSeriousness.Request,
                };
                return impact;
            }
        }
    }

    public class CustomFields
    {
        [JsonPropertyName("major_incident_type")]
        public object? Major_incident_type { get; set; }

        [JsonPropertyName("need_by_date")]
        public object? Need_by_date { get; set; }

        [JsonPropertyName("type_of_outage")]
        public object? Type_of_outage { get; set; }

        [JsonPropertyName("user_if_different_from_requester")]
        public object? User_if_different_from_requester { get; set; }

        [JsonPropertyName("business_impact")]
        public object? Business_impact { get; set; }

        [JsonPropertyName("impacted_locations")]
        public object? Impacted_locations { get; set; }

        [JsonPropertyName("no_of_customers_impacted")]
        public object? No_of_customers_impacted { get; set; }

        [JsonPropertyName("dvid_if_applicable")]
        public object? Dvid_if_applicable { get; set; }

        [JsonPropertyName("hoist_incident")]
        public string? Hoist_incident { get; set; }
    }
}


