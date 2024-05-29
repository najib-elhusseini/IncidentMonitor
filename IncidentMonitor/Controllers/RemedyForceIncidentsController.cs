
using IncidentMonitor.DataLayer.Helpers;
using IncidentMonitor.DataLayer.Models;
using IncidentMonitor.Models;
using IncidentMonitor.Models.RemedyForce;
using IncidentMonitor.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace IncidentMonitor.Controllers
{
    public class RemedyForceIncidentsController : ApiControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public RemedyForceIncidentsController(
            IDataLayerHelperEntity dataLayerHelper,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment webHostEnvironment
            ) : base(userManager, dataLayerHelper)

        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> GetHistoricIncidents(int year)
        {
            var user = await CheckAuthorizationHeader(true);
            if (user == null)
            {
                return Unauthorized();
            }
            var webRootPath = _webHostEnvironment.WebRootPath;
            var fullPath = Path.Combine(webRootPath, "data", "history", $"{year}");
            if (!Directory.Exists(fullPath))
            {
                return BadRequest("Backup was not found");
            }
            var files = Directory.EnumerateFiles(fullPath);
            var allIncidents = new List<Incident>();
            foreach (var jsonFile in files)
            {
                if (string.IsNullOrWhiteSpace(jsonFile))
                {
                    continue;
                }
                var jsonString = System.IO.File.ReadAllText(jsonFile);
                if (string.IsNullOrWhiteSpace(jsonString))
                {
                    continue;
                }
                var incidents = JsonSerializer.Deserialize<IEnumerable<Incident>>(jsonString);
                if (incidents != null && incidents.Any())
                {
                    allIncidents.AddRange(incidents);
                }
            }
            allIncidents = allIncidents.OrderBy(i => i.Name).ToList();
            var result = new
            {
                count = allIncidents.Count,
                incidents = allIncidents
            };
            return Ok(result);
        }






        //[HttpGet]
        //public async Task<IActionResult> GetIncidents()
        //{

        //var user = await CheckAuthorizationHeader(false);
        //if (user == null)
        //{
        //    return Unauthorized();
        //}

        //var incidents = _incidentBackgroundMonitorService.Incidents.ToList();
        //var settings = DataLayerHelper.RemedyForceSettingsHelper.Get();
        //foreach (var incident in incidents)
        //{
        //    incident.InstanceUrl = settings.InstanceUrl;
        //    incident.IncidentStatus = incident.GetIncidentRespondedStatus(user);
        //}

        //return Ok(JsonSerializer.Serialize(incidents));

        //}

        [HttpGet]
        public async Task<IActionResult> GetIncidentsInMonth(int year, int month)
        {
            var user = await CheckAuthorizationHeader(true);
            if (user == null)
            {
                return Unauthorized();
            }
            if (DataLayerHelper.RemedyForceIncidentsHelper is null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var from = new DateTime(year, month, 1);
            var to = from.AddMonths(1);
            var incidents = await DataLayerHelper
              .RemedyForceIncidentsHelper
              .GetIncidentsBetweenAsync(from, to);


            return Ok(JsonSerializer.Serialize(incidents));
        }

        [HttpGet]
        public async Task<IActionResult> GetIncidentsHistoric(bool openIncidents, int year, int period)
        {
            var user = await CheckAuthorizationHeader(true);
            if (user == null)
            {
                return Unauthorized();
            }
            if (DataLayerHelper.RemedyForceIncidentsHelper is null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            var incidents = await DataLayerHelper
                .RemedyForceIncidentsHelper
                .GetIncidentHistoric(openIncidents, year, period);
            return Ok(JsonSerializer.Serialize(incidents));



        }

        [HttpGet]
        public async Task<IActionResult> GetIncidentsBetween(DateTime from, DateTime to)
        {

            var user = await CheckAuthorizationHeader(true);
            if (user == null)
            {
                return Unauthorized();
            }
            if (DataLayerHelper.RemedyForceIncidentsHelper is null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var incidents = await DataLayerHelper
                .RemedyForceIncidentsHelper
                .GetIncidentsBetweenAsync(from.ToUniversalTime(), to.ToUniversalTime());


            return Ok(JsonSerializer.Serialize(incidents));
        }


        [HttpGet]
        public async Task<IActionResult> GetTasks(bool getOpenTasks)
        {
            var user = await CheckAuthorizationHeader(true);
            if (user == null)
            {
                return Unauthorized();
            }
            if (DataLayerHelper.RemedyForceTaskHelper is null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var tasks = await DataLayerHelper
                .RemedyForceTaskHelper
                .GetTasksAsync(getOpenTasks);


            return Ok(JsonSerializer.Serialize(tasks));
        }


        [HttpGet]
        public async Task<IActionResult> GetRemedyForceSettings()
        {
            var user = await CheckAuthorizationHeader(true);
            if (user == null)
            {
                return Unauthorized();
            }

            var settings = DataLayerHelper.RemedyForceSettingsHelper.Get();

            return Ok(JsonSerializer.Serialize(settings));
        }

        [HttpPost]
        public async Task<IActionResult> SaveSettings()
        {
            var user = await CheckAuthorizationHeader(true);
            if (user == null)
            {
                return Unauthorized();
            }
            var id = Request.Form.TryParseId();
            var instanceUrl = Request.Form.TryParseString("instanceUrl");
            var tokenEndpoint = Request.Form.TryParseString("tokenEndpoint");
            var userName = Request.Form.TryParseString("userName");
            var password = Request.Form.TryParseString("password");
            var clientId = Request.Form.TryParseString("clientId");
            var clientSecret = Request.Form.TryParseString("clientSecret");
            var token = Request.Form.TryParseString("token");
            var settings = DataLayerHelper.RemedyForceSettingsHelper.Get();
            settings.InstanceUrl = instanceUrl;
            settings.UserName = userName;
            settings.Password = password;
            settings.ClientId = clientId;
            settings.ClientSecret = clientSecret;
            settings.TokenEndpoint = tokenEndpoint;
            settings.Token = token;
            try
            {
                await DataLayerHelper.SaveAsync();
                return Ok(JsonSerializer.Serialize(settings));
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpPost]
        public async Task<IActionResult> UpdateToken()
        {
            var user = await CheckAuthorizationHeader(true);
            if (user == null)
            {
                return Unauthorized();
            }
            //var id = Request.Form.TryParseId();
            var instanceUrl = Request.Form.TryParseString("instanceUrl");
            var tokenEndpoint = Request.Form.TryParseString("tokenEndpoint");
            var userName = Request.Form.TryParseString("userName");
            var password = Request.Form.TryParseString("password");
            var clientId = Request.Form.TryParseString("clientId");
            var clientSecret = Request.Form.TryParseString("clientSecret");
            //var token = Request.Form.TryParseString("token");
            var settings = DataLayerHelper.RemedyForceSettingsHelper.Get();
            settings.InstanceUrl = instanceUrl;
            settings.UserName = userName;
            settings.Password = password;
            settings.ClientId = clientId;
            settings.ClientSecret = clientSecret;
            settings.TokenEndpoint = tokenEndpoint;

            try
            {
                await DataLayerHelper.RemedyForceSettingsHelper.UpdateTokenAsync(settings);
                await DataLayerHelper.SaveAsync();
                return Ok(JsonSerializer.Serialize(settings));
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
