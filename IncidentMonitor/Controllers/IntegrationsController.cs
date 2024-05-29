using IncidentMonitor.DataLayer.Helpers;
using IncidentMonitor.DataLayer.Models;
using IncidentMonitor.Models;
using IncidentMonitor.Models.Assyst;
using IncidentMonitor.Models.ServiceNow;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace IncidentMonitor.Controllers
{
    public class IntegrationsController : ApiControllerBase
    {
        const int _carrixDepartmentId = 43;
        const int _diamondVogelDepartmentId = 47;

        

        public IntegrationsController(UserManager<ApplicationUser> userManager,
            IDataLayerHelperEntity dataLayerHelper) : base(userManager, dataLayerHelper)
        {
            
        }


        [HttpPost]
        [Obsolete("This action was needed on GO-LIVE, no longer required")]
        public async Task<IActionResult> ConnectToDiamondVogel(int eventId, string? diamondVogelTicketId)
        {
            //customFields
            var user = await CheckAuthorizationHeader(false);
            if (user == null)
            {
                return Unauthorized();
            }
            if (DataLayerHelper.AssystEventsHelper == null)
            {
                return BadRequest();
            }
            var fields = new List<string>() { "customFields" };
            var eventDto = await DataLayerHelper.AssystEventsHelper.GetEventByIdAsync(eventId, fields);
            if (eventDto == null)
            {
                return NotFound($"Event {eventId} Not found");
            }
            diamondVogelTicketId ??= eventDto.CustomerCaseId;
            var oldUserReference = eventDto.UserReference;
            if (diamondVogelTicketId == null)
            {
                return BadRequest("Fresh Service ticket ID is null");
            }
            var diamondVogelTicket = await DataLayerHelper.FreshServiceHelper.GetTicketById(diamondVogelTicketId);
            if (diamondVogelTicket == null)
            {
                return NotFound($"Ticket {diamondVogelTicketId} Not found");
            }
            string onBehalfOfNajib = "NAJIB.ELHUSSEINI@HOIST.TECH";
            await DataLayerHelper.AssystEventsHelper.UpdateEventDtoUserReference
                (eventDto, diamondVogelTicketId, 712, onBehalfOfNajib);
            await DataLayerHelper
                .FreshServiceHelper
                .UpdateHoistIncident(diamondVogelTicketId, $"{eventDto.Id}");
            await DataLayerHelper
                .AssystEventsHelper
                .PostEventAction(eventId, null,
                ActionTypeIds.CommentActionTypeId,
                $"Fresh Service Ticket #{diamondVogelTicketId} was connected to Remedy Force Incident #{oldUserReference}, now connected to Assyst Incident #{eventDto.FormattedReference} ",
                onBehalfOfNajib);

            return Ok(eventDto);
        }



        [HttpPost]
        public async Task<IActionResult> PostActionsToFreshService()
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
            var userReference = Request.Form.TryParseString("userReference");
            if (string.IsNullOrWhiteSpace(userReference))
            {
                return BadRequest();
            }
            var idsString = Request.Form["ids"].ToString();
            var ids = JsonSerializer.Deserialize<List<int>>(idsString);
            if (ids == null || !ids.Any())
            {
                return BadRequest();
            }
            var actions = await DataLayerHelper.AssystEventsHelper.GetActionsById(ids.ToArray());
            if (actions is null || !actions.Any())
            {
                return BadRequest();
            }
            foreach (var action in actions)
            {
                var stringBuilder = new StringBuilder($"<b>Action Taken : {action.ActionType?.Name}</b>");
                stringBuilder.Append("<br/>");
                stringBuilder.Append(action.RichRemarks?.Content ?? "");


                await DataLayerHelper.FreshServiceHelper.CreateTicketNote(userReference, stringBuilder.ToString());
            }

            return Ok();

        }


        [HttpPost]
        public async Task<IActionResult> CarrixUpdateHoistNumber()
        {

            var user = await CheckAuthorizationHeader(true);
            if (user == null)
            {
                return Unauthorized();
            }
            var userReference = Request.Form.TryParseString("userReference");
            if (string.IsNullOrWhiteSpace(userReference)) { return BadRequest(); }
            var id = Request.Form.TryParseId();
            await DataLayerHelper.
                            CarrixServiceNowHelper.
                            UpdateServiceNowHoistNumber(userReference, id.ToString(), null);

            return Ok();

        }


        [HttpPost]
        public async Task<IActionResult> CarrixPostActionsToServiceNow()
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
            var userReference = Request.Form.TryParseString("userReference");
            if (string.IsNullOrWhiteSpace(userReference))
            {
                return BadRequest();
            }
            var idsString = Request.Form["ids"].ToString();
            var ids = JsonSerializer.Deserialize<List<int>>(idsString);
            if (ids == null || !ids.Any())
            {
                return BadRequest();
            }
            var actions = await DataLayerHelper.AssystEventsHelper.GetActionsById(ids.ToArray());
            if (actions is null || !actions.Any())
            {
                return BadRequest();
            }
            foreach (var action in actions)
            {
                var stringBuilder = new StringBuilder($"<b>Action Taken : {action.ActionType?.Name}</b>");
                stringBuilder.Append("<br/>");
                stringBuilder.Append(action.RichRemarks?.Content ?? "");

                await DataLayerHelper.CarrixServiceNowHelper.UpdateCaseComment(userReference, stringBuilder.ToString());
            }

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetThirdPartyTicketComments(int eventId, int departmentId, string userReference)
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

            if (departmentId != _carrixDepartmentId && departmentId != _diamondVogelDepartmentId)
            {
                throw new NotImplementedException("This function is not yet implemented for the selected customer");
            }

            IEnumerable<GenericHelpDeskComment> comments = Enumerable.Empty<GenericHelpDeskComment>();

            if (departmentId == _carrixDepartmentId)
            {
                var activities = await DataLayerHelper
                    .CarrixServiceNowHelper
                    .GetCaseActivitiesByNumber(userReference);
                comments = activities.Select(a =>
                {
                    var comment = (a as IHelpDeskComment).GenericHelpDeskComment;
                    return comment;
                });
            }
            if (departmentId == _diamondVogelDepartmentId)
            {
                //var notes =
                var ticket = await DataLayerHelper.FreshServiceHelper.GetTicketById(userReference);
                if (ticket != null && ticket.Conversations != null)
                {
                    comments = ticket.Conversations
                        .Select(c =>
                        (c as IHelpDeskComment).GenericHelpDeskComment);
                }

            }
            comments = comments.OrderByDescending(c => c.CreationDate).ToList();


            return Ok(comments);


        }

        [HttpPost]
        public async Task<IActionResult> FixFormatting()
        {
            var user = await CheckAuthorizationHeader(true);
            if (user == null)
            {
                return Unauthorized();
            }
            if (DataLayerHelper.AssystEventsHelper is null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var eventId = Request.Form.TryParseId();
            if (eventId == 0)
            {
                return BadRequest();
            }
            var commentsString = Request.Form.TryParseString("comments");
            if (string.IsNullOrWhiteSpace(commentsString))
            {
                return BadRequest();
            }
            try
            {
                var comments = JsonSerializer.Deserialize<List<GenericHelpDeskComment>>(commentsString);
                if (comments == null)
                {
                    return Ok();
                }
                foreach (var comment in comments)
                {
                    var content = comment.PlainTextDescription ?? "";
                    content = content.Replace("[code]", "");
                    content = content.Replace("[/code]", "");
                    var actionId = Convert.ToInt64(comment.CommentId);
                    await DataLayerHelper.AssystEventsHelper.PostEventAction(eventId, actionId,
                        ActionTypeIds.CommentActionTypeId,
                        content, null);
                }

            }
            catch (Exception ex)
            {

            }


            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CopyThirdPartyComments()
        {
            var user = await CheckAuthorizationHeader(true);
            if (user == null)
            {
                return Unauthorized();
            }
            if (DataLayerHelper.AssystEventsHelper is null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var eventId = Request.Form.TryParseId();
            if (eventId == 0)
            {
                return BadRequest();
            }
            var commentsString = Request.Form.TryParseString("comments");
            if (string.IsNullOrWhiteSpace(commentsString))
            {
                return BadRequest();
            }
            try
            {
                var comments = JsonSerializer.Deserialize<List<GenericHelpDeskComment>>(commentsString);
                foreach (var comment in comments)
                {
                    await DataLayerHelper.AssystEventsHelper.PostEventAction(eventId, null,
                        ActionTypeIds.CommentActionTypeId,
                        (comment.RichTextDescription ?? comment.PlainTextDescription) ?? "", null);
                }

            }
            catch (Exception ex)
            {

            }


            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CopyAssystCommentsToThirdParty()
        {
            var user = await CheckAuthorizationHeader(true);
            if (user == null)
            {
                return Unauthorized();
            }
            if (DataLayerHelper.AssystEventsHelper is null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var eventId = Request.Form.TryParseId();
            if (eventId == 0)
            {
                return BadRequest();
            }
            var commentsString = Request.Form.TryParseString("comments");
            if (string.IsNullOrWhiteSpace(commentsString))
            {
                return BadRequest();
            }
            var userReference = Request.Form.TryParseString("userReference");
            if (userReference == null)
            {
                return BadRequest();
            }
            var departmentId = Request.Form.TryParseInt("departmentId");
            if (departmentId != _carrixDepartmentId && departmentId != _diamondVogelDepartmentId)
            {
                throw new NotImplementedException("This function is not yet implemented for the selected customer");
            }

            try
            {
                var comments = JsonSerializer.Deserialize<List<GenericHelpDeskComment>>(commentsString);
                if (comments == null)
                {
                    return BadRequest();
                }
                if (departmentId == _carrixDepartmentId)
                {
                    CarrixPostComments(userReference, comments);
                }
                if (departmentId == _diamondVogelDepartmentId)
                {
                    DiamondVogelPostComments(userReference, comments);
                }

                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        private async void CarrixPostComments(string caseNumber, IEnumerable<GenericHelpDeskComment> comments)
        {
            foreach (var comment in comments)
            {
                var richText = $"[code]<p><b>Action taken : {comment.Title}</b></p><div>{comment.RichTextDescription}</div>[/code]";
                await DataLayerHelper.CarrixServiceNowHelper.UpdateCaseComment(caseNumber, richText);
            }
        }

        private async void DiamondVogelPostComments(string ticketId, IEnumerable<GenericHelpDeskComment> comments)
        {
            foreach (var comment in comments)
            {
                var richText = $"<p><b>Action taken : {comment.Title}</b></p><div>{comment.RichTextDescription}</div>";
                await DataLayerHelper.FreshServiceHelper.CreateTicketNote(ticketId, richText);

            }
        }


        [HttpGet]
        public async Task<IActionResult> CarrixGetCaseDetails([FromQuery] string[] numbers)
        {
            var user = await CheckAuthorizationHeader(true);
            if (user == null)
            {
                return Unauthorized();
            }

            try
            {
                var cases = new List<ServiceNowCase>();
                foreach (var number in numbers)
                {
                    if (number.StartsWith("000"))
                    {
                        continue;
                    }
                    if (number == "00012224")
                    {
                        continue;
                    }

                    var snowCase = await DataLayerHelper.CarrixServiceNowHelper.GetCaseByNumber(number);

                    if (snowCase == null) continue;
                    

                    cases.Add(snowCase);

                }
                var serialized = JsonSerializer.Serialize(cases);

                return Ok(serialized);
            }
            catch (Exception ex)
            {
                

                throw;
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateIntegration()
        {
            var user = await CheckAuthorizationHeader(true);
            if (user == null)
            {
                return Unauthorized();
            }
            if (DataLayerHelper.AssystEventsHelper is null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            var ticketId = Request.Form.TryParseString("ticketId");
            var deprtmentId = Request.Form.TryParseInt("deprtmentId");
            if (string.IsNullOrEmpty(ticketId))
            {
                return BadRequest();
            }
            var eventDto = new EventDto()
            {
                RichRemarks = new RichTextFieldDto(),
                ServiceOfferingId = 168,
                AssignedServDeptId = 1,
                ItemAId = 426,
                AffectedUserId = 707,
            };
            switch (deprtmentId)
            {
                case null:
                    return BadRequest();
                case _diamondVogelDepartmentId:
                    await AddDiamondVogelIntegration(ticketId, eventDto);

                    return Ok();
                default:
                    return BadRequest();

            }

        }

        private async Task AddDiamondVogelIntegration(string ticketId, EventDto @event)
        {
            var ticket = await DataLayerHelper.FreshServiceHelper.GetTicketById(ticketId);
            if (ticket == null)
            {
                return;
            }
            if (ticket.Responder_id != null)
            {
                var agent = await DataLayerHelper.FreshServiceHelper.GetAgentAsync(ticket.Responder_id.Value);
                ticket.Responder = agent;
            }

            @event.TicketShortDescription = ticket.TicketShortDescription;
            @event.TicketFullDescription = ticket.TicketFullDescription;
            @event.HelpDeskImpact = ticket.HelpDeskImpact;
            @event.HelpDeskUrgency = ticket.HelpDeskUrgency;
            @event.TicketAffectedUserEmail = ticket.Requester?.Email;

            var result = await DataLayerHelper.AssystEventsHelper!.CreateEventAsync(@event, "NAJIB.ELHUSSEINI@HOIST.TECH");
            if (result == null || result.Id == null)
            {
                return;
            }
            var actions = new List<AssystActionDto>();
            foreach (var comment in ticket.Comments)
            {
                var description = comment.RichTextDescription ?? comment.PlainTextDescription;
                if (description == null)
                {
                    continue;
                }
                var action = await DataLayerHelper.AssystEventsHelper.PostEventAction(result.Id.Value,
                      null, ActionTypeIds.CommentActionTypeId,
                      description, "NAJIB.ELHUSSEINI@HOIST.TECH");
                if (action != null)
                {
                    actions.Add(action);
                }
            }
            actions = actions.OrderBy(x => x.Id).ToList();
            result.Actions = actions;
            try
            {
                var integration = new Integration()
                {
                    DateCreated = DateTime.Now,
                    EventId = (ulong)result.Id!.Value,
                    IntegratedTicketId = $"{ticket.Id}",
                    IntegratedSystem = IntegratedSystems.DiamondVogel,
                    EventData = JsonSerializer.Serialize(result),
                    IntegratedTickedData = JsonSerializer.Serialize(ticket),
                    LastUpdated = DateTime.Now,
                };
                DataLayerHelper.IntegrationsHelper.Add(integration);
                await DataLayerHelper.SaveAsync();
            }
            catch (Exception ex)
            {

                throw;
            }




        }

    }
}
