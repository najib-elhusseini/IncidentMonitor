using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.ServiceNow
{
    public class ServiceNowActivity : ServiceNowObject, IHelpDeskComment
    {
        [JsonPropertyName("sys_created_on_adjusted")]
        public string? SysCreatedOnAdjusted { get; set; }


        [JsonPropertyName("login_name")]
        public string? LoginName { get; set; }

        [JsonPropertyName("user_sys_id")]
        public string? UserSysId { get; set; }

        [JsonPropertyName("initials")]
        public string? Initials { get; set; }

        [JsonPropertyName("sys_created_on")]
        public string? SysCreatedOn { get; set; }

        [JsonPropertyName("contains_code")]
        public string? ContainsCode { get; set; }

        [JsonPropertyName("field_label")]
        public string? FieldLabel { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("value")]
        public string? Value { get; set; }

        [JsonPropertyName("element")]
        public string? Element { get; set; }

        public string CommentId => SysId;

        public DateTime? CreationDate
        {
            get
            {
                if (SysCreatedOn == null) return null;
                if (DateTime.TryParse(SysCreatedOn, out DateTime dt))
                {
                    return dt;
                }
                return null;

            }
        }

        public string? CreatedBy => null;

        public string? Title => FieldLabel;

        public string? PlainTextDescription => null;

        public string? RichTextDescription => Value;
    }

    public class ServiceNowActivitySearch
    {
        public class ServiceNowActivitiesPresenter : ServiceNowObject
        {
            [JsonPropertyName("entries")]
            public List<ServiceNowActivity> Entries { get; set; }
        }

        [JsonPropertyName("result")]
        public ServiceNowActivitiesPresenter Result { get; set; }
    }

}
