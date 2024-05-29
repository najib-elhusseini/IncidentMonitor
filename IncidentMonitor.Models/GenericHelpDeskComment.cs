using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models
{
    public class GenericHelpDeskComment : IHelpDeskComment
    {
        public GenericHelpDeskComment()
        {

        }

        public GenericHelpDeskComment(IHelpDeskComment other)
        {
            CommentId = other.CommentId;
            CreationDate = other.CreationDate;
            CreatedBy = other.CreatedBy;
            Title = other.Title;
            PlainTextDescription = other.PlainTextDescription;
            RichTextDescription = other.RichTextDescription;
        }

        [JsonPropertyName("commentId")]
        public string CommentId { get; set; } = string.Empty;

        [JsonPropertyName("creationDate")]
        public DateTime? CreationDate { get; set; }

        [JsonPropertyName("createdBy")]
        public string? CreatedBy { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("plainTextDescription")]
        public string? PlainTextDescription { get; set; }

        [JsonPropertyName("richTextDescription")]
        public string? RichTextDescription { get; set; }
    }
}
