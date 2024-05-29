using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models
{
    public interface IHelpDeskComment
    {
        string CommentId { get; }

        DateTime? CreationDate { get; }

        string? CreatedBy { get; }

        string? Title { get; }

        string? PlainTextDescription { get; }

        string? RichTextDescription { get; }

        public GenericHelpDeskComment GenericHelpDeskComment => new(this);

        public string Serialize()
        {
            var payload = new
            {
                commentId = CommentId,
                creationDate = CreationDate,
                title = Title,
                plainTextDescription = PlainTextDescription,
                richTextDescription = RichTextDescription
            };
            var options = new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            };


            var serialized = JsonSerializer.Serialize(payload, options);
            return serialized;

        }
    }
}
