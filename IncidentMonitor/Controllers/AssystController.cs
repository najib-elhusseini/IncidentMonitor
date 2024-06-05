using IncidentMonitor.DataLayer.Helpers;
using IncidentMonitor.DataLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using IncidentMonitor.Models.Assyst;
using IncidentMonitor.Models.RemedyForce;
using IncidentMonitor.Models;
using IncidentMonitor.Services;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using IncidentMonitor.DataLayer.Data;
using Microsoft.VisualBasic;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace IncidentMonitor.Controllers
{
    public class AssystController : ApiControllerBase
    {

        private readonly IncidentBackgroundMonitorService _incidentBackgroundMonitorService;
        public AssystController(UserManager<ApplicationUser> userManager,
            IDataLayerHelperEntity dataLayerHelper,
            IncidentBackgroundMonitorService incidentBackgroundMonitorService
            ) : base(userManager, dataLayerHelper)
        {
            _incidentBackgroundMonitorService = incidentBackgroundMonitorService;
        }
        #region Assyst Settings

        [HttpGet]
        public async Task<IActionResult> GetAssystSettingsAsync()
        {
            var user = await CheckAuthorizationHeader(true);
            if (user == null)
            {
                return Unauthorized();
            }

            var settings = DataLayerHelper.AssystSettingsHelper.Get();

            return Ok(JsonSerializer.Serialize(settings));
        }

        [HttpPost]
        public async Task<IActionResult> SaveSettingsAsync()
        {

            var user = await CheckAuthorizationHeader(true);
            if (user == null)
            {
                return Unauthorized();
            }
            var settings = DataLayerHelper.AssystSettingsHelper.Get();
            var userName = Request.Form.TryParseString("userName");
            var password = Request.Form.TryParseString("password");
            var baseUrl = Request.Form.TryParseString("baseUrl");
            settings.UserName = userName ?? "";
            settings.Password = password ?? "";
            settings.BaseUrl = baseUrl ?? "";
            try
            {
                await DataLayerHelper.SaveAsync();
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }


        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetEventAsync(int eventId)
        {
            var user = await CheckAuthorizationHeader(true);
            if (user == null)
            {
                return Unauthorized();
            }
            if (DataLayerHelper.AssystEventsHelper is null)
            {
                return BadRequest();
            }

            var eventDto = await DataLayerHelper.AssystEventsHelper.GetEventByIdAsync(eventId);
            if (eventDto == null)
            {
                return NotFound();
            }
            eventDto.Actions = eventDto?.Actions?.OrderByDescending(a => a.Id).ToList() ?? new();
            return Ok(eventDto);

        }

        [HttpGet]
        [Obsolete("No longer used, should be removed on next push")]
        public async Task<IActionResult> GetLastEvent()
        {
            throw new NotImplementedException();
            //var user = await CheckAuthorizationHeader(true);
            //if (user == null)
            //{
            //    return Unauthorized();
            //}
            //if (DataLayerHelper.AssystEventsHelper is null)
            //{
            //    return BadRequest();
            //}

            //var assystEvent = await DataLayerHelper.AssystEventsHelper.GetTopEvent(EventTypes.INCIDENT);
            //if (assystEvent == null)
            //{
            //    return NotFound();
            //}
            //return Ok(assystEvent);
        }

        [HttpGet]
        public async Task<IActionResult> GetTodayIncidentsAsync()
        {
            var user = await CheckAuthorizationHeader(true);
            if (user == null)
            {
                return Unauthorized();
            }
            if (DataLayerHelper.AssystEventsHelper is null)
            {
                return BadRequest();
            }

            try
            {
                List<EventDto> events = new List<EventDto>();
                events = _incidentBackgroundMonitorService.Incidents;

                foreach (var evet in events)
                {

                    var status = evet.GetEventAcknowledgedStatus(user);
                    evet.EventAcknowledgedStatus = status;

                }

                return Ok(events);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> RefreshIncidentsAsync()
        {
            var user = await CheckAuthorizationHeader(true);
            if (user == null)
            {
                return Unauthorized();
            }
            if (DataLayerHelper.AssystEventsHelper is null)
            {
                return BadRequest();
            }

            try
            {
                List<EventDto> events = new List<EventDto>();
                await _incidentBackgroundMonitorService.GetIncidents();
                events = _incidentBackgroundMonitorService.Incidents;

                foreach (var evet in events)
                {
                    var status = evet.GetEventAcknowledgedStatus(user);
                    evet.EventAcknowledgedStatus = status;

                }

                return Ok(events);
            }
            catch (Exception ex)
            {

                throw;
            }
        }



        [HttpPost]
        public async Task<IActionResult> PostEventAction()
        {
            var user = await CheckAuthorizationHeader(false);
            if (user == null)
            {
                return Unauthorized();
            }
            if (DataLayerHelper.AssystEventsHelper == null)
            {
                return BadRequest();
            }

            try
            {
                var shortCode = Request.Form.TryParseString("shortCode");
                var eventId = Request.Form.TryParseInt("eventId");
                var remarks = Request.Form.TryParseString("remarks") ?? "";
                var actionTypeId = Request.Form.TryParseInt("eventActionTypeId");
                if (eventId == null || actionTypeId == null)
                {
                    return BadRequest();
                }
                var action = await DataLayerHelper.AssystEventsHelper.PostEventAction(
                    eventId.Value,
                    null,
                    actionTypeId.Value,
                    remarks,
                    shortCode
                    );
                if (action != null)
                {
                    await _incidentBackgroundMonitorService.GetIncidents();
                    var events = _incidentBackgroundMonitorService.Incidents;
                    foreach (var evet in events)
                    {
                        var status = evet.GetEventAcknowledgedStatus(user);
                        evet.EventAcknowledgedStatus = status;

                    }
                    return Ok(events);
                }

                return StatusCode(StatusCodes.Status500InternalServerError);

            }
            catch (Exception ex)
            {

                throw;
            }





        }

        [HttpGet]
        public async Task<IActionResult> GetSearchCount(string query)
        {
            var user = await CheckAuthorizationHeader(false);
            if (user == null)
            {
                return Unauthorized();
            }
            if (DataLayerHelper.AssystEventsHelper == null)
            {
                return BadRequest();
            }

            var count = await DataLayerHelper.AssystEventsHelper.GetSearchResultCount(query);

            return Ok(count);
        }

        [HttpGet]
        [Obsolete(message: "Please user QueryEvents that will also return a search result count instead")]
        public async Task<IActionResult> SearchEvents(string searchQuery)
        {
            var user = await CheckAuthorizationHeader(false);
            if (user == null)
            {
                return Unauthorized();
            }
            if (DataLayerHelper.AssystEventsHelper == null)
            {
                return BadRequest();
            }

            var events = await DataLayerHelper.AssystEventsHelper.GetEventsAsync(searchQuery);

            return Ok(events);
        }

        [HttpGet]
        public async Task<IActionResult> QueryEvents(string searchQuery, int? skip, int? top, string? additionalFields)
        {
            var user = await CheckAuthorizationHeader(false);
            if (user == null)
            {
                return Unauthorized();
            }
            if (DataLayerHelper.AssystEventsHelper == null)
            {
                return BadRequest();
            }
            skip ??= 0;
            top ??= 100;
            var count = await DataLayerHelper.AssystEventsHelper.GetSearchResultCount(searchQuery);
            var query = $"{searchQuery}&$skip={skip.Value}&$top={top.Value}"; //searchQuery; 
            additionalFields ??= string.Empty;
            var fields = additionalFields.Split(',');
            var result = await DataLayerHelper.AssystEventsHelper.GetEventsAsync(query, fields);


            return Ok(new
            {
                count,
                result
            });

        }

        [HttpGet]
        public async Task<IActionResult> GetEventsInRange(DateTime from, DateTime? to, string? eventType)
        {
            var user = await CheckAuthorizationHeader(false);
            if (user == null)
            {
                return Unauthorized();
            }
            if (DataLayerHelper.AssystEventsHelper == null)
            {
                return BadRequest();
            }

            to ??= DateTime.Now;
            eventType ??= "INCIDENT";
            var events = new List<EventDto>();
            var skip = 0;
            var fields = "actions[id,richRemarks,actionTypeId,actionType[id,name],modifyDate,dateActioned,modifyId,actionedBy[id,name,emailAddress],serviceTime[value]]";
            do
            {
                bool done = false;
                var query = $"$skip={skip}&$top=50&eventType={eventType}&$orderby=id:desc";
                var result = await DataLayerHelper.AssystEventsHelper.GetEventsAsync(query, fields);
                if (result == null)
                {
                    break;
                }
                foreach (var @event in result)
                {
                    if (@event.DateLogged != null && @event.DateLogged < from)
                    {
                        done = true;
                        break;
                    }
                    if (@event.DateLogged >= from && @event.DateLogged <= to)
                    {
                        events.Add(@event);
                    }
                }
                if (done)
                {
                    break;
                }
                skip += 50;

            } while (true);


            return Ok(events);

        }



    }
}
