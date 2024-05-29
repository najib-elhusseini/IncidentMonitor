using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor.DataLayer.Helpers
{
    public class AssystHelper
    {

        public AssystHelper(AssystSettings settings)
        {
            Settings = settings;
        }

        public AssystSettings Settings { get; protected set; }

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
            if(acceptJson)
            {
                httpClient
                    .DefaultRequestHeaders.Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            var baseUrl = Settings.BaseUrl.TrimEnd('/');
            endPoint = endPoint.TrimStart('/');
            var url = $"{baseUrl}/assystREST/v2/{endPoint}";
            return (httpClient, url);
        }
    }
}
