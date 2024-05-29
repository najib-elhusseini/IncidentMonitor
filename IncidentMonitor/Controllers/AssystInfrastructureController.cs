using IncidentMonitor.DataLayer.Helpers;
using IncidentMonitor.DataLayer.Models;
using IncidentMonitor.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace IncidentMonitor.Controllers
{
    public class AssystInfrastructureController : ApiControllerBase
    {
        public AssystInfrastructureController(UserManager<ApplicationUser> userManager,
             IDataLayerHelperEntity dataLayerHelper
             ) : base(userManager, dataLayerHelper)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartmentsAsync()
        {
            var user = await CheckAuthorizationHeader(true);
            if (user == null)
            {
                return Unauthorized();
            }

            if (DataLayerHelper.AssystInfrastructureHelper == null)
            {
                return BadRequest();
            }

            var departments = await DataLayerHelper
                .AssystInfrastructureHelper
                .GetDepartmentsAsync();

            return Ok(departments);

        }

        [HttpGet]
        public async Task<IActionResult> GetContactUsersAsync(
            [FromQuery] int[]? departmentIds,
            string? query,
            int? skip,
            int? top

            )
        {
            var user = await CheckAuthorizationHeader(true);
            if (user == null)
            {
                return Unauthorized();
            }

            if (DataLayerHelper.AssystInfrastructureHelper == null)
            {
                return BadRequest();
            }
            departmentIds ??= Array.Empty<int>();
            var ids = new List<int>();
            foreach (var departmentId in departmentIds)
            {
                if (departmentId == -1)
                {
                    continue;
                }
                ids.Add(departmentId);
            }

            try
            {
                var totalCount = await DataLayerHelper
                     .AssystInfrastructureHelper
                     .GetContactUsersCountAsync(ids.ToArray(), query);

                var contactUsers = await DataLayerHelper
                    .AssystInfrastructureHelper
                    .GetContactUsersAsync(ids.ToArray(), query, skip, top);
                var result = new
                {
                    totalCount,
                    contactUsers
                };

                var serialized = JsonSerializer.Serialize(result);
                return Ok(serialized);

            }
            catch (Exception ex)
            {

                throw;
            }

        }


        [HttpPost]
        public async Task<IActionResult> AssignContactUsersToDepartmentAsync()
        {

            var user = await CheckAuthorizationHeader(true);
            if (user == null)
            {
                return Unauthorized();
            }

            if (DataLayerHelper.AssystInfrastructureHelper == null)
            {
                return BadRequest();
            }
            var departmentId = Request.Form.TryParseInt("departmentId");
            if (departmentId == null)
            {
                return BadRequest();
            }
            var userIds = Request.Form.TryParseObject<IEnumerable<int>>("userIds");
            if (userIds==null)
            {
                return BadRequest();
            }
            foreach (var userId in userIds)
            {
                await DataLayerHelper.AssystInfrastructureHelper
                    .UpdateContactUserDepartmentAsync(userId, departmentId.Value);
            }
            return Ok();


        }





    }
}
