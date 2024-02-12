using IncidentMonitor.DataLayer.Helpers;
using IncidentMonitor.Services;
using Microsoft.AspNetCore.Mvc;

namespace IncidentMonitor.Controllers
{
    public class RemedyForceIncidentsController : ApiControllerBase
    {
        private readonly IncidentBackgroundMonitorService _incidentBackgroundMonitorService;
        public RemedyForceIncidentsController(
           
            IncidentBackgroundMonitorService incidentBackgroundMonitorService
            )
            
        {
            _incidentBackgroundMonitorService = incidentBackgroundMonitorService;
        }

        [HttpGet]
        public IActionResult GetTest()
        {

            return Ok(_incidentBackgroundMonitorService.Count);
        }
    }
}
