using IncidentMonitor.Models;
using IncidentMonitor.Models.RemedyForce;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                "CreatedBy.Email",
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
                "BMCServiceDesk__Queue__c",
                "BMCServiceDesk__Client_Account__c",
                "BMCServiceDesk__respondedDateTime__c",
                "BMCServiceDesk__Launch_console__c",
                "(SELECT ID,Name,CreatedDate,CreatedBy.Id,CreatedBy.Username,BMCServiceDesk__note__c,BMCServiceDesk__description__c,BMCServiceDesk__RichTextNote__c FROM bmcservicedesk__incident_histories__r)",
                "(SELECT ID,Name,CreatedDate FROM Attachments)",
                "BMCServiceDesk__closeDateTime__c",// Added from here
                "BMCServiceDesk__dueDateTime__c",
                "BMCServiceDesk__openDateTime__c",
                "BMCServiceDesk__Closed_By__c",
                "BMCServiceDesk__TotalWorkTime__c",
                "System_Category_del__c",
                "IFS_Functional_Flow__c",
                "Customer_Case_ID__c",
                "Environment__c",
                "Total_Billable_Time__c",
                "Track__c",
                "Customer_Request_Type__c",
                "Cost_Center__c",
                "IFS_Case_ID__c",
                "bmcservicedesk__fkopenby__r.FirstName,bmcservicedesk__fkopenby__r.LastName,bmcservicedesk__fkopenby__r.Name,bmcservicedesk__fkopenby__r.UserName"

            };
            string result = "";
            foreach (var property in props)
            {
                result += property + ",";
            }
            result = result.TrimEnd(',');
            return result;
        }

        private (DateTime dateStart, DateTime dateEnd) GetPeriodLimits(int period, int year)
        {
            var result = period switch
            {
                1 => (new DateTime(year, 1, 1), new DateTime(year, 3, 31)),
                2 => (new DateTime(year, 4, 1), new DateTime(year, 6, 30)),
                3 => (new DateTime(year, 7, 1), new DateTime(year, 9, 30)),
                4 => (new DateTime(year, 10, 1), new DateTime(year, 12, 31)),
                _ => (new DateTime(year, 1, 1), new DateTime(year, 3, 31)),
            };
            return result;
        }

        public async Task<IEnumerable<Incident>> GetIncidentHistoric(bool openIncidents, int year, int period)
        {
            var (dateStart, dateEnd) = GetPeriodLimits(period, year);

            //var dateStart = new DateTime(year, period == 1 ? 1 : 6, 1);
            //var dateEnd = new DateTime(year, period == 1 ? 6 : 12, period == 1 ? 30 : 31);

            var dateLiteralStart = DateToRemedyForceDateLiteral(dateStart);
            var dateLiteralEnd = DateToRemedyForceDateLiteral(dateEnd);
            var props = BuildSelectProps();
            var statusParam = $"BMCServiceDesk__FKStatus__r.name {(openIncidents ? "NOT IN" : "IN")}  ('CLOSED','COMPLETED')";
            var dateParam = $"CreatedDate >= {dateLiteralStart} and CreatedDate<= {dateLiteralEnd}";
            var query = $"select {props} from BMCServiceDesk__Incident__c WHERE {statusParam} and {dateParam} ORDER BY CreatedDate ";
            return await GetIncidentsInternalAsync(query, true);
        }



        /// <summary>
        /// Returns the Remedy Force Incidents between a specific date range
        /// </summary>
        /// <param name="from">From date in UTC format</param>
        /// <param name="to">To date in UTC format</param>
        /// <returns></returns>
        public async Task<IEnumerable<Incident>> GetIncidentsBetweenAsync(DateTime from, DateTime to)
        {
            var dateLiteralFrom = DateToRemedyForceDateLiteral(from);
            var dateLiteralTo = DateToRemedyForceDateLiteral(to);
            var props = BuildSelectProps();
            var query = $"select {props} from BMCServiceDesk__Incident__c WHERE CreatedDate >= {dateLiteralFrom} AND CreatedDate<={dateLiteralTo} ORDER BY CreatedDate LIMIT 500";
            return await GetIncidentsInternalAsync(query, true);
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
            return await GetIncidentsInternalAsync(query);
        }

        private async Task<List<Incident>> GetUnseenRecords(string props, string dateLiteral)
        {

            var query = $"select {props} from BMCServiceDesk__Incident__c where CreatedDate >= {dateLiteral} AND bmcservicedesk__fkstatus__r.Name <> 'CLOSED' AND bmcservicedesk__fkstatus__r.Name <> 'COMPLETED' ORDER BY CreatedDate DESC ";
            return await GetIncidentsInternalAsync(query);
        }

        private async Task<List<Incident>> GetIncidentsInternalAsync(string query)
        {
            var url = base.ConstructQuery(query);
            var client = GetHttpClient();
            var response = await client.GetAsync(url);
            var responseText = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            var result = JsonSerializer.Deserialize<RemedyForceQuerySet<Incident>>(responseText);
            var records = result?.Records.ToList() ?? Enumerable.Empty<Incident>();
            return records.ToList();
        }

        private async Task<List<Incident>> GetIncidentsInternalAsync(string query, bool getNextRecord)
        {
            var url = base.ConstructQuery(query);
            var client = GetHttpClient();
            var response = await client.GetAsync(url);
            var responseText = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            var result = JsonSerializer.Deserialize<RemedyForceQuerySet<Incident>>(responseText);
            if (result == null)
            {
                return new List<Incident>();
            }
            if (result.Done)
            {
                return result.Records.ToList();
            }

            var records = result.Records.ToList();
            do
            {
                result = await GetNextRecord(result.NextRecordsUrl!);
                if (result == null)
                {
                    break;
                }
                records.AddRange(result.Records);
                if (result.NextRecordsUrl == null)
                {
                    break;
                }

            } while (result.Done == false);

            return records;
        }

        private async Task<RemedyForceQuerySet<Incident>?> GetNextRecord(string nextRecordUrl)
        {
            var url = base.ConstructUrl(nextRecordUrl);
            var client = GetHttpClient();
            var response = await client.GetAsync(url);
            var responseText = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RemedyForceQuerySet<Incident>>(responseText);
            return result;
        }









    }
}
