using IncidentMonitor.DataLayer.Helpers;
using IncidentMonitor.DataLayer.Models;
using IncidentMonitor.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;
using System.Text.Json;

namespace IncidentMonitor.Controllers
{
    public class CompanySitesController : ApiControllerBase
    {
        public CompanySitesController(
            UserManager<ApplicationUser> userManager,
            IDataLayerHelperEntity dataLayerHelper) : base(userManager, dataLayerHelper)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var user = await CheckAuthorizationHeader(true);
            if (user == null)
            {
                return Unauthorized();
            }
            var sites = DataLayerHelper.CompanySitesHelper.GetAll().ToList();
            return Ok(JsonSerializer.Serialize(sites));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCompany()
        {
            var user = await CheckAuthorizationHeader(true);
            if (user == null)
            {
                return Unauthorized();
            }

            CompanySite? site = null;

            var id = Request.Form.TryParseId();
            if (id == 0)
            {
                site = new CompanySite();
                DataLayerHelper.CompanySitesHelper.Add(site);
            }
            else
            {
                site = DataLayerHelper.CompanySitesHelper.Get(id);
                if (site == null)
                {
                    return NotFound();
                }
            }

            var companyName = Request.Form.TryParseString("companyName");
            var shiftStartHours = Request.Form.TryParseInt("shiftStartHours") ?? 9;
            var shiftStartMinutes = Request.Form.TryParseInt("shiftStartMinutes") ?? 0;
            var shiftEndHours = Request.Form.TryParseInt("shiftEndHours") ?? 17;
            var shiftEndMinutes = Request.Form.TryParseInt("shiftEndMinutes") ?? 0;
            var enableAlarmNotifications = Request.Form.TryParseBool("enableAlarmNotifications") ?? false;
            var enableEmailNotifications = Request.Form.TryParseBool("enableEmailNotifications") ?? true;
            var tzOffset = Request.Form.TryParseInt("tzOffset") ?? 0;
            site.CompanyName = companyName;
            site.ShiftStartHours = shiftStartHours;
            site.ShiftStartMinutes = shiftStartMinutes;
            site.ShiftEndHours = shiftEndHours;
            site.ShiftEndMinutes = shiftEndMinutes;
            site.EnableAlarmNotifications = enableAlarmNotifications;
            site.EnableEmailNotifications = enableEmailNotifications;
            site.TimeZoneOffset = tzOffset;
            try
            {
                await DataLayerHelper.SaveAsync();
                return Ok(site.Id);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCompany(int companyId)
        {
            var user = await CheckAuthorizationHeader(true);
            if (user == null)
            {
                return Unauthorized();
            }



            var site = await DataLayerHelper.CompanySitesHelper.GetAsync(companyId);
            if (site == null)
            {
                return BadRequest();
            }
            var usersInSite = DataLayerHelper.UsersHelper.GetAll((u) => u.CompanySiteId == companyId).ToList();
            foreach (var siteUser in usersInSite)
            {
                siteUser.CompanySiteId = null;
            }
            try
            {
                DataLayerHelper.CompanySitesHelper.Remove(site);
                await DataLayerHelper.SaveAsync();
                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
