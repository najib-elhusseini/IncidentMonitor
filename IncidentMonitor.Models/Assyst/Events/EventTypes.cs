using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.Assyst
{
    public enum EventTypes
    {
        INCIDENT,
        CHANGE,
        PROBLEM,
        NORMALTASK,
        DECISIONTASK,
        AUTHORISATIONTASK,
        SERVICEREQUEST,
        ORDER,
    }

    public class EventTypesJsonConverter : JsonConverter<EventTypes>
    {
        public override EventTypes Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var str = reader.GetString();
            var result = str switch
            {
                "INCIDENT" => EventTypes.INCIDENT,
                "CHANGE" => EventTypes.CHANGE,
                "PROBLEM" => EventTypes.PROBLEM,
                "NORMALTASK" => EventTypes.NORMALTASK,
                "DECISIONTASK" => EventTypes.DECISIONTASK,
                "AUTHORISATIONTASK" => EventTypes.AUTHORISATIONTASK,
                "SERVICEREQUEST" => EventTypes.SERVICEREQUEST,
                "ORDER" => EventTypes.ORDER,
                _ => EventTypes.INCIDENT,
            };
            return result;
        }

        public override void Write(Utf8JsonWriter writer, EventTypes value, JsonSerializerOptions options)
        {
            var valueString = value.ToString();
            writer.WriteStringValue(valueString);          
        }
    }
}
