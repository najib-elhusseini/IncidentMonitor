using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.Assyst
{


    public class SeriousnessDto : AssystBaseCSGDto
    {


        [JsonPropertyName("bmp")]
        public string? Bmp { get; set; }


        [JsonPropertyName("change")]
        public bool? Change { get; set; }


        [JsonPropertyName("incident")]
        public bool? Incident { get; set; }


        [JsonPropertyName("order")]
        public bool? Order { get; set; }


        [JsonPropertyName("problem")]
        public bool? Problem { get; set; }


        [JsonPropertyName("serviceRequest")]
        public bool? ServiceRequest { get; set; }


        [JsonPropertyName("sortOrder")]
        public int? SortOrder { get; set; }


        [JsonPropertyName("task")]
        public bool? Task { get; set; }

    }

}
