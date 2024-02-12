using IncidentMonitor.DataLayer.Helpers;
using Microsoft.AspNetCore.Mvc;
namespace IncidentMonitor.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ApiControllerBase : Controller
    {
        

        public ApiControllerBase()
        {
            
        }
    }
}
