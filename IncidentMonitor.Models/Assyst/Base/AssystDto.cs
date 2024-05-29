using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.Assyst
{


    public abstract class AssystDto : GraphObjectBase
    {
        /// <summary>
        /// 
        /// Data Type : attachmentDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" maxOccurs="unbounded" minOccurs="0" name="attachmentsForLinking" nillable="true" type="attachmentDto"/>
        /// </summary>

        [JsonPropertyName("attachmentsForLinking")]
        public object? AttachmentsForLinking { get; set; }


        [JsonPropertyName("bulkOperation")]
        public bool? BulkOperation { get; set; }


        [JsonPropertyName("cacheable")]
        public bool? Cacheable { get; set; }


        [JsonPropertyName("dataLocale")]
        public string? DataLocale { get; set; }


        /// <summary>
        /// 
        /// Data Type : entityDefinitionDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="entityDefinition" type="entityDefinitionDto"/>
        /// </summary>

        [JsonPropertyName("entityDefinition")]
        public object? EntityDefinition { get; set; }


        [JsonPropertyName("entityDefinitionId")]
        public int? EntityDefinitionId { get; set; }


        [JsonPropertyName("entityDefinitionType")]
        public int? EntityDefinitionType { get; set; }


        [JsonPropertyName("id")]
        public int? Id { get; set; }


        /// <summary>
        /// 
        /// Data Type : jobDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="jobCommandForCreate" type="jobDto"/>
        /// </summary>

        [JsonPropertyName("jobCommandForCreate")]
        public object? JobCommandForCreate { get; set; }


        /// <summary>
        /// 
        /// Data Type : jobDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="jobCommandForDelete" type="jobDto"/>
        /// </summary>

        [JsonPropertyName("jobCommandForDelete")]
        public object? JobCommandForDelete { get; set; }


        /// <summary>
        /// 
        /// Data Type : jobDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="jobCommandForUpdate" type="jobDto"/>
        /// </summary>

        [JsonPropertyName("jobCommandForUpdate")]
        public object? JobCommandForUpdate { get; set; }


        [JsonPropertyName("maxRecordsCount")]
        public int? MaxRecordsCount { get; set; }


        [JsonPropertyName("objectAvailable")]
        public bool? ObjectAvailable { get; set; }


        /// <summary>
        /// 
        /// Data Type : objectGraphInstruction
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="objectGraphInstruction" type="objectGraphInstruction"/>
        /// </summary>

        [JsonPropertyName("objectGraphInstruction")]
        public object? ObjectGraphInstruction { get; set; }


        /// <summary>
        /// 
        /// Data Type : jobDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" maxOccurs="unbounded" minOccurs="0" name="onDemandFormJobs" nillable="true" type="jobDto"/>
        /// </summary>

        [JsonPropertyName("onDemandFormJobs")]
        public object? OnDemandFormJobs { get; set; }


        [JsonPropertyName("parentVersion")]
        public int? ParentVersion { get; set; }


        [JsonPropertyName("partOfTruncatedDataset")]
        public bool? PartOfTruncatedDataset { get; set; }


        /// <summary>
        /// 
        /// Data Type : assystDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/query" minOccurs="0" name="previousVersionDto" type="assystDto"/>
        /// </summary>

        [JsonPropertyName("previousVersionDto")]
        public object? PreviousVersionDto { get; set; }


        [JsonPropertyName("resolveNestedObjects")]
        public bool? ResolveNestedObjects { get; set; }


        [JsonPropertyName("systemRecordFlag")]
        public bool? SystemRecordFlag { get; set; }


        [JsonPropertyName("totalRecordsCount")]
        public int? TotalRecordsCount { get; set; }


        [JsonPropertyName("version")]
        public int? Version { get; set; }


        /// <summary>
        /// 
        /// Data Type : webCustomPropertyValueDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" maxOccurs="unbounded" minOccurs="0" name="customFields" type="webCustomPropertyValueDto"/>
        /// </summary>

        [JsonPropertyName("customFields")]
        public IEnumerable<WebCustomPropertyValueDto?>? CustomFields { get; set; }


        /// <summary>
        /// 
        /// Data Type : windowsCustomFieldPropertyValueDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" maxOccurs="unbounded" minOccurs="0" name="windowsCustomFields" type="windowsCustomFieldPropertyValueDto"/>
        /// </summary>

        [JsonPropertyName("windowsCustomFields")]
        public object? WindowsCustomFields { get; set; }


        /// <summary>
        /// 
        /// Data Type : windowsCustomLookupPropertyValueDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" maxOccurs="unbounded" minOccurs="0" name="windowsCustomLookups" type="windowsCustomLookupPropertyValueDto"/>
        /// </summary>

        [JsonPropertyName("windowsCustomLookups")]
        public object? WindowsCustomLookups { get; set; }

    }







}
