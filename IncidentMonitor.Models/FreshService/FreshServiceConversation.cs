using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.FreshService
{
    public class FreshServiceConversation : IHelpDeskComment
    {
        [JsonPropertyName("id")]
        public ulong? Id { get; set; }

        [JsonPropertyName("user_id")]
        public ulong? User_id { get; set; }

        [JsonPropertyName("to_emails")]
        public List<string>? To_emails { get; set; }

        [JsonPropertyName("body")]
        public string? Body { get; set; }

        [JsonPropertyName("body_text")]
        public string? Body_text { get; set; }

        [JsonPropertyName("ticket_id")]
        public ulong? Ticket_id { get; set; }

        [JsonPropertyName("created_at")]
        public string? Created_at { get; set; }

        [JsonPropertyName("updated_at")]
        public string? Updated_at { get; set; }

        [JsonPropertyName("incoming")]
        public bool? Incoming { get; set; }

        [JsonPropertyName("private")]
        public bool? Private { get; set; }

        [JsonPropertyName("support_email")]
        public object? Support_email { get; set; }

        [JsonPropertyName("source")]
        public int? Source { get; set; }

        [JsonPropertyName("from_email")]
        public object? From_email { get; set; }

        [JsonPropertyName("cc_emails")]
        public object? Cc_emails { get; set; }

        [JsonPropertyName("bcc_emails")]
        public object? Bcc_emails { get; set; }

        [JsonPropertyName("attachments")]
        public object? Attachments { get; set; }

        public string CommentId => $"{Id}";

        public DateTime? CreationDate
        {
            get
            {
                if (Created_at != null && DateTime.TryParse(Created_at, out DateTime result))
                {
                    return result;
                }

                return null;
            }
        }

        public string? CreatedBy => $"{User_id}";

        public string? Title
        {
            get
            {
                var noteType = Private == true ? "Private" : "Public";
                return $"{noteType} Note";
            }
        }

        public string? PlainTextDescription => Body_text;

        public string? RichTextDescription => Body;
    }
}
