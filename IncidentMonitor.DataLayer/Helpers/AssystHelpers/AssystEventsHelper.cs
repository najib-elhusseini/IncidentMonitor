using IncidentMonitor.Models;
using IncidentMonitor.Models.Assyst;
using IncidentMonitor.Models.RemedyForce;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IncidentMonitor.DataLayer.Helpers
{

    public class AssystEventsHelper : AssystHelper
    {



        public AssystEventsHelper(AssystSettings settings) : base(settings)
        {
        }

        private string GetEventFields(params string[] additionalFields)
        {
            var fields = new List<string>()
            {
                "id",
                "richRemarks[content]",
                "userReference",
                "assignedServDeptId",
                "affectedUserId",
                "affectedUserName",
                "affectedUserEmail",
                "eventRef",
                "formattedReference",
                "eventStatus",
                "eventState",
                "eventStateEnum",
                "eventStatusEnum",
                "shortDescription",
                "impactId",
                "urgencyId",
                "priorityId",
                "departmentId",
                "dateLogged",
                "assignedUser[name,emailAddress]",
                "department[id,sectionDepartmentName,sectionDepartmentShortCode,section[name]]",
                "assignedServDept[id,name,shortCode]",
                "actions[id,richRemarks,actionTypeId,actionType[id,name],modifyDate,dateActioned]",
                "lastSlaClockStop",
            };
            foreach (var field in additionalFields)
            {
                if (string.IsNullOrWhiteSpace(field))
                {
                    continue;
                }
                fields.Add(field);
            }
            
            //StringBuilder sb = new StringBuilder();
            //foreach (var field in fields)
            //{
            //    sb.Append(field);
            //    sb.Append(',');
            //}

            return string.Join(",", fields);

        }



        public async Task<List<ServDeptDto>> GetServiceDepartments()
        {
            var endPoint = $"serviceDepartments?fields=[id,name,shortCode]";
            var (client, url) = GetHttpClient(endPoint);
            var response = await client.GetAsync(url);
            var responseText = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            var departments = JsonSerializer.Deserialize<IEnumerable<ServDeptDto>>(responseText);
            return departments?.ToList() ?? new List<ServDeptDto>();
        }

        public async Task<ActionTypeDto?> GetUserCallbackActionType()
        {
            var endPoint = "actionTypes?shortCode=USER-CALLBACK";
            var (client, url) = GetHttpClient(endPoint);
            var response = await client.GetAsync(url);
            var responseText = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            var actionTypes = JsonSerializer.Deserialize<IEnumerable<ActionTypeDto>>(responseText);
            if (actionTypes == null)
            {
                return null;
            }
            return actionTypes.FirstOrDefault();

        }

        public async Task<int> GetSearchResultCount(string query)
        {
            try
            {
                var endPoint = $"events/searchResultCount?{query}";
                var (client, url) = GetHttpClient(endPoint);
                var response = await client.GetAsync(url);
                var responseText = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
                var count = JsonSerializer.Deserialize<SearchResultCount>(responseText);
                return count.Value;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<EventDto>?> GetEventsAsync(string query, params string[] additionalFields)
        {
            var fields = GetEventFields(additionalFields);
            query = $"{query}&fields={fields}";
            try
            {
                var endPoint = $"events?{query}";
                var (client, url) = GetHttpClient(endPoint);
                var response = await client.GetAsync(url);
                var responseText = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
                var events = JsonSerializer.Deserialize<IEnumerable<EventDto>>(responseText);
                return events; 
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<EventDto?> GetEventByIdAsync(int id, IEnumerable<string>? fields)
        {
            var endPoint = $"events/{id}";
            if (fields != null && fields.Any())
            {
                endPoint = $"{endPoint}?fields={string.Join(",", fields)}";
            }
            var (client, url) = GetHttpClient(endPoint);
            var response = await client.GetAsync(url);
            var responseText = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            var eventDto = JsonSerializer.Deserialize<EventDto>(responseText);
            return eventDto;

        }


        public async Task<List<EventDto>?> GetEventByRemedyForceReferences(params string[] forceReferences)
        {
            var references = string.Join(',', forceReferences);
            var fields = GetEventFields();
            var endPoint = $"events?eventType=INCIDENT&fields=[id,eventRef,userReference,lastSlaClockStop]&orderByLoggedDateDesc=true&userReference={references}";
            var (client, url) = GetHttpClient(endPoint);
            var response = await client.GetAsync(url);
            var responseText = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            var events = JsonSerializer.Deserialize<IEnumerable<EventDto>>(responseText);
            if (events == null)
            {
                return null;
            }

            //foreach (var evnt in events)
            //{
            //    if (evnt.LastSlaClockStop == null)
            //    {
            //        try
            //        {
            //            await PostEventAction(evnt.Id!.Value, null, WaitingOnCustomerInputActionTypeId, "Clock stopped by automation", "NAJIB.ELHUSSEINI@HOIST.TECH");

            //        }
            //        catch (Exception ex)
            //        {

            //            throw ex;
            //        }
            //    }
            //}
            return events.ToList();
        }

        public async Task<object> UpdateEventDtoUserReference
            (EventDto eventDto,
            string userReference,
            int? affectedUserId,
            string? onBehaldOfUser = null)
        {
            var endPoint = $"events/{eventDto.Id}";
            if (!string.IsNullOrWhiteSpace(onBehaldOfUser))
            {
                endPoint = $"{endPoint}?onBehalfOfUser={onBehaldOfUser}";
            }
            var (client, url) = GetHttpClient(endPoint);
            var id = eventDto.Id;
            eventDto.Id = null;
            JsonSerializerOptions options = new()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
            };
            eventDto.Id = id;
            var t = new
            {
                userReference,
                affectedUserId,
            };
            var bodytext = JsonSerializer.Serialize(t, options);
            var stringContent = new StringContent(bodytext, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, stringContent);
            var responseText = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            return responseText;

        }

        public async Task<(List<EventDto> todayEvents, bool done)> GetTodayOpenIncidents(int skip)
        {
            var fields = GetEventFields();
            var endPoint = $"events?eventType=INCIDENT&eventStatus=OPEN,PENDING,SUBMITTED&fields=[{fields}]&orderByLoggedDateDesc=true&$top=25&$skip={skip}";
            var (client, url) = GetHttpClient(endPoint);
            var response = await client.GetAsync(url);
            var responseText = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            var events = JsonSerializer.Deserialize<IEnumerable<EventDto>>(responseText);
            var todayEvents = new List<EventDto>();
            var yesterdayEvents = new List<EventDto>();
            if (events == null || !events.Any())
            {
                return (todayEvents, true);
            }
            var today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            //.ToUniversalTime();
            var yesetrday = today.AddDays(-1);
            var dayBeforeYesterday = yesetrday.AddDays(-1);
            bool done = false;
            foreach (var incident in events)
            {
                var eventDate = incident.DateLogged;
                if (eventDate == null)//guard, but not necessary 
                {
                    continue;
                }

                eventDate = eventDate.Value.ToUniversalTime();
                if (eventDate <= dayBeforeYesterday)
                {
                    done = true;
                    break;
                }

                //if (eventDate > yesetrday && eventDate <= today)
                //{
                //    todayEvents.Add(incident);
                //}
                //if (eventDate > dayBeforeYesterday && eventDate <= yesetrday)
                //{
                //    yesterdayEvents.Add(incident);
                //}
                //if (incident.Actions != null)
                //{
                //    var respondedAction = incident.Actions.FirstOrDefault(a =>
                //    a.ActionTypeId == ActionTypeIds.AcknowledgmentActionTypeId);
                //    incident.Acknowledged = respondedAction != null;
                //}
                todayEvents.Add(incident);

            }

            return (todayEvents, done);
        }

        public async Task<EventDto?> GetEventByIdAsync(int id)
        {

            var endPoint = $"events/{id}?fields=[*,department[section[name]],serviceOffering[name],actions[*,actionType]]";
            var (client, url) = GetHttpClient(endPoint);
            var response = await client.GetAsync(url);
            var responseText = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            var eventDto = JsonSerializer.Deserialize<EventDto>(responseText);
            if (eventDto != null && eventDto.Actions != null)
            {
                eventDto.Actions = eventDto.Actions.OrderByDescending(a => a.DateActioned).ToList();
            }
            return eventDto;

        }


        public async Task<IEnumerable<AssystActionDto>> GetEventActions(params int[] ids)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var id in ids)
            {
                stringBuilder.Append(id);
                stringBuilder.Append(',');
            }
            var idString = stringBuilder.ToString().TrimEnd(',');
            var endPoint = $"/actions?eventId={idString}";
            var (client, url) = GetHttpClient(endPoint);
            var response = await client.GetAsync(url);
            var responseText = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            var actions = JsonSerializer.Deserialize<IEnumerable<AssystActionDto>>(responseText);
            return actions ?? new List<AssystActionDto>();
        }




        public async Task<bool?> CheckEventAcknowledgement(int eventId)
        {
            var result = await GetEventActions(eventId);
            if (result == null)
            {
                return false;
            }

            foreach (var item in result)
            {
                if (item.ActionTypeId == ActionTypeIds.AcknowledgmentActionTypeId)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<IEnumerable<AssystActionDto>?> GetEventActions(int eventId)
        {
            var endPoint = $"/actions?eventId={eventId}";
            var (client, url) = GetHttpClient(endPoint);
            var response = await client.GetAsync(url);
            var responseText = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            var actions = JsonSerializer.Deserialize<IEnumerable<AssystActionDto>>(responseText);
            return actions;
        }


        public async Task<EventDto?> CreateEventAsync(EventDto eventDto, string onBehalfOfUser)
        {
            var endPoint = $"events";

            if (!string.IsNullOrWhiteSpace(onBehalfOfUser))
            {
                endPoint = $"{endPoint}?onBehalfOfUser={onBehalfOfUser}";
            }
            var (client, url) = GetHttpClient(endPoint);
            var data = new
            {
                affectedUserId = eventDto.AffectedUserId,
                shortDescription = eventDto.ShortDescription,
                richRemarks = new
                {
                    content = eventDto.RichRemarks?.Content ?? ""
                },
                assignedServDeptId = eventDto.AssignedServDeptId,
                impactId = eventDto.ImpactId,
                urgencyId = eventDto.UrgencyId,
                itemAId = eventDto.ItemAId,
                serviceOfferingId = eventDto.ServiceOfferingId

            };
            var serialized = JsonSerializer.Serialize(data);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, stringContent);
            var responseText = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            var evt = JsonSerializer.Deserialize<EventDto>(responseText);
            return evt;
        }


        public async Task<AssystActionDto?> PostEventAction(int eventId,
            long? actionId,
            int actionTypeId,
            string content, string? onBehalfOfUser)
        {
            var endPoint = $"actions";
            if (actionId != null)
            {
                endPoint = $"{endPoint}/{actionId}";
            }
            if (!string.IsNullOrWhiteSpace(onBehalfOfUser))
            {
                endPoint = $"{endPoint}?onBehalfOfUser={onBehalfOfUser}";
            }
            var (client, url) = GetHttpClient(endPoint);
            var data = new
            {
                eventId,
                actionTypeId,
                richRemarks = new
                {
                    content,
                }
            };
            var stringContent = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, stringContent);
            var responseText = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            var action = JsonSerializer.Deserialize<AssystActionDto>(responseText);
            return action;
        }



        public async Task<IEnumerable<AssystActionDto>?> GetActionsById(params int[] ids)
        {
            var idString = string.Join(",", ids);
            var endPoint = $"actions?id={idString}&fields=[*,richRemarks,actionType]";
            var (client, url) = GetHttpClient(endPoint);

            var response = await client.GetAsync(url);
            var responseText = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<IEnumerable<AssystActionDto>?>(responseText);
        }
    }
}
