using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.Assyst
{


    public class PrivilegeUserDto : AssystBaseDto
    {

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="assystUser"/>
         */


        [JsonPropertyName("assystUserId")]
        public int? AssystUserId { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="contactUser"/>
         */

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="privilegeGroup"/>
         */
        [JsonPropertyName("privilegeGroup")]
        public PrivilegeGroupDto? PrivilegeGroup { get; set; }



        [JsonPropertyName("privilegeGroupId")]
        public int? PrivilegeGroupId { get; set; }

    }

}
