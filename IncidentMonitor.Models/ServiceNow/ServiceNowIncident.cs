using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.ServiceNow
{
    public class ServiceNowIncident
    {
        [JsonPropertyName("parent")]
        public string? Parent { get; set; }

        [JsonPropertyName("caused_by")]
        public string? CausedBy { get; set; }

        [JsonPropertyName("watch_list")]
        public string? WatchList { get; set; }

        [JsonPropertyName("upon_reject")]
        public string? UponReject { get; set; }

        [JsonPropertyName("sys_updated_on")]
        public string? SysUpdatedOn { get; set; }

        [JsonPropertyName("origin_table")]
        public string? OriginTable { get; set; }

        [JsonPropertyName("approval_history")]
        public string? ApprovalHistory { get; set; }

        [JsonPropertyName("number")]
        public string? Number { get; set; }

        [JsonPropertyName("state")]
        public string? State { get; set; }

        [JsonPropertyName("u_affected_business_aplication")]
        public string? UAffectedBusinessAplication { get; set; }

        [JsonPropertyName("sys_created_by")]
        public string? SysCreatedBy { get; set; }

        [JsonPropertyName("knowledge")]
        public string? Knowledge { get; set; }

        [JsonPropertyName("order")]
        public string? Order { get; set; }

        [JsonPropertyName("cmdb_ci")]
        public string? CmdbCi { get; set; }

        [JsonPropertyName("delivery_plan")]
        public string? DeliveryPlan { get; set; }

        [JsonPropertyName("contract")]
        public string? Contract { get; set; }

        [JsonPropertyName("impact")]
        public string? Impact { get; set; }

        [JsonPropertyName("active")]
        public string? Active { get; set; }

        [JsonPropertyName("work_notes_list")]
        public string? WorkNotesList { get; set; }

        [JsonPropertyName("u_vendor")]
        public string? UVendor { get; set; }

        [JsonPropertyName("u_preferred_contact_number")]
        public string? UPreferredContactNumber { get; set; }

        [JsonPropertyName("priority")]
        public string? Priority { get; set; }

        [JsonPropertyName("sys_domain_path")]
        public string? SysDomainPath { get; set; }

        [JsonPropertyName("business_duration")]
        public string? BusinessDuration { get; set; }

        [JsonPropertyName("group_list")]
        public string? GroupList { get; set; }

        [JsonPropertyName("approval_set")]
        public string? ApprovalSet { get; set; }

        [JsonPropertyName("u_vendor_details")]
        public string? UVendorDetails { get; set; }

        [JsonPropertyName("universal_request")]
        public string? UniversalRequest { get; set; }

        [JsonPropertyName("short_description")]
        public string? ShortDescription { get; set; }

        [JsonPropertyName("correlation_display")]
        public string? CorrelationDisplay { get; set; }

        [JsonPropertyName("work_start")]
        public string? WorkStart { get; set; }

        [JsonPropertyName("additional_assignee_list")]
        public string? AdditionalAssigneeList { get; set; }

        [JsonPropertyName("u_location_impacted")]
        public string? ULocationImpacted { get; set; }

        [JsonPropertyName("notify")]
        public string? Notify { get; set; }

        [JsonPropertyName("service_offering")]
        public string? ServiceOffering { get; set; }

        [JsonPropertyName("sys_class_name")]
        public string? SysClassName { get; set; }

        [JsonPropertyName("closed_by")]
        public string? ClosedBy { get; set; }

        [JsonPropertyName("follow_up")]
        public string? FollowUp { get; set; }

        [JsonPropertyName("parent_incident")]
        public string? ParentIncident { get; set; }

        [JsonPropertyName("reopened_by")]
        public string? ReopenedBy { get; set; }

        [JsonPropertyName("reassignment_count")]
        public string? ReassignmentCount { get; set; }

        [JsonPropertyName("assigned_to")]
        public AssignedTo? AssignedTo { get; set; }

        [JsonPropertyName("sla_due")]
        public string? SlaDue { get; set; }

        [JsonPropertyName("comments_and_work_notes")]
        public string? CommentsAndWorkNotes { get; set; }

        [JsonPropertyName("escalation")]
        public string? Escalation { get; set; }

        [JsonPropertyName("upon_approval")]
        public string? UponApproval { get; set; }

        [JsonPropertyName("correlation_id")]
        public string? CorrelationId { get; set; }

        [JsonPropertyName("x_591777_integrati_external_id")]
        public string? X591777IntegratiExternalId { get; set; }

        [JsonPropertyName("u_in_person_visit")]
        public string? UInPersonVisit { get; set; }

        [JsonPropertyName("made_sla")]
        public string? MadeSla { get; set; }

        [JsonPropertyName("child_incidents")]
        public string? ChildIncidents { get; set; }

        [JsonPropertyName("hold_reason")]
        public string? HoldReason { get; set; }

        [JsonPropertyName("task_effective_number")]
        public string? TaskEffectiveNumber { get; set; }

        [JsonPropertyName("resolved_by")]
        public string? ResolvedBy { get; set; }

        [JsonPropertyName("sys_updated_by")]
        public string? SysUpdatedBy { get; set; }

        [JsonPropertyName("opened_by")]
        public OpenedBy? OpenedBy { get; set; }

        [JsonPropertyName("user_input")]
        public string? UserInput { get; set; }

        [JsonPropertyName("sys_created_on")]
        public string? SysCreatedOn { get; set; }

        [JsonPropertyName("sys_domain")]
        public SysDomain? SysDomain { get; set; }

        [JsonPropertyName("route_reason")]
        public string? RouteReason { get; set; }

        [JsonPropertyName("calendar_stc")]
        public string? CalendarStc { get; set; }

        [JsonPropertyName("closed_at")]
        public string? ClosedAt { get; set; }

        [JsonPropertyName("business_service")]
        public string? BusinessService { get; set; }

        [JsonPropertyName("business_impact")]
        public string? BusinessImpact { get; set; }

        [JsonPropertyName("rfc")]
        public string? Rfc { get; set; }

        [JsonPropertyName("time_worked")]
        public string? TimeWorked { get; set; }

        [JsonPropertyName("expected_start")]
        public string? ExpectedStart { get; set; }

        [JsonPropertyName("opened_at")]
        public string? OpenedAt { get; set; }

        [JsonPropertyName("u_contact_method_s")]
        public string? UContactMethodS { get; set; }

        [JsonPropertyName("work_end")]
        public string? WorkEnd { get; set; }

        [JsonPropertyName("caller_id")]
        public CallerId? CallerId { get; set; }

        [JsonPropertyName("reopened_time")]
        public string? ReopenedTime { get; set; }

        [JsonPropertyName("resolved_at")]
        public string? ResolvedAt { get; set; }

        [JsonPropertyName("subcategory")]
        public string? Subcategory { get; set; }

        [JsonPropertyName("work_notes")]
        public string? WorkNotes { get; set; }

        [JsonPropertyName("close_code")]
        public string? CloseCode { get; set; }

        [JsonPropertyName("assignment_group")]
        public AssignmentGroup? AssignmentGroup { get; set; }

        [JsonPropertyName("business_stc")]
        public string? BusinessStc { get; set; }

        [JsonPropertyName("cause")]
        public string? Cause { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("u_vendor_ticket")]
        public string? UVendorTicket { get; set; }

        [JsonPropertyName("origin_id")]
        public string? OriginId { get; set; }

        [JsonPropertyName("calendar_duration")]
        public string? CalendarDuration { get; set; }

        [JsonPropertyName("close_notes")]
        public string? CloseNotes { get; set; }

        [JsonPropertyName("sys_id")]
        public string? SysId { get; set; }

        [JsonPropertyName("contact_type")]
        public string? ContactType { get; set; }

        [JsonPropertyName("incident_state")]
        public string? IncidentState { get; set; }

        [JsonPropertyName("urgency")]
        public string? Urgency { get; set; }

        [JsonPropertyName("problem_id")]
        public string? ProblemId { get; set; }

        [JsonPropertyName("company")]
        public Company? Company { get; set; }

        [JsonPropertyName("activity_due")]
        public string? ActivityDue { get; set; }

        [JsonPropertyName("severity")]
        public string? Severity { get; set; }

        [JsonPropertyName("comments")]
        public string? Comments { get; set; }

        [JsonPropertyName("approval")]
        public string? Approval { get; set; }

        [JsonPropertyName("due_date")]
        public string? DueDate { get; set; }

        [JsonPropertyName("sys_mod_count")]
        public string? SysModCount { get; set; }

        [JsonPropertyName("reopen_count")]
        public string? ReopenCount { get; set; }

        [JsonPropertyName("sys_tags")]
        public string? SysTags { get; set; }

        [JsonPropertyName("x_591777_integrati_source_location")]
        public string? X591777IntegratiSourceLocation { get; set; }

        [JsonPropertyName("location")]
        public string? Location { get; set; }

        [JsonPropertyName("category")]
        public string? Category { get; set; }
    }

    public class AssignedTo
    {
        [JsonPropertyName("link")]
        public string? Link { get; set; }

        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }

    public class OpenedBy
    {
        [JsonPropertyName("link")]
        public string? Link { get; set; }

        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }

    public class SysDomain
    {
        [JsonPropertyName("link")]
        public string? Link { get; set; }

        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }

    public class CallerId
    {
        [JsonPropertyName("link")]
        public string? Link { get; set; }

        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }

    public class AssignmentGroup
    {
        [JsonPropertyName("link")]
        public string? Link { get; set; }

        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }

    public class Company
    {
        [JsonPropertyName("link")]
        public string? Link { get; set; }

        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }

}
