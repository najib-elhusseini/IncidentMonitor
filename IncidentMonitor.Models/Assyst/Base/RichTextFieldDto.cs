using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.Assyst
{


    public class RichTextFieldDto
    {

        [JsonPropertyName("content")]
        public string? Content { get; set; }


        [JsonPropertyName("plainTextContent")]
        public string? PlainTextContent { get; set; }


        /// <summary>
        /// 
        /// Data Type : attachmentDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" maxOccurs="unbounded" minOccurs="0" name="unsavedInlineImages" nillable="true" type="attachmentDto"/>
        /// </summary>

        [JsonPropertyName("unsavedInlineImages")]
        public object? UnsavedInlineImages { get; set; }

    }

}
