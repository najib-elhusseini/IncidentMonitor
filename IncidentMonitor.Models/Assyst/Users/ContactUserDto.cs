using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.Assyst.Users
{


    public class ContactUserDto : UserDto
    {

        [JsonPropertyName("address1")]
        public string? Address1 { get; set; }

        [JsonPropertyName("address2")]
        public string? Address2 { get; set; }


        [JsonPropertyName("address3")]
        public string? Address3 { get; set; }


        [JsonPropertyName("anetLicence")]
        public bool? AnetLicence { get; set; }


        [JsonPropertyName("anetLicense")]
        public bool? AnetLicense { get; set; }


        [JsonPropertyName("assystUserAlias")]
        public AssystUserDto? AssystUserAlias { get; set; }


        [JsonPropertyName("assystUserAliasId")]
        public int? AssystUserAliasId { get; set; }


        [JsonPropertyName("assystUserAliasShortCode")]
        public string? AssystUserAliasShortCode { get; set; }


        [JsonPropertyName("contactBleep")]
        public bool? ContactBleep { get; set; }


        [JsonPropertyName("contactFax")]
        public bool? ContactFax { get; set; }


        [JsonPropertyName("contactMail")]
        public bool? ContactMail { get; set; }


        [JsonPropertyName("contactPageNo")]
        public string? ContactPageNo { get; set; }


        [JsonPropertyName("contactPrint")]
        public bool? ContactPrint { get; set; }


        [JsonPropertyName("contactTele")]
        public bool? ContactTele { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="costCentre"/>
         */


        [JsonPropertyName("costCentreId")]
        public int? CostCentreId { get; set; }


        [JsonPropertyName("country")]
        public string? Country { get; set; }


        /// <summary>
        /// 
        /// Data Type : slaDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:deprecated="true" axios:replacementField="sla" axios:resourcePath="/serviceLevelAgreements" minOccurs="0" name="defaultSla" type="slaDto"/>
        /// </summary>

        [JsonPropertyName("defaultSla")]
        public object? DefaultSla { get; set; }


        [JsonPropertyName("defaultSlaId")]
        public int? DefaultSlaId { get; set; }


        /// <summary>
        /// 
        /// Data Type : delegationLinkDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/delegationLinks" maxOccurs="unbounded" minOccurs="0" name="delegateUsers" nillable="true" type="delegationLinkDto"/>
        /// </summary>

        [JsonPropertyName("delegateUsers")]
        public object? DelegateUsers { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="department"/>
         */

        [JsonPropertyName("department")]
        public DepartmentDto? Department { get; set; }


        [JsonPropertyName("departmentId")]
        public int? DepartmentId { get; set; }


        /// <summary>
        /// 
        /// Data Type : assystUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assystUsers" minOccurs="0" name="equivalentUser" type="assystUserDto"/>
        /// </summary>

        [JsonPropertyName("equivalentUser")]
        public object? EquivalentUser { get; set; }


        [JsonPropertyName("equivalentUserId")]
        public int? EquivalentUserId { get; set; }


        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }


        [JsonPropertyName("homeEmailAddress")]
        public string? HomeEmailAddress { get; set; }


        [JsonPropertyName("internalId")]
        public string? InternalId { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="licenceRole"/>
         */


        [JsonPropertyName("licenceRoleId")]
        public int? LicenceRoleId { get; set; }


        /// <summary>
        /// 
        /// Data Type : contactUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/contactUsers" minOccurs="0" name="manager" type="contactUserDto"/>
        /// </summary>

        [JsonPropertyName("manager")]
        public object? Manager { get; set; }


        [JsonPropertyName("managerId")]
        public int? ManagerId { get; set; }


        /// <summary>
        /// 
        /// Data Type : messageReadDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/messageReads" maxOccurs="unbounded" minOccurs="0" name="messages" nillable="true" type="messageReadDto"/>
        /// </summary>

        [JsonPropertyName("messages")]
        public object? Messages { get; set; }


        [JsonPropertyName("middleName")]
        public string? MiddleName { get; set; }


        [JsonPropertyName("orderApprovalThreshold")]
        public int? OrderApprovalThreshold { get; set; }


        /// <summary>
        /// 
        /// Data Type : contactUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/contactUsers" minOccurs="0" name="organisationalManager" type="contactUserDto"/>
        /// </summary>

        [JsonPropertyName("organisationalManager")]
        public object? OrganisationalManager { get; set; }


        [JsonPropertyName("organisationalManagerId")]
        public int? OrganisationalManagerId { get; set; }


        [JsonPropertyName("personalMobile")]
        public string? PersonalMobile { get; set; }


        [JsonPropertyName("postCode")]
        public string? PostCode { get; set; }


        [JsonPropertyName("postTown")]
        public string? PostTown { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="room"/>
         */


        [JsonPropertyName("roomId")]
        public int? RoomId { get; set; }


        [JsonPropertyName("salutation")]
        public string? Salutation { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="sla"/>
         */


        [JsonPropertyName("slaId")]
        public int? SlaId { get; set; }


        [JsonPropertyName("surname")]
        public string? Surname { get; set; }


        [JsonPropertyName("title")]
        public string? Title { get; set; }


        [JsonPropertyName("uniqueReference")]
        public string? UniqueReference { get; set; }


        /// <summary>
        /// 
        /// Data Type : assystUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assystUsers" minOccurs="0" name="userAlias" type="assystUserDto"/>
        /// </summary>

        [JsonPropertyName("userAlias")]
        public object? UserAlias { get; set; }


        [JsonPropertyName("userAliasId")]
        public int? UserAliasId { get; set; }


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
                if (this.UserImageData == null) return null;
                return Encoding.UTF8.GetBytes(UserImageData);
            }
        }


        /// <summary>
        /// 
        /// Data Type : userItemDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/userItems" maxOccurs="unbounded" minOccurs="0" name="userItems" nillable="true" type="userItemDto"/>
        /// </summary>

        [JsonPropertyName("userItems")]
        public object? UserItems { get; set; }


        /// <summary>
        /// 
        /// Data Type : contactUserQueryProfileDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/contactUserQueryProfiles" maxOccurs="unbounded" minOccurs="0" name="userProfileGroups" nillable="true" type="contactUserQueryProfileDto"/>
        /// </summary>

        [JsonPropertyName("userProfileGroups")]
        public object? UserProfileGroups { get; set; }


        /// <summary>
        /// 
        /// Data Type : userSkillDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/userSkills" maxOccurs="unbounded" minOccurs="0" name="userSkills" nillable="true" type="userSkillDto"/>
        /// </summary>

        [JsonPropertyName("userSkills")]
        public object? UserSkills { get; set; }

        [JsonPropertyName("usrFlag1")]
        public string? UsrFlag1 { get; set; }


        [JsonPropertyName("usrFlag2")]
        public string? UsrFlag2 { get; set; }


        [JsonPropertyName("workMobile")]
        public string? WorkMobile { get; set; }

    }

}
