using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.Assyst
{

    public class ResolvingParameterDto
    {

        [JsonPropertyName("parameterName")]
        public string? ParameterName { get; set; }


        [JsonPropertyName("parameterValue")]
        public string? ParameterValue { get; set; }


        [JsonPropertyName("parameterValues")]
        public string? ParameterValues { get; set; }

    }

}
