using IncidentMonitor.Models;
using IncidentMonitor.Models.ServiceNow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IncidentMonitor.DataLayer.Helpers
{
    public class CarrixServiceNowHelper : ServiceNowHelper
    {

        #region Statics
        private static ServiceNowSettings GetProdServiceNowSettings()
        {
            return new ServiceNowSettings()
            {
                BaseUrl = "https://carrix.service-now.com",
                UserName = "hoist_integration@carrix.com",
                Password = "Kz$RlGC*u^K$Z<KF:N2izi>h,7<*-%C>9N),DN>F",
            };
        }
        #endregion


        public CarrixServiceNowHelper() : base(GetProdServiceNowSettings())
        {

        }

        public async Task<object> GetClosedTaks()
        {
            var endPoint = "sn_customerservice/case?sysparm_query=u_hoist_integration_status=active^state=3^ORstate=7";

            var (client, url) = GetHttpClient(endPoint);

            throw new NotImplementedException();
        }

        public async Task<string?> GetCaseSysIdByNumber(string number)
        {
            try
            {
                var endPoint = $"sn_customerservice/case?sysparm_query=number={number}&sysparm_fields=u_hoist_number,assignment_group,number,state";
                var (client, url) = GetHttpClient(endPoint);
                var response = await client.GetAsync(url);
                var repsonseText = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
                var result = JsonSerializer.Deserialize<ServiceNowArraySearch<ServiceNowCase>>(repsonseText);
                if (result != null && result.Result != null && result.Result.Any())
                {
                    var first = result.Result.FirstOrDefault();
                    if (first.State == "3")
                    {
                        return "";
                    }
                    return result.Result.FirstOrDefault()?.SysId;
                }

                return string.Empty;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<bool> UpdateServiceNowHoistNumber(string caseNumber,
            string newHoistNumber, string? comment)
        {
            var sysId = await GetCaseSysIdByNumber(caseNumber);
            if (string.IsNullOrEmpty(sysId))
            {
                return false;
            }

            try
            {
                var endPoint = $"sn_customerservice/case/{sysId}";
                var body = new
                {
                    u_hoist_number = newHoistNumber,
                    comments = string.IsNullOrWhiteSpace(comment) ?
                    null :
                    $"[code]{comment}[/code]"
                };
                var (client, url) = GetHttpClient(endPoint);
                var options = new JsonSerializerOptions()
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                };
                var serialized = JsonSerializer.Serialize(body, options);
                var stringContent = new StringContent(serialized, null, "application/json");
                var response = await client.PutAsync(url, stringContent);
                var repsonseText = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool> UpdateCaseComment(string caseNumber, string? comment)
        {
            var sysId = await GetCaseSysIdByNumber(caseNumber);
            if (string.IsNullOrEmpty(sysId) || string.IsNullOrWhiteSpace(comment))
            {
                return false;
            }

            try
            {
                var endPoint = $"sn_customerservice/case/{sysId}";
                var body = new
                {
                    comments = $"[code]{comment}[/code]"
                };
                var (client, url) = GetHttpClient(endPoint);
                var options = new JsonSerializerOptions()
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                };
                var serialized = JsonSerializer.Serialize(body, options);
                var stringContent = new StringContent(serialized, null, "application/json");
                var response = await client.PutAsync(url, stringContent);
                var repsonseText = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }


        public async Task<IEnumerable<ServiceNowActivity>> GetCaseActivitiesByNumber(string number)
        {
            var sysId = await GetCaseSysIdByNumber(number);
            if (string.IsNullOrEmpty(sysId))
            {
                return Enumerable.Empty<ServiceNowActivity>();
            }

            //var endPoint = $"sn_customerservice/case/{sysId}/activities";
            //var (client, url) = GetHttpClient(endPoint);
            //var response = await client.GetAsync(url);
            //var repsonseText = await response.Content.ReadAsStringAsync();
            //response.EnsureSuccessStatusCode();
            //var result = JsonSerializer.Deserialize<ServiceNowActivitySearch>(repsonseText);
            //return result?.Result.Entries ?? Enumerable.Empty<ServiceNowActivity>();
            return await GetCaseActivities(sysId);

        }


        public async Task<IEnumerable<ServiceNowActivity>> GetCaseActivities(string sysId)
        {
            var endPoint = $"sn_customerservice/case/{sysId}/activities";
            var (client, url) = GetHttpClient(endPoint);
            var response = await client.GetAsync(url);
            var repsonseText = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                return Enumerable.Empty<ServiceNowActivity>() ;
            }
            
            var result = JsonSerializer.Deserialize<ServiceNowActivitySearch>(repsonseText);
            return result?.Result.Entries ?? Enumerable.Empty<ServiceNowActivity>();

        }





        public async Task<ServiceNowCase?> GetCaseBySysId(string sysId)
        {
            var activities = await GetCaseActivities(sysId);

            var endPoint = $"sn_customerservice/case/{sysId}";
            var (client, url) = GetHttpClient(endPoint);
            var response = await client.GetAsync(url);
            var repsonseText = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            try
            {
                var result = JsonSerializer.Deserialize<ServiceNowObjectSearch<ServiceNowCase>>(repsonseText);
                var snowCase = result?.Result;
                if (snowCase != null)
                {
                    snowCase.Comments = activities;
                }
                return snowCase;
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public async Task<ServiceNowCase?> GetCaseByNumber(string number)
        {
            var sysId = await GetCaseSysIdByNumber(number);
            if (sysId == null)
            {
                return null;
            }
            return await GetCaseBySysId(sysId);
        }


    }
}
