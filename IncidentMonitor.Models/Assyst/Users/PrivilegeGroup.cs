using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.Assyst
{


    public class PrivilegeGroupDto : AssystBaseCSGDto
    {

        /// <summary>
        /// 
        /// Data Type : activityCategoryPrivDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/privilegeGroupActivityCategories" maxOccurs="unbounded" minOccurs="0" name="activityCategoryPrivileges" nillable="true" type="activityCategoryPrivDto"/>
        /// </summary>

        [JsonPropertyName("activityCategoryPrivileges")]
        public object? ActivityCategoryPrivileges { get; set; }


        [JsonPropertyName("allActivityCategoryPrivs")]
        public bool? AllActivityCategoryPrivs { get; set; }


        [JsonPropertyName("allItemPrivs")]
        public bool? AllItemPrivs { get; set; }


        /// <summary>
        /// 
        /// Data Type : itemPrivDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/privilegeGroupItems" maxOccurs="unbounded" minOccurs="0" name="itemPrivileges" nillable="true" type="itemPrivDto"/>
        /// </summary>

        [JsonPropertyName("itemPrivileges")]
        public object? ItemPrivileges { get; set; }


        /// <summary>
        /// 
        /// Data Type : knowledgePrivDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/knowledgePrivileges" maxOccurs="unbounded" minOccurs="0" name="knowledgePrivileges" nillable="true" type="knowledgePrivDto"/>
        /// </summary>

        [JsonPropertyName("knowledgePrivileges")]
        public object? KnowledgePrivileges { get; set; }


        /// <summary>
        /// 
        /// Data Type : privilegeGroupPermissionDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/privilegeGroupPermissions" maxOccurs="unbounded" minOccurs="0" name="permissions" nillable="true" type="privilegeGroupPermissionDto"/>
        /// </summary>

        [JsonPropertyName("permissions")]
        public object? Permissions { get; set; }


        /// <summary>
        /// 
        /// Data Type : privilegeUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/privilegeUsers" maxOccurs="unbounded" minOccurs="0" name="privilegeUsers" nillable="true" type="privilegeUserDto"/>
        /// </summary>

        [JsonPropertyName("privilegeUsers")]
        public object? PrivilegeUsers { get; set; }


        /// <summary>
        /// Property used to determine how many users are associated with a particular privilege group. This property is populated using field prepopulation value 'assystUsersCount'
        /// </summary>

        [JsonPropertyName("privilegeUsersCount")]
        public int? PrivilegeUsersCount { get; set; }


        /// <summary>
        /// 
        /// Data Type : privilegeDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/privilegeGroupEntities" maxOccurs="unbounded" minOccurs="0" name="privileges" nillable="true" type="privilegeDto"/>
        /// </summary>

        [JsonPropertyName("privileges")]
        public object? Privileges { get; set; }

    }

}
