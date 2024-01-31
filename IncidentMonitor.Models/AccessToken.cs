using System.Text.Json.Serialization;

namespace IncidentMonitor.Models
{
    public class AccessToken
    {
        [JsonPropertyName("access_token")]
        public string Token { get; set; }

        [JsonPropertyName("instance_url")]
        public string InstanceUrl { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("token_type")]
        public string token_type { get; set; }

        [JsonPropertyName("issued_at")]
        public string IssuedAt { get; set; }

        [JsonPropertyName("signature")]
        public string Signature { get; set; }
    }
}