using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.Assyst
{
    public enum EventStateTypesEnum
    {

        ASSESSED,
        BACKED_OUT,
        CANCELLED,
        REGISTERED,
        KNOWN_ERROR,
        FAILED,
        HOLD,
        REJECTED,
        KNOWN_PROBLEM,
        LOGGED,
        IMPLEMENTED,
        PROCEED,
        PROBLEM,
        ROUTINE_INCIDENT,
        TESTED,
        BUILT,
        AUTHORISED,
        VERIFIED,
        REVIEWED,
        CHANGE,
        NOT_AUTHORISED,
        KNOWLEDGE_SOLVE,
        WITHDRAWN,
        RESCHEDULED,
    }

    public class EventStateTypesEnumJsonConverter : JsonConverter<EventStateTypesEnum?>
    {

        public override EventStateTypesEnum? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var str = reader.GetString();
            EventStateTypesEnum? result = str switch
            {

                "ASSESSED" => EventStateTypesEnum.ASSESSED,
                "BACKED_OUT" => EventStateTypesEnum.BACKED_OUT,
                "CANCELLED" => EventStateTypesEnum.CANCELLED,
                "REGISTERED" => EventStateTypesEnum.REGISTERED,
                "KNOWN_ERROR" => EventStateTypesEnum.KNOWN_ERROR,
                "FAILED" => EventStateTypesEnum.FAILED,
                "HOLD" => EventStateTypesEnum.HOLD,
                "REJECTED" => EventStateTypesEnum.REJECTED,
                "KNOWN_PROBLEM" => EventStateTypesEnum.KNOWN_PROBLEM,
                "LOGGED" => EventStateTypesEnum.LOGGED,
                "IMPLEMENTED" => EventStateTypesEnum.IMPLEMENTED,
                "PROCEED" => EventStateTypesEnum.PROCEED,
                "PROBLEM" => EventStateTypesEnum.PROBLEM,
                "ROUTINE_INCIDENT" => EventStateTypesEnum.ROUTINE_INCIDENT,
                "TESTED" => EventStateTypesEnum.TESTED,
                "BUILT" => EventStateTypesEnum.BUILT,
                "AUTHORISED" => EventStateTypesEnum.AUTHORISED,
                "VERIFIED" => EventStateTypesEnum.VERIFIED,
                "REVIEWED" => EventStateTypesEnum.REVIEWED,
                "CHANGE" => EventStateTypesEnum.CHANGE,
                "NOT_AUTHORISED" => EventStateTypesEnum.NOT_AUTHORISED,
                "KNOWLEDGE_SOLVE" => EventStateTypesEnum.KNOWLEDGE_SOLVE,
                "WITHDRAWN" => EventStateTypesEnum.WITHDRAWN,
                "RESCHEDULED" => EventStateTypesEnum.RESCHEDULED,
                _ => null,
            };
            return result;
        }

        public override void Write(Utf8JsonWriter writer, EventStateTypesEnum? value, JsonSerializerOptions options)
        {
            var valueString = value.ToString();
            writer.WriteStringValue(valueString);
        }


    }



}