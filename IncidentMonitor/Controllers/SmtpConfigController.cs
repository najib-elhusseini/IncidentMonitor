using IncidentMonitor.DataLayer.Helpers;
using IncidentMonitor.DataLayer.Models;
using IncidentMonitor.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace IncidentMonitor.Controllers
{
    public class SmtpConfigController : ApiControllerBase
    {
        public SmtpConfigController(UserManager<ApplicationUser> userManager, IDataLayerHelperEntity dataLayerHelper) : base(userManager, dataLayerHelper)
        {
        }


        [HttpGet]
        public async Task<IActionResult> GetSmtpConfig()
        {
            var user = await CheckAuthorizationHeader(true);
            if (user == null)
            {
                return Unauthorized();
            }
            var config = DataLayerHelper.SmtpConfigHelper.Get();
            return Ok(JsonSerializer.Serialize(config));

        }

        [HttpPost]
        public async Task<IActionResult> Save()
        {
            var user = await CheckAuthorizationHeader(true);
            if (user == null)
            {
                return Unauthorized();
            }
            var config = DataLayerHelper.SmtpConfigHelper.Get();
            var id = Request.Form.TryParseId();
            var smtpServer = Request.Form.TryParseString("smtpServer");
            var username = Request.Form.TryParseString("username");
            var password = Request.Form.TryParseString("password");
            var port = Request.Form.TryParseInt("port");
            var enableSSL = Request.Form.TryParseBool("enableSSL");


            config.SmtpClientName = smtpServer;
            config.UserName = username;
            config.Password = password;
            config.SmtpPort = port;
            config.EnableSsl = enableSSL ?? false;
            try
            {
                await DataLayerHelper.SaveAsync();
                return Ok(JsonSerializer.Serialize(config));

            }
            catch (Exception)
            {

                throw;
            }

        }


        [HttpPost]
        public async Task<IActionResult> Test()
        {
            var user = await CheckAuthorizationHeader(true);
            if (user == null)
            {
                return Unauthorized();
            }
            var config = new EmailConfiguration();
            var id = Request.Form.TryParseId();
            var smtpServer = Request.Form.TryParseString("smtpServer");
            var username = Request.Form.TryParseString("username");
            var password = Request.Form.TryParseString("password");
            var port = Request.Form.TryParseInt("port");
            var enableSSL = Request.Form.TryParseBool("enableSSL");


            config.Id = id;
            config.SmtpClientName = smtpServer;
            config.UserName = username;
            config.Password = password;
            config.SmtpPort = port;
            config.EnableSsl = enableSSL ?? false;
            var receiverEmailAddress = config.UserName;
            if (string.IsNullOrWhiteSpace(receiverEmailAddress))
            {
                return BadRequest();
            }
            var helper = new EmailHelper(config);

            try
            {
                await helper.SendEmailAsync("Test email", "Email sent with success", null, receiverEmailAddress);
                return Ok();

            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
