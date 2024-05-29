using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.Assyst
{


    public class DepartmentDto : AssystBaseCSGDto
    {
        [JsonPropertyName("address1")]
        public string? Address1 { get; set; }


        [JsonPropertyName("address2")]
        public string? Address2 { get; set; }


        [JsonPropertyName("address3")]
        public string? Address3 { get; set; }


        /// <summary>
        /// 
        /// Data Type : departmentContactDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/departmentContacts" maxOccurs="unbounded" minOccurs="0" name="contacts" nillable="true" type="departmentContactDto"/>
        /// </summary>

        [JsonPropertyName("contacts")]
        public object? Contacts { get; set; }


        [JsonPropertyName("country")]
        public string? Country { get; set; }


        [JsonPropertyName("defaultDepartment")]
        public bool? DefaultDepartment { get; set; }


        /// <summary>
        /// 
        /// Data Type : departmentNameDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/departmentNames" minOccurs="0" name="departmentDepartmentName" type="departmentNameDto"/>
        /// </summary>

        [JsonPropertyName("departmentDepartmentName")]
        public object? DepartmentDepartmentName { get; set; }


        [JsonPropertyName("departmentDepartmentNameId")]
        public int? DepartmentDepartmentNameId { get; set; }


        [JsonPropertyName("departmentDepartmentShortCode")]
        public string? DepartmentDepartmentShortCode { get; set; }


        [JsonPropertyName("departmentName")]
        public string? DepartmentName { get; set; }


        [JsonPropertyName("departmentNameName")]
        public string? DepartmentNameName { get; set; }


        [JsonPropertyName("departmentShortCode")]
        public string? DepartmentShortCode { get; set; }


        [JsonPropertyName("fax")]
        public string? Fax { get; set; }


        [JsonPropertyName("incClearanceDays")]
        public int? IncClearanceDays { get; set; }


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


        [JsonPropertyName("postCode")]
        public string? PostCode { get; set; }


        [JsonPropertyName("postTown")]
        public string? PostTown { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="section"/>
         */

        [JsonPropertyName("section")]
        public SectionDto? Section { get; set; }

        [JsonPropertyName("sectionDepartmentName")]
        public string? SectionDepartmentName { get; set; }


        [JsonPropertyName("sectionDepartmentShortCode")]
        public string? SectionDepartmentShortCode { get; set; }


        [JsonPropertyName("sectionId")]
        public int? SectionId { get; set; }


        /// <summary>
        /// 
        /// Data Type : departmentSlaDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/departmentSlas" maxOccurs="unbounded" minOccurs="0" name="slas" nillable="true" type="departmentSlaDto"/>
        /// </summary>

        [JsonPropertyName("slas")]
        public object? Slas { get; set; }


        [JsonPropertyName("telephone")]
        public string? Telephone { get; set; }


        [JsonPropertyName("telex")]
        public string? Telex { get; set; }

        [JsonPropertyName("sectionName")]
        public string? SectionName
        {
            get
            {
                if (Section == null)
                {
                    return string.Empty;
                }
                return Section.Name;
            }
        }


    }

}
