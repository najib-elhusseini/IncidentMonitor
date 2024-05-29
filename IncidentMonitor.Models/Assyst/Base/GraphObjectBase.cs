using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.Assyst
{
    public abstract class GraphObjectBase
    {

        [JsonPropertyName("pseudoId")]
        public int? PseudoId { get; set; }

        [JsonPropertyName("resolvingParameters")]
        public ResolvingParameterDto? ResolvingParameters { get; set; }

    }
}
