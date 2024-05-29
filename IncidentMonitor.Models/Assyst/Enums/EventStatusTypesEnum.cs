using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.Assyst
{
    public enum EventStatusTypesEnum
    {
        OPEN,
        CLOSED,
        PENDING,
        SUBMITTED,
    }

    public class EventStatusTypesEnumJsonConverter : JsonConverter<EventStatusTypesEnum?>
    {

        public override EventStatusTypesEnum? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var str = reader.GetString();
            EventStatusTypesEnum? result = str switch
            {

                "OPEN" => EventStatusTypesEnum.OPEN,
                "CLOSED" => EventStatusTypesEnum.CLOSED,
                "PENDING" => EventStatusTypesEnum.PENDING,
                "SUBMITTED" => EventStatusTypesEnum.SUBMITTED,
                _ => null,
            };
            return result;
        }

        public override void Write(Utf8JsonWriter writer, EventStatusTypesEnum? value, JsonSerializerOptions options)
        {

            var valueString = value?.ToString() ?? "";
            writer.WriteStringValue(valueString);
        }


    }



}
