using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IncidentMonitor.Models
{
    public class RemedyForceSetting:IDatabaseObject<int>
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        public string? TokenEndpoint { get; set; }

        public string? InstanceUrl { get; set; }

        public string? Token { get; set; }

        public string GrantType { get; set; } = "password";

        public string? ClientId { get; set; }

        public string? ClientSecret { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; }

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
