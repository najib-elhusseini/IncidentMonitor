using IncidentMonitor.Models;
using IncidentMonitor.Models.Assyst;
using IncidentMonitor.Models.Assyst.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IncidentMonitor.DataLayer.Helpers.AssystHelpers
{
    public class AssystInfrastructureHelper : AssystHelper
    {
        public AssystInfrastructureHelper(AssystSettings settings) : base(settings)
        {
        }

        public async Task<List<DepartmentDto>> GetDepartmentsAsync()
        {
            var endPoint = $"departments?fields=[id,sectionDepartmentName,sectionDepartmentShortCode,section[name]]";
            var (client, url) = GetHttpClient(endPoint);
            var response = await client.GetAsync(url);
            var responseText = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            var departments = JsonSerializer.Deserialize<IEnumerable<DepartmentDto>>(responseText);
            return departments?.ToList() ?? new List<DepartmentDto>();
        }

        public async Task<int> GetContactUsersCountAsync(IEnumerable<int> departmentIds, string? query)
        {
            var endPoint = $"contactUsers/searchResultCount";
            var searchParams = new List<string>();
            if (departmentIds.Any())
            {
                var departments = string.Join(",", departmentIds);
                searchParams.Add($"departmentId={departments}");
            }
            if (!string.IsNullOrWhiteSpace(query))
            {
                //name[like]=%25{query}&
                searchParams.Add($"emailAddress[like]=%25{query}");
            }
            if (searchParams.Any())
            {
                endPoint = $"{endPoint}?{string.Join('&', searchParams)}";
            }

            var (client, url) = GetHttpClient(endPoint);
            var response = await client.GetAsync(url);
            var responseText = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            var count = JsonSerializer.Deserialize<SearchResultCount>(responseText);
            return count.Value;
        }

        public async Task<List<ContactUserDto>> GetContactUsersAsync
            (IEnumerable<int> departmentIds, string? query,
            int? skip,
            int? top)
        {
            var endPoint = $"contactUsers";
            var searchParams = new List<string>
            {
                "fields=[*,id,name,emailAddress,departmentId,department[section[name]]]"
            };
            if (departmentIds.Any())
            {
                var departments = string.Join(",", departmentIds);
                searchParams.Add($"departmentId={departments}");
            }
            if (!string.IsNullOrWhiteSpace(query))
            {
                //name[like]=%25{query}&
                searchParams.Add($"emailAddress[like]=%25{query}");
            }
            if (skip != null && skip > 0)
            {
                searchParams.Add($"$skip={skip}");
            }
            if (top != null && top > 0)
            {
                searchParams.Add($"$top={top}");
            }

            if (searchParams.Any())
            {
                endPoint = $"{endPoint}?{string.Join('&', searchParams)}";
            }

            var (client, url) = GetHttpClient(endPoint);
            var response = await client.GetAsync(url);
            var responseText = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();

            var users = JsonSerializer.Deserialize<IEnumerable<ContactUserDto>>(responseText);
            users ??= new List<ContactUserDto>();
            return users.ToList();
        }

        public async Task UpdateContactUserDepartmentAsync(int userId, int departmentId)
        {
            var endPoint = $"contactUsers/{userId}";
            var (client, url) = GetHttpClient(endPoint);
            var body = new
            {
                departmentId
            };

            var serialized = JsonSerializer.Serialize(body);
            var stringContent = new StringContent(serialized, null, "application/json");

            var response = await client.PostAsync(url, stringContent);
            var responseText = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();


        }


    }
}
