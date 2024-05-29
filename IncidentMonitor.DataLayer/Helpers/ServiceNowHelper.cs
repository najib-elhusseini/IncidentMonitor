using IncidentMonitor.Models.ServiceNow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor.DataLayer.Helpers
{
    public abstract class ServiceNowHelper
    {
        public ServiceNowSettings Settings { get; set; }
        public ServiceNowHelper(ServiceNowSettings settings)
        {
            Settings = settings;
        }

        protected virtual string GetBasicAuth()
        {
            return Convert.ToBase64String(
               Encoding.ASCII.GetBytes($"{Settings.UserName}:{Settings.Password}"));
        }

        protected (HttpClient client, string url) GetHttpClient(string endPoint, bool acceptJson = true)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                   new AuthenticationHeaderValue("Basic", GetBasicAuth());
            if (acceptJson)
            {
                httpClient
                    .DefaultRequestHeaders.Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            var baseUrl = Settings.BaseUrl.TrimEnd('/');
            endPoint = endPoint.TrimStart('/');
            var url = $"{baseUrl}/api/{endPoint}";
            return (httpClient, url);
        }
    }
}
