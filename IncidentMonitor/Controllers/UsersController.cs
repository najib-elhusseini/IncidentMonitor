using IncidentMonitor.DataLayer.Helpers;
using IncidentMonitor.DataLayer.Models;
using IncidentMonitor.Models;
using IncidentMonitor.Models.Assyst;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Text.Json;

namespace IncidentMonitor.Controllers
{
    public class UsersController : ApiControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UsersController(
            IDataLayerHelperEntity dataLayerHelper,
            SignInManager<ApplicationUser> signInManager,
            IWebHostEnvironment webHostEnvironment,
            UserManager<ApplicationUser> userManager
            ) : base(userManager, dataLayerHelper)
        {
            _signInManager = signInManager;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> Login()
        {
            var userName = Request.Form["username"].ToString();
            var password = Request.Form["password"].ToString();
            if (string.IsNullOrEmpty(userName) ||
                string.IsNullOrEmpty(password))
            {
                return BadRequest("Invalid username or password");
            }
            var user = await UserManager.FindByNameAsync(userName);
            if (user == null)
            {
                return Unauthorized();
            }

            var result = await _signInManager
                .CheckPasswordSignInAsync(user, password, false);
            if (!result.Succeeded)
            {
                return Unauthorized();
            }

            var token = await GetUserToken(user);
            var encoded = await EncodeUserInfo(user, token);

            return Ok(encoded);

        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var user = await CheckAuthorizationHeader(true);
            if (user == null)
            {
                return Unauthorized();
            }
            var users = DataLayerHelper.UsersHelper.GetAll()
                .OrderBy(u => u.UserName)
                .Select(u => new ApplicationUserViewModel(u));
            return Ok(users);
        }



        [HttpGet]
        public async Task<IActionResult> GetUser(string uid)
        {
            var user = await CheckAuthorizationHeader(true);
            if (user == null)
            {
                return Unauthorized();
            }

            user = DataLayerHelper.UsersHelper.Get(uid);
            if (user == null)
            {
                return NotFound();
            }

            var userData = new
            {
                id = user.Id,
                firstName = user.FirstName,
                lastName = user.LastName,
                email = user.Email,
                userName = user.UserName ?? "",
                fullName = user.FullName,
                token = "",
                isAdmin = user.IsAdmin,
                roleName = user.RoleName,
                isActive = user.IsActive,
                enableEmailNotifications = user.EnableEmailNotifications,
                companySiteId = user.CompanySiteId,
                shiftStartHours = user.ShiftStartHours,
                shiftStartMinutes = user.ShiftStartMinutes,
                shiftEndHours = user.ShiftEndHours,
                shiftEndMinutes = user.ShiftEndMinutes,
                tzOffset = user.TimeZoneOffset,
                companySiteName = user.CompanySiteName,
            };

            return Ok(userData);

        }

        [HttpPost]
        public async Task<IActionResult> SaveUser()
        {
            var user = await CheckAuthorizationHeader(true);
            if (user == null)
            {
                return Unauthorized();
            }


            var id = Request.Form["id"].ToString();
            ApplicationUser? contextUser = null;
            if (!string.IsNullOrEmpty(id))
            {
                contextUser = await DataLayerHelper.UsersHelper.GetAsync(id);
                if (contextUser == null)
                {
                    return NotFound();
                }
            }
            var firstName = Request.Form["firstName"].ToString();
            var lastName = Request.Form["lastName"].ToString();
            var email = Request.Form["email"].ToString();
            var userName = Request.Form["username"].ToString();
            var receivesNotifications = Request.Form.TryParseBool("receivesNotifications");
            var isActive = Request.Form.TryParseBool("isActive");
            var isAdmin = Request.Form.TryParseBool("isAdmin");
            var companyId = Request.Form.TryParseInt("companyId");
            var shiftStartHours = Request.Form.TryParseInt("shiftStartHours") ?? 9;
            var shiftStartMinutes = Request.Form.TryParseInt("shiftStartMinutes") ?? 0;
            var shiftEndHours = Request.Form.TryParseInt("shiftEndHours") ?? 17;
            var shiftEndMinutes = Request.Form.TryParseInt("shiftEndMinutes") ?? 0;
            var tzOffset = Request.Form.TryParseInt("tzOffset") ?? 0;

            if (contextUser == null)
            {
                contextUser = new ApplicationUser();
                DataLayerHelper.UsersHelper.Add(contextUser);

            }
            contextUser.FirstName = firstName;
            contextUser.LastName = lastName;
            contextUser.Email = email;
            contextUser.UserName = userName;
            contextUser.EnableEmailNotifications = receivesNotifications ?? false;
            contextUser.IsActive = isActive;
            contextUser.CompanySiteId = companyId;
            contextUser.TimeZoneOffset = tzOffset;
            contextUser.ShiftStartHours = shiftStartHours;
            contextUser.ShiftStartMinutes = shiftStartMinutes;
            contextUser.ShiftEndHours = shiftEndHours;
            contextUser.ShiftEndMinutes = shiftEndMinutes;
            contextUser.IsAdmin = isAdmin == true;


            var isInAdminRole = await UserManager.IsInRoleAsync(contextUser, ApplicationRole._adminRoleName);

            try
            {
                await DataLayerHelper.SaveAsync();
                if (isAdmin == true && !isInAdminRole)
                {
                    var result = await UserManager.AddToRoleAsync(contextUser, ApplicationRole._adminRoleName);
                }
                if (isAdmin == false && isInAdminRole)
                {
                    await UserManager.RemoveFromRoleAsync(contextUser, ApplicationRole._adminRoleName);
                }

                return Ok(contextUser.Id);

            }
            catch (Exception ex)
            {

                throw;
            }



        }

        [HttpPost]
        public async Task<IActionResult> ImportUser(int id)
        {
            var user = await CheckAuthorizationHeader(true);
            if (user == null)
            {
                return Unauthorized();
            }
            if (DataLayerHelper.AssystUsersHelper == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var assystUser = await DataLayerHelper.AssystUsersHelper.GetUserAsync(id);
            if (assystUser == null)
            {
                return NotFound();
            }
            try
            {
                var appUser = await DataLayerHelper.UsersHelper.Add(assystUser);
                await DataLayerHelper.SaveAsync();
                var isAdmin = await UserManager.IsInRoleAsync(appUser, ApplicationRole._adminRoleName);
                var isUser = await UserManager.IsInRoleAsync(appUser, ApplicationRole._userRoleName);
                if (!isAdmin && !isUser)
                {
                    var result = await UserManager.AddToRoleAsync(user, ApplicationRole._userRoleName);
                }
                return Ok(appUser.Id);
            }
            catch (Exception)
            {

                throw;
            }






        }

        [HttpPost]
        public async Task<IActionResult> AddAssystUserAsync()
        {
            var user = await CheckAuthorizationHeader(true);
            if (user == null)
            {
                return Unauthorized();
            }
            if (DataLayerHelper.AssystUsersHelper == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var email = Request.Form.TryParseString("email");
            var userName = Request.Form.TryParseString("name");
            if (email == null || userName == null)
            {
                return BadRequest();
            }

            var assystUser = await DataLayerHelper.AssystUsersHelper.GetUserAsync(email);
            if (assystUser != null)
            {
                return Conflict("User already exists");
            }

            assystUser = await DataLayerHelper.AssystUsersHelper.CreateAssystUserAsync(email, userName);
            if (assystUser != null)
            {
                await DataLayerHelper.AssystUsersHelper.AddSecondaryServiceDepartment(assystUser, 32);
                await DataLayerHelper.AssystUsersHelper.AddSecondaryServiceDepartment(assystUser, 34);

                // standard analyst
                await DataLayerHelper.AssystUsersHelper.AddToPriviliegeGroup(assystUser, 1);

                // "csgId": 1 == IFS Support
                await DataLayerHelper.AssystUsersHelper.AddToCsg(assystUser, 1);

            }



            return Ok(assystUser);

        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword()
        {

            var user = await CheckAuthorizationHeader(true);
            if (user == null)
            {
                return Unauthorized();
            }


            var id = Request.Form["id"].ToString();
            var password = Request.Form["password"].ToString();
            if (string.IsNullOrEmpty(password))
            {
                return BadRequest();
            }
            ApplicationUser? contextUser = await DataLayerHelper.UsersHelper.GetAsync(id);
            if (contextUser == null)
            {
                return NotFound();
            }

            var result = await UserManager.RemovePasswordAsync(contextUser);
            if (result.Succeeded)
            {
                result = await UserManager.AddPasswordAsync(contextUser, password);
            }

            if (result.Succeeded)
            {
                return Ok();
            }

            return StatusCode(StatusCodes.Status500InternalServerError);


        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser()
        {
            var user = await CheckAuthorizationHeader(true);
            if (user == null)
            {
                return Unauthorized();
            }
            var id = Request.Form["id"].ToString();
            ApplicationUser? contextUser = await DataLayerHelper.UsersHelper.GetAsync(id);
            if (contextUser == null)
            {
                return NotFound();
            }
            if (contextUser.UserName == "admin")
            {
                return BadRequest("Admin user cannot be deleted");
            }

            var result = await UserManager.DeleteAsync(contextUser);
            if (result.Succeeded)
            {
                return Ok(contextUser.Id);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);



        }


        [HttpGet]
        public async Task<IActionResult> GetAssystHelpDeskUsersAsync()
        {
            var user = await CheckAuthorizationHeader(false);
            if (user == null)
            {
                return Unauthorized();
            }
            if (DataLayerHelper.AssystUsersHelper == null)
            {
                return BadRequest();
            }
            if (user.ExternalId != null && user.IsAdmin == false)
            {
                var id = int.Parse(user.ExternalId);
                var assystUser = await DataLayerHelper.AssystUsersHelper.GetUserAsync(id);
                if (assystUser == null)
                {
                    return NotFound();
                }
                return Ok(new List<AssystUserDto>() { assystUser });
            }
            var users = DataLayerHelper.UsersHelper.GetAssystHelpDeskUsers();

            var ids = new List<string>();
            foreach (var _user in users)
            {
                if (_user.ExternalId == null)
                {
                    continue;
                }
                ids.Add(_user.ExternalId);
            }

            var assystUsers = await DataLayerHelper.AssystUsersHelper.GetUsersAsync(ids.ToArray());

            return Ok(assystUsers);

        }

        #region Assyst Users

        [HttpGet]
        public async Task<IActionResult> GetAssystUsersCount(string? query = null)
        {
            var user = await CheckAuthorizationHeader(true);
            if (user == null)
            {
                return Unauthorized();
            }
            if (DataLayerHelper.AssystUsersHelper == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var filterArgs = string.Empty;
            if (!string.IsNullOrEmpty(query))
            {
                filterArgs = $"name[like]=%25{query}&shortCode[like]=%25{query}&emailAddress[like]=%25{query}";
            }
            var count = await DataLayerHelper.AssystUsersHelper.GetUsersCountAsync(filterArgs);
            return Ok(count);
        }

        [HttpGet]
        public async Task<IActionResult> GetAssystUsers(int skip, int top, string? query = null)
        {
            var user = await CheckAuthorizationHeader(true);
            if (user == null)
            {
                return Unauthorized();
            }
            if (DataLayerHelper.AssystUsersHelper == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var filterArgs = string.Empty;
            if (!string.IsNullOrEmpty(query))
            {
                filterArgs = $"name[like]=%25{query}&shortCode[like]=%25{query}&emailAddress[like]=%25{query}";
            }
            var count = await DataLayerHelper.AssystUsersHelper.GetUsersCountAsync(filterArgs);

            var users = await DataLayerHelper.AssystUsersHelper.GetUsersAsync(skip, top, query);
            var result = new
            {
                count,
                users
            };

            return Ok(JsonSerializer.Serialize(result));

        }

        #endregion



    }

}
