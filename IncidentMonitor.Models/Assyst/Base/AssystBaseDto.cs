using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.Assyst
{

    public abstract class AssystBaseDto : AssystDto
    {
        /// <summary>
        /// 
        /// Data Type : attachmentDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" maxOccurs="unbounded" minOccurs="0" name="attachments" nillable="true" type="attachmentDto"/>
        /// </summary>

        [JsonPropertyName("attachments")]
        public object? Attachments { get; set; }


        /// <summary>
        /// 
        /// Data Type : webCustomColumnDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" maxOccurs="unbounded" minOccurs="0" name="customColumns" nillable="true" type="webCustomColumnDto"/>
        /// </summary>

        [JsonPropertyName("customColumns")]
        public object? CustomColumns { get; set; }


        [JsonPropertyName("discontinued")]
        public bool? Discontinued { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="image"/>
         */


        [JsonPropertyName("imageId")]
        public int? ImageId { get; set; }


        [JsonPropertyName("modifyDate")]
        public DateTime? ModifyDate { get; set; }


        [JsonPropertyName("modifyId")]
        public string? ModifyId { get; set; }


        [JsonPropertyName("name")]
        public string? Name { get; set; }


        [JsonPropertyName("remarks")]
        public string? Remarks { get; set; }


        /// <summary>
        /// 
        /// Data Type : richTextFieldDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="richRemarks" type="richTextFieldDto"/>
        /// </summary>

        [JsonPropertyName("richRemarks")]
        public RichTextFieldDto? RichRemarks { get; set; }


        [JsonPropertyName("shortCode")]
        public string? ShortCode { get; set; }

    }

}
