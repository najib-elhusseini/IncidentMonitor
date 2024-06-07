using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.Assyst
{
    public class DurationDto
    {
        [JsonPropertyName("value")]
        public double? Value { get; set; }

        [JsonPropertyName("isSetToNull")]
        public bool? IsSetToNull { get; set; }

        [JsonPropertyName("minutesValue")]
        public double? MinutesValue
        {
            get
            {
                return Value / 60000;
            }
        }
    }
}
