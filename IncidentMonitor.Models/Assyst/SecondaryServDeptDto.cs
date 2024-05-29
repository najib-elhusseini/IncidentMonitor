using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.Assyst
{


    public class SecondaryServDeptDto : AssystBaseDto
    {        

        [JsonPropertyName("assystUser")]
        public AssystUserDto? AssystUser { get; set; }

        [JsonPropertyName("assystUserId")]
        public int? AssystUserId { get; set; }


        [JsonPropertyName("manageSvd")]
        public bool? ManageSvd { get; set; }

        [JsonPropertyName("servDept")]
        public ServDeptDto? ServDept { get; set; }


        [JsonPropertyName("servDeptId")]
        public int? ServDeptId { get; set; }

    }

}
