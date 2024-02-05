using IncidentMonitor.Models;
using IncidentMonitor.Models.RemedyForce;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.DataLayer.Helpers
{
    public class RemedyForceIncidentsHelper : RemedyForceApiHelper
    {
        public RemedyForceIncidentsHelper(RemedyForceSetting setting)
            : base(setting)
        {

        }

        private string BuildSelectProps()
        {
            var props = new List<string>()
            {
                "Id",
                "OwnerId",
                //"Owner.Id",
                "Name",
                "CreatedBy.Name",
                "CreatedDate",
                "bmcservicedesk__fkclient__r.username",
                "bmcservicedesk__fkaccount__r.Name",
                "bmcservicedesk__fkstatus__r.Name",
                "bmcservicedesk__fkurgency__r.Name",
                "bmcservicedesk__fkimpact__r.Name",
                "title__c",                
                "BMCServiceDesk__shortDescription__c",
                "BMCServiceDesk__incidentDescription__c",
                "BMCServiceDesk__incidentResolution__c",
                "BMCServiceDesk__queueName__c",
                "BMCServiceDesk__Client_Account__c",
                "BMCServiceDesk__respondedDateTime__c",
                "(SELECT ID,Name,CreatedDate,BMCServiceDesk__note__c,BMCServiceDesk__description__c,BMCServiceDesk__RichTextNote__c FROM bmcservicedesk__incident_histories__r)",
                "(SELECT ID,Name,CreatedDate FROM Attachments)"

            };
            string result = "";
            foreach (var property in props)
            {
                result += property + ",";
            }
            result = result.TrimEnd(',');
            return result;
        }

        public async Task<IEnumerable<Incident>> GetIncidents(DateTime date, int maxRecordsBefore = 10)
        {
            //return new List<Incident>();
            if (string.IsNullOrEmpty(Settings.Token))
            {
                throw new NotImplementedException();
            }
            var dateLiteral = DateToRemedyForceDateLiteral(date);
            var props = BuildSelectProps();

            try
            {
               
                var seenRecords = await GetSeenRecords(props, dateLiteral, maxRecordsBefore);
                var unseenRecords = await GetUnseenRecords(props, dateLiteral);

                var records = unseenRecords.Concat(seenRecords);              
                return records;
            }
            catch (Exception)
            {

                throw;
            }

        }

        private async Task<List<Incident>> GetSeenRecords(string props, string dateLiteral, int limit)
        {            
            var query = $"select {props} from BMCServiceDesk__Incident__c where CreatedDate < {dateLiteral} AND bmcservicedesk__fkstatus__r.Name <> 'CLOSED' AND bmcservicedesk__fkstatus__r.Name <> 'COMPLETED'  ORDER BY CreatedDate DESC  LIMIT {limit}";
            var url = base.ConstructQuery(query);
            var client = GetHttpClient();
            var response = await client.GetAsync(url);
            var responseText = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            var result = JsonSerializer.Deserialize<RemedyForceQuerySet<Incident>>(responseText);
            var seenRecords = result?.Records.ToList() ?? Enumerable.Empty<Incident>();
            foreach (var record in seenRecords)
            {
                record.IsSeen = true;
            }
            return seenRecords.ToList();

        }

        private async Task<List<Incident>> GetUnseenRecords(string props, string dateLiteral)
        {

            var query = $"select {props} from BMCServiceDesk__Incident__c where CreatedDate >= {dateLiteral} AND bmcservicedesk__fkstatus__r.Name <> 'CLOSED' AND bmcservicedesk__fkstatus__r.Name <> 'COMPLETED' ORDER BY CreatedDate DESC";
            var url = base.ConstructQuery(query);
            var client = GetHttpClient();
            var response = await client.GetAsync(url);
            var responseText = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            var result = JsonSerializer.Deserialize<RemedyForceQuerySet<Incident>>(responseText);
            var unseenRecords = result?.Records.ToList() ?? Enumerable.Empty<Incident>();
            return unseenRecords.ToList();
        }






    }
}
