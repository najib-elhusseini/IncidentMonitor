using IncidentMonitor.DataLayer.Helpers;

using IncidentMonitor.DataLayer.Models;
using IncidentMonitor.Models;
using IncidentMonitor.Models.RemedyForce;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace IncidentMonitor.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ApiControllerBase : Controller
    {
        const string _bearer = "Bearer";

        #region Token Key
        private const string loginSecretKey = "p1+h0m9nGe?,6>pI>s>H-5A@HhKl,]*gsM19%Xh1!hYc<slk?'XrY7^:0}%dNX4";

        public static string LoginSecretKey => loginSecretKey;

        public static byte[] EncodedLoginSecretKey => Encoding.ASCII.GetBytes(LoginSecretKey);
        #endregion


        public UserManager<ApplicationUser> UserManager { get; protected set; }

        public IDataLayerHelperEntity DataLayerHelper { get; protected set; }

        public ApiControllerBase(UserManager<ApplicationUser> userManager, IDataLayerHelperEntity dataLayerHelper)
        {
            DataLayerHelper = dataLayerHelper;
            UserManager = userManager;
        }

        protected async Task<string> GetUserToken(ApplicationUser user)
        {
            var secret = new SymmetricSecurityKey(EncodedLoginSecretKey);
            var credentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
            var claims = await GetClaims(user);
            JwtSecurityToken tokenOptions =
                new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return token;
        }

        protected async Task<List<Claim>> GetClaims(ApplicationUser user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName ?? ""),
                new Claim(ClaimTypes.Email, user.Email ?? ""),
                new Claim("Id", user.Id),
                new Claim(ClaimTypes.Expiration, DateTime.Now.AddDays(3).ToString()),

            };
            var appUser = await UserManager.FindByNameAsync(user?.UserName ?? "");
            if (appUser == null)
            {
                throw new NotImplementedException();
            }
            var roles = await UserManager.GetRolesAsync(appUser);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;

        }

        public IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            if (jwt == null)
            {
                return new List<Claim>();
            }
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];

            var jsonBytes = ParseBase64WithoutPadding(payload);

            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));
            return claims;
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }

        protected async Task<ApplicationUser?> TryTokenLoginAsync(string loginToken)
        {
            var claims = ParseClaimsFromJwt(loginToken);
            foreach (var claim in claims)
            {
                if (claim.Type == ClaimTypes.Expiration)
                {
                    var result = DateTime.TryParse(claim.Value, out DateTime value);
                    if (result == false)
                    {
                        return null;
                    }
                    var now = DateTime.Now;
                    if (now > value)
                    {
                        return null;
                    }

                }
                if (claim.Type == "Id")
                {
                    var user = await UserManager.FindByIdAsync(claim.Value);
                    //user = DataLayerHelper.UserHelper.Get(user.Id);
                    return user;
                }
            }

            return null;
        }

        protected async Task<ApplicationUser?> TryTokenLoginAsync(string loginToken, bool adminOnly = false)
        {
            if (string.IsNullOrEmpty(loginToken))
            {
                return null;
            }
            var user = await TryTokenLoginAsync(loginToken);

            if (user == null)
            {
                return null;
            }
            var isInAdminRole = await UserManager.IsInRoleAsync(user, ApplicationRole._adminRoleName);
            user.IsAdmin = isInAdminRole;
            if (adminOnly)
            {

                if (!isInAdminRole)
                {
                    return null;
                }
            }

            return user;
        }

        protected async Task<ApplicationUser?> CheckAuthorizationHeader(bool adminOnly = false)
        {


            var authHeader = Request.Headers.Authorization.ToString();
            if (authHeader.StartsWith(_bearer))
            {
                var splitted = authHeader.Split(_bearer);
                if (splitted.Count() < 2)
                {
                    return null;
                }
                authHeader = splitted[1].Trim();
            }

            var user = await TryTokenLoginAsync(authHeader, adminOnly);
            return user;


        }


        protected async Task<string> EncodeUserInfo(ApplicationUser user, string token)
        {
            var isInAdminRole = await UserManager.IsInRoleAsync(user, ApplicationRole._adminRoleName);
            if (isInAdminRole)
            {
                user.IsAdmin = true;
            }

            var userViewModel = new
            {
                id = user.Id,
                firstName = user.FirstName,
                lastName = user.LastName,
                email = user.Email,
                userName = user.UserName ?? "",
                fullName = user.FullName,
                token,
                isAdmin = user.IsAdmin,
                roleName = user.RoleName,
                lastLoginDate = DateTime.Now,
                loginValidUntil = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"),
                companySiteId = user.CompanySiteId ?? 0,
                isActive = user.IsActive,
                enableEmailNotifications = user.EnableEmailNotifications,
                shiftStartHours = user.ShiftStartHours,
                shiftEndHours = user.ShiftEndHours,
                shiftStartMinutes = user.ShiftStartMinutes,
                shiftEndMinutes = user.ShiftEndMinutes,
                tzOffset = user.TimeZoneOffset,
            };


            return JsonSerializer.Serialize(userViewModel);
        }
    }


    public static class FormExtensions
    {
        public static int? TryParseInt(this IFormCollection form, string key)
        {
            var value = form[key].ToString();
            if (int.TryParse(value, out int i))
            {
                return i;
            }
            return null;
        }

        public static int TryParseId(this IFormCollection form)
        {
            return TryParseInt(form, "id") ?? 0;
        }

        public static bool? TryParseBool(this IFormCollection form, string key)
        {
            var value = form[key].ToString();
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }
            // to cater for web's input check
            if (value is "on" || value is "ON")
            {
                return true;
            }
            if (bool.TryParse(value, out bool i))
            {
                return i;
            }
            return null;
        }

        public static double? TryParseDouble(this IFormCollection form, string key)
        {
            var value = form[key].ToString();
            if (string.IsNullOrWhiteSpace(value)) return null;

            var result = double.TryParse(value, out double dbl);
            if (result) return dbl;
            return null;
        }

        public static DateTime? TryParseDateTime(this IFormCollection form, string key)
        {
            var stringValue = TryParseString(form, key);
            if (stringValue == null) return null;
            var result = DateTime.TryParse(stringValue, out DateTime value);
            if (result)
            {
                return value;
            }
            return null;
        }

        public static string? TryParseString(this IFormCollection form, string key)
        {
            var str = form[key];
            if (string.IsNullOrWhiteSpace(str))
            {
                return null;
            }
            //var value = str.ToString();
            //if (string.IsNullOrWhiteSpace(value))
            //{
            //    return null;
            //}
            return str;

        }

        public static T? TryParseObject<T>(this IFormCollection form, string key)
        {
            var value = form[key].ToString();
            if (string.IsNullOrWhiteSpace(value))
            {
                return default;
            }

            var parsed = JsonSerializer.Deserialize<T>(value);
            return parsed;

        }

        //public static T? TryParseEnum<T>(this IFormCollection form, string key) where T : struct
        //{
        //    if (!typeof(T).IsEnum)
        //    {
        //        throw new NotSupportedException($"Type {typeof(T).Name} is not an enum type.");
        //    }
        //    var value = TryParseInt(form, key);
        //    if (value == null)
        //    {
        //        return null;
        //    }

        //    T? result = (T?)Enum.ToObject(typeof(T?), value);

        //    return result;

        //}



    }
}
