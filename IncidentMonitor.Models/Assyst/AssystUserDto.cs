using IncidentMonitor.Models.Assyst.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.Assyst
{


    public class AssystUserDto : UserDto
    {



        /// <summary>
        /// 
        /// Data Type : assignableServDeptDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assignableServiceDepartments" maxOccurs="unbounded" minOccurs="0" name="assignableServDeptAssociations" nillable="true" type="assignableServDeptDto"/>
        /// </summary>

        [JsonPropertyName("assignableServDeptAssociations")]
        public object? AssignableServDeptAssociations { get; set; }


        /// <summary>
        /// 
        /// Data Type : servDeptDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceDepartments" maxOccurs="unbounded" minOccurs="0" name="assignableServDepts" nillable="true" type="servDeptDto"/>
        /// </summary>

        [JsonPropertyName("assignableServDepts")]
        public object? AssignableServDepts { get; set; }


        /// <summary>
        /// 
        /// Data Type : availabilityDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" maxOccurs="unbounded" minOccurs="0" name="availability" nillable="true" type="availabilityDto"/>
        /// </summary>

        [JsonPropertyName("availability")]
        public object? Availability { get; set; }


        /// <summary>
        /// 
        /// Data Type : contactUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/contactUsers" maxOccurs="unbounded" minOccurs="0" name="contactUsers" nillable="true" type="contactUserDto"/>
        /// </summary>

        [JsonPropertyName("contactUsers")]
        public object? ContactUsers { get; set; }


        [JsonPropertyName("csgsNotVisibleToPrincipal")]
        public bool? CsgsNotVisibleToPrincipal { get; set; }


        /// <summary>
        /// 
        /// Data Type : assystUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assystUsers" minOccurs="0" name="customAlias" type="assystUserDto"/>
        /// </summary>

        [JsonPropertyName("customAlias")]
        public object? CustomAlias { get; set; }


        [JsonPropertyName("customAliasId")]
        public int? CustomAliasId { get; set; }


        /// <summary>
        /// 
        /// Data Type : csgMembershipDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/csgMemberships" maxOccurs="unbounded" minOccurs="0" name="customerServiceGroupMemberships" nillable="true" type="csgMembershipDto"/>
        /// </summary>

        [JsonPropertyName("customerServiceGroupMemberships")]
        public IEnumerable<CsgMembershipDto>? CustomerServiceGroupMemberships { get; set; }


        [JsonPropertyName("docketBox")]
        public int? DocketBox { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="homepage"/>
         */


        [JsonPropertyName("homepageId")]
        public int? HomepageId { get; set; }


        [JsonPropertyName("isReportWriter")]
        public bool? IsReportWriter { get; set; }


        [JsonPropertyName("mailSystem")]
        public int? MailSystem { get; set; }


        /// <summary>
        /// 
        /// Data Type : mailSystemTypesEnum
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="mailSystemEnum" type="mailSystemTypesEnum"/>
        /// </summary>

        [JsonPropertyName("mailSystemEnum")]
        public object? MailSystemEnum { get; set; }


        [JsonPropertyName("manageOwnSVD")]
        public bool? ManageOwnSVD { get; set; }


        /// <summary>
        /// 
        /// Data Type : servDeptDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceDepartments" maxOccurs="unbounded" minOccurs="0" name="managedServiceDepartments" nillable="true" type="servDeptDto"/>
        /// </summary>

        [JsonPropertyName("managedServiceDepartments")]
        public object? ManagedServiceDepartments { get; set; }


        /// <summary>
        /// 
        /// Data Type : assystUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assystUsers" minOccurs="0" name="manager" type="assystUserDto"/>
        /// </summary>

        [JsonPropertyName("manager")]
        public object? Manager { get; set; }


        [JsonPropertyName("managerId")]
        public int? ManagerId { get; set; }


        [JsonPropertyName("orderApprovalThreshold")]
        public int? OrderApprovalThreshold { get; set; }


        /// <summary>
        /// 
        /// Data Type : assystUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assystUsers" minOccurs="0" name="organisationalManager" type="assystUserDto"/>
        /// </summary>

        [JsonPropertyName("organisationalManager")]
        public object? OrganisationalManager { get; set; }


        [JsonPropertyName("organisationalManagerId")]
        public int? OrganisationalManagerId { get; set; }


        [JsonPropertyName("pagerCode")]
        public string? PagerCode { get; set; }


        [JsonPropertyName("pagerNumber")]
        public string? PagerNumber { get; set; }


        /// <summary>
        /// 
        /// Data Type : assystUserPermissionsDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="permissions" type="assystUserPermissionsDto"/>
        /// </summary>

        [JsonPropertyName("permissions")]
        public object? Permissions { get; set; }


        [JsonPropertyName("printAddress")]
        public string? PrintAddress { get; set; }


        /// <summary>
        /// 
        /// Data Type : privilegeUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/privilegeUsers" maxOccurs="unbounded" minOccurs="0" name="privilegeGroupMemberships" nillable="true" type="privilegeUserDto"/>
        /// </summary>

        [JsonPropertyName("privilegeGroupMemberships")]
        public List<PrivilegeUserDto>? PrivilegeGroupMemberships { get; set; }


        /// <summary>
        /// 
        /// Data Type : secondaryServDeptDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/secondaryServiceDepartments" maxOccurs="unbounded" minOccurs="0" name="secondaryServDeptAssociations" nillable="true" type="secondaryServDeptDto"/>
        /// </summary>
        /// 
        [JsonPropertyName("secondaryServDeptAssociations")]
        public List<SecondaryServDeptDto>? SecondaryServDeptAssociations { get; set; }




        [JsonPropertyName("secondaryServDepts")]
        public List<ServDeptDto>? SecondaryServDepts { get; set; }


        /// <summary>
        /// 
        /// Data Type : servDeptDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceDepartments" minOccurs="0" name="servDept" type="servDeptDto"/>
        /// </summary>

        [JsonPropertyName("servDept")]
        public ServDeptDto? ServDept { get; set; }


        [JsonPropertyName("servDeptId")]
        public int? ServDeptId { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="shiftDetails"/>
         */


        [JsonPropertyName("shiftDetailsId")]
        public int? ShiftDetailsId { get; set; }


        [JsonPropertyName("timeZone")]
        public int? TimeZone { get; set; }


        [JsonPropertyName("timeZoneEnabled")]
        public bool? TimeZoneEnabled { get; set; }


        [JsonPropertyName("userAliasOnly")]
        public bool? UserAliasOnly { get; set; }


        [JsonPropertyName("userContact")]
        public string? UserContact { get; set; }


        /// <summary>
        /// Convenience property for setting the User Image. This is the same as setting userImage.imgBlob. Both should not be set together, but userImage.imgBlob will take precedence if this is done. Takes a base64 encoded image.
        /// </summary>

        [JsonPropertyName("userImageData")]
        public string? UserImageData { get; set; }

        [JsonPropertyName("userImageDataBytes")]
        public byte[]? UserImageDataBytes
        {
            get
            {
                if (string.IsNullOrEmpty(UserImageData))
                {
                    return null;
                }
                return Encoding.UTF8.GetBytes(UserImageData);

            }
        }

    }

}
