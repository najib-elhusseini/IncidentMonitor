using IncidentMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace IncidentMonitor.DataLayer.Helpers.Interfaces
{
    public interface IApiHelper<T> where T : IApiSettings
    {
        public T Settings { get; }

        public bool UseBasicAuth { get; }

        public virtual string GetBasicAuth()
        {
            var stringToConvert = Settings.UserName;
            if (!string.IsNullOrWhiteSpace(Settings.UserName) &&
                !string.IsNullOrWhiteSpace(Settings.Password))
            {
                stringToConvert = $"{Settings.UserName}:{Settings.Password}";
            }

            return Convert.ToBase64String(
                   Encoding.ASCII.GetBytes(stringToConvert));
        }


        public (HttpClient client, string url) GetHttpClient(string endPoint, bool acceptJson = true);
       

    }
}
