using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.FreshService
{
    public class FreshServiceAttachment
    {
        [JsonPropertyName("id")]
        public ulong? Id { get; set; }

        [JsonPropertyName("attachment_url")]
        public string? Attachment_url { get; set; }

        [JsonPropertyName("content_type")]
        public string? Content_type { get; set; }

        [JsonPropertyName("created_at")]
        public string? Created_at { get; set; }



        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("size")]
        public int? Size { get; set; }

        [JsonPropertyName("updated_at")]
        public string? Updated_at { get; set; }
    }
}
