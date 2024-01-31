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
    public class EmailConfiguration : IDatabaseObject<int>
    {
        [PrimaryKey]
        [AutoIncrement]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("userName")]
        public string? UserName { get; set; }

        [JsonPropertyName("password")]
        public string? Password { get; set; }

        [JsonPropertyName("smtpClientName")]
        public string? SmtpClientName { get; set; }

        [JsonPropertyName("smtpPort")]
        public int? SmtpPort { get; set; }

        //[JsonPropertyName("sslSmtpPort")]
        //public int? SslSmtpPort { get; set; }

        [JsonPropertyName("enableSsl")]
        public bool EnableSsl { get; set; }


        public bool CheckValidity()
        {
            return SmtpClientName != null && SmtpPort != null && UserName != null && Password != null;
        }
    }
}

