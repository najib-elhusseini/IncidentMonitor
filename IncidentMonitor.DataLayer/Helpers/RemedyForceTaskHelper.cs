using IncidentMonitor.Models;
using IncidentMonitor.Models.RemedyForce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IncidentMonitor.DataLayer.Helpers
{
    public class RemedyForceTaskHelper : RemedyForceApiHelper
    {
        public RemedyForceTaskHelper(RemedyForceSetting setting) : base(setting)
        {
        }

        private string BuildSelectProps()
        {
            var props = new List<string>()
            {
                "Id",
                "Name",
                "CreatedDate",
                "CreatedBy.Email",
                "CreatedBy.Name",
                "BMCServiceDesk__Client_Account__c",
                "BMCServiceDesk__Client_ID__c",
                "BMCServiceDesk__taskDescription__c",
                "BMCServiceDesk__shortDescription__c",
                "Incident_Title__c",
                "BMCServiceDesk__FKIncident__c",
                "Incident_Account__c",
                "BA_Responsible_Incident_Staff__c",
                "BMCServiceDesk__FKStatus__r.Name",
                "bmcservicedesk__fkurgency__r.Name",
                "bmcservicedesk__fkimpact__r.Name",
                "(SELECT ID,Name,CreatedDate,BMCServiceDesk__note__c FROM bmcservicedesk__task_history__r)",
                "bmcservicedesk__fkopenby__r.FirstName,bmcservicedesk__fkopenby__r.LastName,bmcservicedesk__fkopenby__r.Name,bmcservicedesk__fkopenby__r.UserName",
                "BMCServiceDesk__FKIncident__r.CRIM__c",
                "BMCServiceDesk__FKIncident__r.Name",
                "BMCServiceDesk__FKIncident__r.BMCServiceDesk__Queue__c",
                "BMCServiceDesk__FKIncident__r.BMCServiceDesk__queueName__c",
                "BMCServiceDesk__FKIncident__r.BMCServiceDesk__Status_ID__c",

            };
            string result = "";
            foreach (var property in props)
            {
                result += property + ",";
            }
            result = result.TrimEnd(',');
            return result;
        }


        public async Task<List<RemedyForceTask>> GetTasksAsync(bool getOpenTasks = false)
        {
            string props = BuildSelectProps();
            // for clarity
            StringBuilder sb = new();
            sb.Append($"SELECT {props} FROM BMCServiceDesk__Task__c");
            sb.Append(" where bmcservicedesk__fkstatus__r.Name  ");
            if (getOpenTasks)
            {
                sb.Append(" NOT ");
            }
            sb.Append(" IN ");
            sb.Append('(');
            sb.Append("'CANCELLED','CLOSED','COMPLETED'");
            sb.Append(')');
            sb.Append(" AND BMCServiceDesk__FKIncident__c<>null ");
            sb.Append(" AND BMCServiceDesk__FKIncident__r.BMCServiceDesk__Status_ID__c ");
            if (getOpenTasks)
            {
                sb.Append(" NOT ");
            }
            sb.Append(" IN ");
            sb.Append('(');
            sb.Append("'CANCELLED','CLOSED','COMPLETED'");
            sb.Append(')');
            sb.Append("AND CreatedDate>2022-01-01T00:00:00.000Z ORDER BY CreatedDate ASC");

            var query = sb.ToString();
            var url = base.ConstructQuery(query);


            var client = GetHttpClient();
            var response = await client.GetAsync(url);
            var responseText = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();


            var result = JsonSerializer.Deserialize<RemedyForceQuerySet<RemedyForceTask>>(responseText);
            if (result == null)
            {
                return new List<RemedyForceTask>();
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

        private async Task<RemedyForceQuerySet<RemedyForceTask>?> GetNextRecord(string nextRecordUrl)
        {
            var url = base.ConstructUrl(nextRecordUrl);
            var client = GetHttpClient();
            var response = await client.GetAsync(url);
            var responseText = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RemedyForceQuerySet<RemedyForceTask>>(responseText);
            return result;
        }
    }
}
