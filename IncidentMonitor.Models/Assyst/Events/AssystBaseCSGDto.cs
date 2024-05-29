using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.Assyst
{


    public class AssystBaseCSGDto : AssystBaseDto
    {

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="csg"/>
         */


        [JsonPropertyName("csgActive")]
        public bool? CsgActive { get; set; }


        [JsonPropertyName("csgEnabled")]
        public bool? CsgEnabled { get; set; }


        [JsonPropertyName("csgId")]
        public int? CsgId { get; set; }


        [JsonPropertyName("csgShortCode")]
        public string? CsgShortCode { get; set; }

    }

}
