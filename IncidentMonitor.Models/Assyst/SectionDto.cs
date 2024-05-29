using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.Assyst
{


    public class SectionDto : AssystBaseCSGDto
    {


        [JsonPropertyName("address1")]
        public string? Address1 { get; set; }


        [JsonPropertyName("address2")]
        public string? Address2 { get; set; }


        [JsonPropertyName("address3")]
        public string? Address3 { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="branch"/>
         */


        [JsonPropertyName("branchId")]
        public int? BranchId { get; set; }


        /// <summary>
        /// 
        /// Data Type : contactUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/contactUsers" maxOccurs="unbounded" minOccurs="0" name="contacts" nillable="true" type="contactUserDto"/>
        /// </summary>

        [JsonPropertyName("contacts")]
        public object? Contacts { get; set; }


        [JsonPropertyName("country")]
        public string? Country { get; set; }


        /// <summary>
        /// 
        /// Data Type : sectionRelationshipDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" maxOccurs="unbounded" minOccurs="0" name="customers" nillable="true" type="sectionRelationshipDto"/>
        /// </summary>

        [JsonPropertyName("customers")]
        public object? Customers { get; set; }


        /// <summary>
        /// 
        /// Data Type : departmentDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/departments" minOccurs="0" name="defaultDepartment" type="departmentDto"/>
        /// </summary>

        [JsonPropertyName("defaultDepartment")]
        public object? DefaultDepartment { get; set; }


        /// <summary>
        /// 
        /// Data Type : slaDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceLevelAgreements" minOccurs="0" name="defaultSla" type="slaDto"/>
        /// </summary>

        [JsonPropertyName("defaultSla")]
        public object? DefaultSla { get; set; }


        [JsonPropertyName("defaultSlaId")]
        public int? DefaultSlaId { get; set; }


        /// <summary>
        /// 
        /// Data Type : supplierDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/suppliers" minOccurs="0" name="dfltInsurer" type="supplierDto"/>
        /// </summary>

        [JsonPropertyName("dfltInsurer")]
        public object? DfltInsurer { get; set; }


        [JsonPropertyName("dfltInsurerId")]
        public int? DfltInsurerId { get; set; }


        [JsonPropertyName("fax")]
        public string? Fax { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="holidayPlan"/>
         */


        [JsonPropertyName("holidayPlanId")]
        public int? HolidayPlanId { get; set; }


        [JsonPropertyName("licenceCount")]
        public int? LicenceCount { get; set; }


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
        /// Data Type : sectionRelationshipDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" maxOccurs="unbounded" minOccurs="0" name="partners" nillable="true" type="sectionRelationshipDto"/>
        /// </summary>

        [JsonPropertyName("partners")]
        public object? Partners { get; set; }


        [JsonPropertyName("postCode")]
        public string? PostCode { get; set; }


        [JsonPropertyName("postTown")]
        public string? PostTown { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="sectionClass"/>
         */


        [JsonPropertyName("sectionClassId")]
        public int? SectionClassId { get; set; }


        /// <summary>
        /// 
        /// Data Type : sectionContactDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/sectionContacts" maxOccurs="unbounded" minOccurs="0" name="sectionContacts" nillable="true" type="sectionContactDto"/>
        /// </summary>

        [JsonPropertyName("sectionContacts")]
        public object? SectionContacts { get; set; }


        [JsonPropertyName("telephone")]
        public string? Telephone { get; set; }


        [JsonPropertyName("telex")]
        public string? Telex { get; set; }


        [JsonPropertyName("translationModifyDate")]
        public DateTime? TranslationModifyDate { get; set; }


        /// <summary>
        /// 
        /// Data Type : sectionDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/sections" maxOccurs="unbounded" minOccurs="0" name="translations" nillable="true" type="sectionDto"/>
        /// </summary>

        [JsonPropertyName("translations")]
        public object? Translations { get; set; }

    }

}
