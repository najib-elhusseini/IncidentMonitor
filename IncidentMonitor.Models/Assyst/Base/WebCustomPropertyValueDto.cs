using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.Assyst
{
    public class WebCustomPropertyValueDto
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("version")]
        public int? Version { get; set; }

        [JsonPropertyName("objectAvailable")]
        public bool? ObjectAvailable { get; set; }

        [JsonPropertyName("systemRecordFlag")]
        public bool? SystemRecordFlag { get; set; }

        [JsonPropertyName("entityDefinitionType")]
        public int? EntityDefinitionType { get; set; }

        [JsonPropertyName("cacheable")]
        public bool? Cacheable { get; set; }

        [JsonPropertyName("dataLocale")]
        public string? DataLocale { get; set; }

        [JsonPropertyName("richRemarks")]
        public RichTextFieldDto? RichRemarks { get; set; }

        [JsonPropertyName("imageId")]
        public int? ImageId { get; set; }

        [JsonPropertyName("entityInstanceId")]
        public int? EntityInstanceId { get; set; }

        [JsonPropertyName("stringValue")]
        public string? StringValue { get; set; }

        [JsonPropertyName("booleanValue")]
        public bool? BooleanValue { get; set; }

        [JsonPropertyName("customLookupValueShortCode")]
        public string? CustomLookupValueShortCode { get; set; }

        [JsonPropertyName("systemLookupValueId")]
        public int? SystemLookupValueId { get; set; }

        [JsonPropertyName("customFieldShortCode")]
        public string? CustomFieldShortCode { get; set; }

        [JsonPropertyName("dtoName")]
        public string? DtoName { get; set; }

        [JsonPropertyName("anonymousRecord")]
        public bool? AnonymousRecord { get; set; }

        [JsonPropertyName("record")]
        public bool? Record { get; set; }

        [JsonPropertyName("systemRecord")]
        public bool? SystemRecord { get; set; }

        [JsonPropertyName("customFieldId")]
        public int? CustomFieldId { get; set; }

        [JsonPropertyName("customFieldType")]
        public int? CustomFieldType { get; set; }

        [JsonPropertyName("customLookupValueId")]
        public int? CustomLookupValueId { get; set; }
    }
}
