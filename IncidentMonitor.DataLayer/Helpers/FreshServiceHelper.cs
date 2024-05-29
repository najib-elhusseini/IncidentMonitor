using IncidentMonitor.DataLayer.Helpers.Interfaces;
using IncidentMonitor.Models;
using IncidentMonitor.Models.Assyst;
using IncidentMonitor.Models.FreshService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.DataLayer.Helpers
{
    public class FreshServiceHelper : IApiHelper<FreshServiceSettings>
    {
        public FreshServiceSettings Settings { get; set; }

        public bool UseBasicAuth => true;

        public (HttpClient client, string url) GetHttpClient(string endPoint, bool acceptJson = true)
        {
            var httpClient = new HttpClient();
            if (UseBasicAuth)
            {
                var apiHelper = this as IApiHelper<FreshServiceSettings>;
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic", apiHelper.GetBasicAuth());
            }

            if (acceptJson)
            {
                httpClient
                    .DefaultRequestHeaders.Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            var baseUrl = Settings.BaseUrl.TrimEnd('/');
            endPoint = endPoint.TrimStart('/');
            var url = $"{baseUrl}/{endPoint}";
            return (httpClient, url);

        }

        #region Ctor
        public FreshServiceHelper()
        {
            Settings = new FreshServiceSettings()
            {
                BaseUrl = "https://diamondvogel.freshservice.com/api/v2",
                UserName = "BDJtj8ATw45f1e5BWzJo",
                Password = "",
            };
        }
        #endregion

        #region Agents

        class AgentResultSet
        {
            [JsonPropertyName("agent")]
            public Agent? Agent { get; set; }
        }


        public async Task<Agent?> GetAgentAsync(ulong agentId)
        {
            var endPoint = $"agents/{agentId}";
            var (client, url) = GetHttpClient(endPoint);
            var response = await client.GetAsync(url);
            var responseText = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<AgentResultSet>(responseText);
            return result?.Agent;
        }
        #endregion


        public async Task<FreshServiceTicket?> GetTicketById(string id)
        {
            try
            {
                var endPoint = $"tickets/{id}?include=conversations,requester";
                var (client, url) = GetHttpClient(endPoint);
                var response = await client.GetAsync(url);
                var responseText = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
                var freshServiceTicket = JsonSerializer.Deserialize<FreshServiceTicketResponse>(responseText);
                var ticket = freshServiceTicket?.Ticket;
                if(ticket!=null && ticket.Conversations!= null)
                {
                    ticket.Conversations = ticket.Conversations.OrderBy(ticket => ticket.Id).ToList();
                }

                return ticket;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task UpdateHoistIncident(string id, string hoistIncident)
        {
            var endPoint = $"tickets/{id}";
            var (client, url) = GetHttpClient(endPoint);
            var content = new
            {
                custom_fields = new
                {
                    hoist_incident = hoistIncident,
                }
            };
            try
            {
                var stringContent = new StringContent(JsonSerializer.Serialize(content), null, "application/json");
                var response = await client.PutAsync(url, stringContent);
                var responseText = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public class FreshServiceTicketResponse
        {
            [JsonPropertyName("ticket")]
            public FreshServiceTicket? Ticket { get; set; }
        }





        public async Task GetTicketConversations(string ticketId)
        {
            var endPoint = $"tickets/{ticketId}/conversations";
            var (client, url) = GetHttpClient(endPoint);
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
        }

        public async Task CreateTicketNote(string ticketId, string body)
        {
            var endPoint = $"tickets/{ticketId}/notes";
            var (client, url) = GetHttpClient(endPoint);
            var note = new FreshServiceConversation()
            {
                Private = false,
                Body = body
            };

            var options = new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            var serialized = JsonSerializer.Serialize(note, options);
            var content = new StringContent(serialized, null, "application/json");

            var response = await client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();

        }

    }
}
