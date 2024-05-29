using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.Assyst
{


    public class UserDto : AssystBaseCSGDto
    {


        /// <summary>
        /// 
        /// Data Type : docketDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="docket" type="docketDto"/>
        /// </summary>

        [JsonPropertyName("docket")]
        public object? Docket { get; set; }


        [JsonPropertyName("docketId")]
        public int? DocketId { get; set; }


        [JsonPropertyName("email")]
        public string? Email { get; set; }


        [JsonPropertyName("emailAddress")]
        public string? EmailAddress { get; set; }


        [JsonPropertyName("homeTele")]
        public string? HomeTele { get; set; }


        [JsonPropertyName("homeTelephone")]
        public string? HomeTelephone { get; set; }


        [JsonPropertyName("lastLocationDate")]
        public DateTime? LastLocationDate { get; set; }


        [JsonPropertyName("latitude")]
        public double? Latitude { get; set; }


        [JsonPropertyName("loginName")]
        public string? LoginName { get; set; }


        [JsonPropertyName("longitude")]
        public double? Longitude { get; set; }


        [JsonPropertyName("officeExtension")]
        public string? OfficeExtension { get; set; }


        [JsonPropertyName("officeTelephone")]
        public string? OfficeTelephone { get; set; }


        [JsonPropertyName("officeTelephoneExtension")]
        public string? OfficeTelephoneExtension { get; set; }


        [JsonPropertyName("password")]
        public string? Password { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="person"/>
         */


        /// <summary>
        /// 
        /// Data Type : userRoleDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/userRoles" minOccurs="0" name="role" type="userRoleDto"/>
        /// </summary>

        [JsonPropertyName("role")]
        public object? Role { get; set; }


        [JsonPropertyName("roleId")]
        public int? RoleId { get; set; }


        [JsonPropertyName("staffNumber")]
        public string? StaffNumber { get; set; }


        [JsonPropertyName("typeOfUser")]
        public int? TypeOfUser { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="userGroup"/>
         */


        [JsonPropertyName("userGroupId")]
        public int? UserGroupId { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="userImage"/>
         */


        [JsonPropertyName("userImageId")]
        public int? UserImageId { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="userRole"/>
         */


        [JsonPropertyName("userRoleId")]
        public int? UserRoleId { get; set; }

    }

}
