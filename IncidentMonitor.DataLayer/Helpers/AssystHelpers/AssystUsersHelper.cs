using IncidentMonitor.Models;
using IncidentMonitor.Models.Assyst;
using IncidentMonitor.Models.Assyst.Users;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.DataLayer.Helpers
{
    public class AssystUsersHelper : AssystHelper
    {
        public AssystUsersHelper(AssystSettings settings) : base(settings)
        {
        }


        public async Task<int> GetUsersCountAsync(string searchArgs)
        {
            var endPoint = "/assystUsers/searchResultCount";
            if (!string.IsNullOrWhiteSpace(searchArgs))
            {
                endPoint = $"{endPoint}?{searchArgs}";
            }
            var (client, url) = GetHttpClient(endPoint);
            var response = await client.GetAsync(url);
            var responseText = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            var result = JsonSerializer.Deserialize<SearchResultCount?>(responseText);
            result ??= new SearchResultCount() { Value = 0 };
            return result.Value.Value;
        }

        private string GetUsersFeilds()
        {
            string[] arr = new string[]
            {
                "id",
                "name",
                "email",
                "emailAddress",
                "privilegeGroupMemberships[privilegeGroup[shortCode,name]]"
            };
            return string.Join(",", arr);
        }

        public async Task<IEnumerable<AssystUserDto>> GetUsersAsync(int skip, int top, string? query)
        {

            var endPoint = $"/assystUsers?fields={GetUsersFeilds()}";
            if (!string.IsNullOrEmpty(query))
            {
                var filterArgs = $"name[like]=%25{query}&shortCode[like]=%25{query}&emailAddress[like]=%25{query}";
                endPoint = $"{endPoint}&{filterArgs}";
            }
            endPoint = $"{endPoint}&$skip={skip}&$top={top}";

            var (client, url) = GetHttpClient(endPoint);
            var response = await client.GetAsync(url);
            var responseText = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            var result = JsonSerializer.Deserialize<IEnumerable<AssystUserDto>>(responseText);
            result ??= new List<AssystUserDto>();
            return result;
        }

        public async Task<IEnumerable<AssystUserDto>> GetUsersAsync(params string[] ids)
        {
            var idString = string.Join(",", ids);
            var endPoint = $"/assystUsers?id={idString}&fields={GetUsersFeilds()}";
            var (client, url) = GetHttpClient(endPoint);
            var response = await client.GetAsync(url);
            var responseText = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            var result = JsonSerializer.Deserialize<IEnumerable<AssystUserDto>>(responseText);
            result ??= new List<AssystUserDto>();
            return result;
        }

        public async Task<AssystUserDto?> GetUserAsync(int id)
        {
            var endPoint = $"/assystUsers/{id}";
            var (client, url) = GetHttpClient(endPoint);
            var response = await client.GetAsync(url);
            var responseText = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            var result = JsonSerializer.Deserialize<AssystUserDto>(responseText);
            return result;
        }

        public async Task<AssystUserDto?> GetUserAsync(string shortCode)
        {
            var endPoint = $"/assystUsers?shortCode={shortCode.ToUpper()}";
            var (client, url) = GetHttpClient(endPoint);
            var response = await client.GetAsync(url);
            var responseText = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            var result = JsonSerializer.Deserialize<IEnumerable<AssystUserDto>>(responseText);
            return result?.FirstOrDefault();
        }

        public async Task<AssystUserDto?> CreateAssystUserAsync(string email, string name)
        {
            var endPoint = "assystUsers";
            var (client, url) = GetHttpClient(endPoint);
            var payLoad = new
            {
                name = name,
                email = email,
                emailAddress = email,
                shortCode = email.ToUpper(),
                servDeptId = 1,
                roleId = 13,
            };
            var bodytext = JsonSerializer.Serialize(payLoad);
            var stringContent = new StringContent(bodytext, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, stringContent);
            var responseText = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            var assystUserDto = JsonSerializer.Deserialize<AssystUserDto>(responseText);
            return assystUserDto;
        }

        public async Task<SecondaryServDeptDto?> AddSecondaryServiceDepartment(AssystUserDto assystUserDto, int servDeptId)
        {
            var endPoint = "secondaryServiceDepartments";
            var (client, url) = GetHttpClient(endPoint);
            var payLoad = new
            {
                servDeptId,
                assystUserId = assystUserDto.Id
            };
            var bodytext = JsonSerializer.Serialize(payLoad);
            var stringContent = new StringContent(bodytext, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, stringContent);
            var responseText = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            var servDept = JsonSerializer.Deserialize<SecondaryServDeptDto>(responseText);
            return servDept;
        }

        public async Task<PrivilegeUserDto?> AddToPriviliegeGroup(AssystUserDto assystUserDto, int privilegeGroupId)
        {
            var endPoint = "privilegeUsers";
            var (client, url) = GetHttpClient(endPoint);
            var payLoad = new
            {
                privilegeGroupId,
                assystUserId = assystUserDto.Id
            };
            var bodytext = JsonSerializer.Serialize(payLoad);
            var stringContent = new StringContent(bodytext, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, stringContent);
            var responseText = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            var group = JsonSerializer.Deserialize<PrivilegeUserDto>(responseText);
            return group;

        }

        public async Task<CsgMembershipDto?> AddToCsg(AssystUserDto assystUserDto, int csgId)
        {
            var endPoint = "csgMemberships";
            var (client, url) = GetHttpClient(endPoint);
            var payLoad = new
            {
                csgId,
                assystUserId = assystUserDto.Id
            };
            var bodytext = JsonSerializer.Serialize(payLoad);
            var stringContent = new StringContent(bodytext, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, stringContent);
            var responseText = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            var membershipDto = JsonSerializer.Deserialize<CsgMembershipDto>(responseText);
            return membershipDto;
        }






    }
}
