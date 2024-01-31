using IncidentMonitor.DataLayer.Data;
using IncidentMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IncidentMonitor.DataLayer.Helpers
{
    public class RemedyForceSettingsHelper : EntityHelper<RemedyForceSetting, int>
    {
        public RemedyForceSettingsHelper(DataContext context)
            : base(context)
        {
        }

        public async Task<RemedyForceSetting?> GetRemedyForceSettingsAsync()
        {
            var settings = await Connection
                .Table<RemedyForceSetting>()
                .FirstOrDefaultAsync();            
            return settings;
        }

    
        public override async Task<int> UpdateAsync(RemedyForceSetting item)
        {
            var result = await Connection.UpdateAsync(item);
            
            return result;
            
        }

        public async Task UpdateTokenAsync(RemedyForceSetting setting)
        {
            var client = new HttpClient();
            var url = $"{setting.InstanceUrl}/{setting.TokenEndpoint}";

            var urlParams = $"?grant_type=password&client_id={setting.ClientId}&client_secret={setting.ClientSecret}&username={setting.UserName}&password={setting.Password}";
            url += urlParams;

            var message = new HttpRequestMessage(HttpMethod.Post, url) ;
            var response = await client.SendAsync(message) ;
            var responseText = await response.Content.ReadAsStringAsync();
            response?.EnsureSuccessStatusCode();
            var accessToken = JsonSerializer.Deserialize<AccessToken>(responseText) ;
            if(accessToken != null )
            {
                setting.Token = accessToken.Token;
                await UpdateAsync(setting);
            }
           
        }


    }
}
