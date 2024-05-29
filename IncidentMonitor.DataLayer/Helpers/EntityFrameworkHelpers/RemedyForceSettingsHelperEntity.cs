using IncidentMonitor.DataLayer.Data;
using IncidentMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IncidentMonitor.DataLayer.Helpers
{
    public class RemedyForceSettingsHelperEntity : EntityHelperEntity<RemedyForceSetting, int>
    {
        public RemedyForceSettingsHelperEntity(ApplicationDbContext context) : base(context)
        {
        }

        public override RemedyForceSetting? Get(int id, IEnumerable<string>? includedProperties = null)
        {
            throw new NotSupportedException();
        }

        public RemedyForceSetting Get()
        {
            var settings = Context.RemedyForceSettings.FirstOrDefault();
            if (settings == null)
            {
                settings ??= new RemedyForceSetting()
                {
                    InstanceUrl = "https://hgts.my.salesforce.com",
                    TokenEndpoint = "services/oauth2/token",
                    UserName = "integrations@hoist.tech",
                };
                Context.RemedyForceSettings.Add(settings);
                Context.SaveChanges();
            }
            return settings;
        }

        public override void Update(RemedyForceSetting entity)
        {
            throw new NotImplementedException();
        }


        public async Task UpdateTokenAsync(RemedyForceSetting setting)
        {
            var client = new HttpClient();
            var url = $"{setting.InstanceUrl}/{setting.TokenEndpoint}";

            var urlParams = $"?grant_type=password&client_id={setting.ClientId}&client_secret={setting.ClientSecret}&username={setting.UserName}&password={setting.Password}";
            url += urlParams;

            var message = new HttpRequestMessage(HttpMethod.Post, url);
            var response = await client.SendAsync(message);
            var responseText = await response.Content.ReadAsStringAsync();
            response?.EnsureSuccessStatusCode();
            var accessToken = JsonSerializer.Deserialize<AccessToken>(responseText);
            if (accessToken != null)
            {
                setting.Token = accessToken.Token;
                //await UpdateAsync(setting);
            }

        }
    }
}
