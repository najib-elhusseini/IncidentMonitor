using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace IncidentMonitor.Models
{
    public class RemedyForceSetting : IDatabaseObject<int>
    {
        [PrimaryKey]
        [AutoIncrement]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("tokenEndPoint")]
        public string? TokenEndpoint { get; set; }

        [JsonPropertyName("instanceUrl")]
        public string? InstanceUrl { get; set; }
        
        [JsonPropertyName("token")]
        public string? Token { get; set; }

        [JsonPropertyName("grantType")]
        public string GrantType { get; set; } = "password";

        [JsonPropertyName("clientId")]
        public string? ClientId { get; set; }

        [JsonPropertyName("clientSecret")]
        public string? ClientSecret { get; set; }

        [JsonPropertyName("userName")]
        public string? UserName { get; set; }

        [JsonPropertyName("password")]
        public string? Password { get; set; }

        [JsonPropertyName("accessToken")]
        public string? AccessToken { get; set; }


        public string GetCompletePassword() => $"{Password}{AccessToken}";


        public bool ValidateSettings()
        {
            if (TokenEndpoint == null)
            {
                return false;
            }

            if (InstanceUrl == null)
            {
                return false;
            }

            if (ClientId == null ||
                ClientSecret == null ||
                UserName == null ||
                Password == null
                )
            {
                return false;
            }

            return true;
        }
    }
}
