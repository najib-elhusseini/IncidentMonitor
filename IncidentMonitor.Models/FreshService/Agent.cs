using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.FreshService
{
    public class Agent
    {
        [JsonPropertyName("active")]
        public bool? Active { get; set; }

        [JsonPropertyName("address")]
        public object? Address { get; set; }

        [JsonPropertyName("auto_assign_status_changed_at")]
        public string? AutoAssignStatusChangedAt { get; set; }

        [JsonPropertyName("auto_assign_tickets")]
        public bool? AutoAssignTickets { get; set; }

        [JsonPropertyName("background_information")]
        public object? BackgroundInformation { get; set; }

        [JsonPropertyName("can_see_all_tickets_from_associated_departments")]
        public bool? CanSeeAllTicketsFromAssociatedDepartments { get; set; }

        [JsonPropertyName("created_at")]
        public string? CreatedAt { get; set; }

        [JsonPropertyName("custom_fields")]
        public CustomFields? CustomFields { get; set; }

        [JsonPropertyName("department_ids")]
        public IEnumerable<ulong>? DepartmentIds { get; set; }

        [JsonPropertyName("department_names")]
        public IEnumerable<string?>? DepartmentNames { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("external_id")]
        public string? ExternalId { get; set; }

        [JsonPropertyName("first_name")]
        public string? FirstName { get; set; }

        [JsonPropertyName("has_logged_in")]
        public bool? HasLoggedIn { get; set; }

        [JsonPropertyName("id")]
        public ulong? Id { get; set; }

        [JsonPropertyName("job_title")]
        public string? JobTitle { get; set; }

        [JsonPropertyName("language")]
        public string? Language { get; set; }

        [JsonPropertyName("last_active_at")]
        public string? LastActiveAt { get; set; }

        [JsonPropertyName("last_login_at")]
        public string? LastLoginAt { get; set; }

        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }

        [JsonPropertyName("location_id")]
        public object? LocationId { get; set; }

        [JsonPropertyName("location_name")]
        public string? LocationName { get; set; }

        [JsonPropertyName("mobile_phone_number")]
        public object? MobilePhoneNumber { get; set; }

        [JsonPropertyName("occasional")]
        public bool? Occasional { get; set; }

        [JsonPropertyName("reporting_manager_id")]
        public object? ReportingManagerId { get; set; }

        [JsonPropertyName("roles")]
        public IEnumerable<object>? Roles { get; set; }

        [JsonPropertyName("scoreboard_level_id")]
        public int? ScoreboardLevelId { get; set; }

        [JsonPropertyName("scoreboard_points")]
        public object? ScoreboardPoints { get; set; }

        [JsonPropertyName("signature")]
        public string? Signature { get; set; }

        [JsonPropertyName("time_format")]
        public string? TimeFormat { get; set; }

        [JsonPropertyName("time_zone")]
        public string? TimeZone { get; set; }

        [JsonPropertyName("updated_at")]
        public string? UpdatedAt { get; set; }

        [JsonPropertyName("vip_user")]
        public bool? VipUser { get; set; }

        [JsonPropertyName("work_phone_number")]
        public string? WorkPhoneNumber { get; set; }

        [JsonPropertyName("workspace_ids")]
        public IEnumerable<uint>? WorkspaceIds { get; set; }

        [JsonPropertyName("workspace_info")]
        public object? WorkspaceInfo { get; set; }

        [JsonPropertyName("member_of")]
        public IEnumerable<ulong>? MemberOf { get; set; }

        [JsonPropertyName("observer_of")]
        public object? ObserverOf { get; set; }

        [JsonPropertyName("member_of_pending_approval")]
        public object? MemberOfPendingApproval { get; set; }

        [JsonPropertyName("observer_of_pending_approval")]
        public object? ObserverOfPendingApproval { get; set; }
    }


}
