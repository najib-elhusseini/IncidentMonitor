using IncidentMonitor.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor.DataLayer.Helpers
{
    public abstract class RemedyForceApiHelper
    {
        protected RemedyForceSetting Settings { get; set; }
        protected int Version { get; set; } = 59;

        public RemedyForceApiHelper(RemedyForceSetting setting)
        {
            Settings = setting;
        }

        protected virtual string ConstructUrl(string endPoint) => $"{Settings.InstanceUrl}/{endPoint}";

        protected virtual string ConstructQuery(string query)
        {
            query = query.Replace(" ", "+");
            var endPoint = $"services/data/v{Version}.0/query?q={query}";
            return ConstructUrl(endPoint);
        }



        protected virtual string DateToRemedyForceDateLiteral(DateTime date)
        {
            static string FormatInteger(int i)
            {
                return i < 10 ? $"0{i}" : $"{i}";
            }          
            var dateLiteral = $"{date.Year}-{FormatInteger(date.Month)}-{FormatInteger(date.Day)}T{FormatInteger(date.Hour)}:{FormatInteger(date.Minute)}:{FormatInteger(date.Second)}Z";
            return dateLiteral;
        }

        protected virtual HttpClient GetHttpClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Settings.Token);
            client.DefaultRequestHeaders.Add("Cookie", "BrowserId=AfcJaId-Ee6n7EfsO5V9Jg; CookieConsentPolicy=0:1; LSKey-c$CookieConsentPolicy=0:1");
            return client;

        }




    }
}
