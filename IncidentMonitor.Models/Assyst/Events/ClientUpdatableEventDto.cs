using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.Assyst
{


    /// <summary>
    /// Represents the properties of an event.
    /// </summary>

    public class ClientUpdatableEventDto : AssystBaseCSGDto
    {

        /// <summary>
        /// Defines the list of additional affected users associated with an event.
        /// Data Type : contactUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="Defines the list of additional affected users associated with an event." axios:resourcePath="/contactUsers" maxOccurs="unbounded" minOccurs="0" name="additionalAffectedUsers" nillable="true" type="contactUserDto"/>
        /// </summary>

        [JsonPropertyName("additionalAffectedUsers")]
        public object? AdditionalAffectedUsers { get; set; }


        [JsonPropertyName("additionalAffectedUsersCount")]
        public int? AdditionalAffectedUsersCount { get; set; }


        [JsonPropertyName("additionalRequirements")]
        public string? AdditionalRequirements { get; set; }


        /// <summary>
        /// 
        /// Data Type : contactUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/contactUsers" minOccurs="0" name="affectedUser" type="contactUserDto"/>
        /// </summary>

        [JsonPropertyName("affectedUser")]
        public object? AffectedUser { get; set; }


        [JsonPropertyName("affectedUserEmail")]
        public string? AffectedUserEmail { get; set; }


        [JsonPropertyName("affectedUserId")]
        public int? AffectedUserId { get; set; }


        /// <summary>
        /// Setting only the affected user name signifies an anonymous user.
        /// </summary>

        [JsonPropertyName("affectedUserName")]
        public string? AffectedUserName { get; set; }


        [JsonPropertyName("affectedUserTelephone")]
        public string? AffectedUserTelephone { get; set; }


        [JsonPropertyName("affectedUserTelephoneExtension")]
        public string? AffectedUserTelephoneExtension { get; set; }


        /// <summary>
        /// 
        /// Data Type : servDeptDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceDepartments" minOccurs="0" name="assignedServDept" type="servDeptDto"/>
        /// </summary>
        /// 
        [JsonPropertyName("assignedServDept")]
        public ServDeptDto? AssignedServDept { get; set; }

        [JsonPropertyName("assignedServDeptId")]
        public int? AssignedServDeptId { get; set; }


        /// <summary>
        /// 
        /// Data Type : assystUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assystUsers" minOccurs="0" name="assignedUser" type="assystUserDto"/>
        /// </summary>

        [JsonPropertyName("assignedUser")]
        public AssystUserDto? AssignedUser { get; set; }


        [JsonPropertyName("assignedUserId")]
        public int? AssignedUserId { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="attachedProcess"/>
         */


        [JsonPropertyName("attachedProcessId")]
        public int? AttachedProcessId { get; set; }


        [JsonPropertyName("authorisationDate")]
        public DateTime? AuthorisationDate { get; set; }


        /// <summary>
        /// 
        /// Data Type : contactUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/contactUsers" minOccurs="0" name="authorisingUser" type="contactUserDto"/>
        /// </summary>

        [JsonPropertyName("authorisingUser")]
        public object? AuthorisingUser { get; set; }


        [JsonPropertyName("authorisingUserId")]
        public int? AuthorisingUserId { get; set; }


        [JsonPropertyName("callbackRemark")]
        public string? CallbackRemark { get; set; }


        [JsonPropertyName("callbackRequired")]
        public bool? CallbackRequired { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="category"/>
         */


        [JsonPropertyName("categoryId")]
        public int? CategoryId { get; set; }


        [JsonPropertyName("chargeFlag")]
        public int? ChargeFlag { get; set; }


        /// <summary>
        /// 
        /// Data Type : chargeFlagTypesEnum
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="chargeFlagEnum" type="chargeFlagTypesEnum"/>
        /// </summary>

        [JsonPropertyName("chargeFlagEnum")]
        public object? ChargeFlagEnum { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="costCentre"/>
         */


        [JsonPropertyName("costCentreId")]
        public int? CostCentreId { get; set; }


        /// <summary>
        /// 
        /// Data Type : phaseDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/phases" minOccurs="0" name="currentPhase" type="phaseDto"/>
        /// </summary>

        [JsonPropertyName("currentPhase")]
        public object? CurrentPhase { get; set; }


        [JsonPropertyName("dateLogged")]
        public DateTime? DateLogged { get; set; }
     

        [JsonPropertyName("department")]
        public DepartmentDto? Department { get; set; }


        [JsonPropertyName("departmentId")]
        public int? DepartmentId { get; set; }


        [JsonPropertyName("downFlag")]
        public bool? DownFlag { get; set; }


        /// <summary>
        /// 
        /// Data Type : durationDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="estimate" type="durationDto"/>
        /// </summary>

        [JsonPropertyName("estimate")]
        public object? Estimate { get; set; }


        [JsonPropertyName("eventCost")]
        public double? EventCost { get; set; }


        /// <summary>
        /// 
        /// Data Type : csgDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/csgs" minOccurs="0" name="filteringCsg" type="csgDto"/>
        /// </summary>

        [JsonPropertyName("filteringCsg")]
        public object? FilteringCsg { get; set; }


        [JsonPropertyName("filteringCsgId")]
        public int? FilteringCsgId { get; set; }
        

        [JsonPropertyName("impact")]
        public SeriousnessDto? Impact { get; set; }


        [JsonPropertyName("impactId")]
        public int? ImpactId { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="importProfile"/>
         */


        [JsonPropertyName("importProfileId")]
        public int? ImportProfileId { get; set; }


        [JsonPropertyName("incDataVersion")]
        public int? IncDataVersion { get; set; }


        /// <summary>
        /// 
        /// Data Type : itemDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/items" minOccurs="0" name="itemA" type="itemDto"/>
        /// </summary>

        [JsonPropertyName("itemA")]
        public object? ItemA { get; set; }


        [JsonPropertyName("itemAId")]
        public int? ItemAId { get; set; }


        /// <summary>
        /// 
        /// Data Type : itemDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/items" minOccurs="0" name="itemB" type="itemDto"/>
        /// </summary>

        [JsonPropertyName("itemB")]
        public object? ItemB { get; set; }


        [JsonPropertyName("itemBId")]
        public int? ItemBId { get; set; }


        [JsonPropertyName("justification")]
        public string? Justification { get; set; }


        /// <summary>
        /// 
        /// Data Type : linkedItemGroupDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/linkedItemGroups" maxOccurs="unbounded" minOccurs="0" name="linkedItemGroups" nillable="true" type="linkedItemGroupDto"/>
        /// </summary>

        [JsonPropertyName("linkedItemGroups")]
        public object? LinkedItemGroups { get; set; }


        [JsonPropertyName("linkedItemsCount")]
        public int? LinkedItemsCount { get; set; }


        /// <summary>
        /// 
        /// Data Type : phaseEventDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/phaseEvents" maxOccurs="unbounded" minOccurs="0" name="phaseEvents" nillable="true" type="phaseEventDto"/>
        /// </summary>

        [JsonPropertyName("phaseEvents")]
        public object? PhaseEvents { get; set; }

        
        [JsonPropertyName("priority")]
        public PriorityDto? Priority { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="priorityDerived"/>
         */


        [JsonPropertyName("priorityDerivedId")]
        public int? PriorityDerivedId { get; set; }


        [JsonPropertyName("priorityId")]
        public int? PriorityId { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="project"/>
         */


        [JsonPropertyName("projectId")]
        public int? ProjectId { get; set; }


        [JsonPropertyName("quantity")]
        public double? Quantity { get; set; }


        [JsonPropertyName("receiveSourceType")]
        public int? ReceiveSourceType { get; set; }


        /// <summary>
        /// 
        /// Data Type : receiveSourceTypesEnum
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="receiveSourceTypeEnum" type="receiveSourceTypesEnum"/>
        /// </summary>

        [JsonPropertyName("receiveSourceTypeEnum")]
        public object? ReceiveSourceTypeEnum { get; set; }


        /// <summary>
        /// 
        /// Data Type : contactUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/contactUsers" minOccurs="0" name="reportingUser" type="contactUserDto"/>
        /// </summary>

        [JsonPropertyName("reportingUser")]
        public object? ReportingUser { get; set; }


        [JsonPropertyName("reportingUserId")]
        public int? ReportingUserId { get; set; }


        [JsonPropertyName("reportingUserName")]
        public string? ReportingUserName { get; set; }


        [JsonPropertyName("reportingUserTelephone")]
        public string? ReportingUserTelephone { get; set; }


        [JsonPropertyName("reportingUserTelephoneExtension")]
        public string? ReportingUserTelephoneExtension { get; set; }


        [JsonPropertyName("requiredByDate")]
        public DateTime? RequiredByDate { get; set; }


        /// <summary>
        /// 
        /// Data Type : servDeptDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceDepartments" minOccurs="0" name="responsibleBServDept" type="servDeptDto"/>
        /// </summary>

        [JsonPropertyName("responsibleBServDept")]
        public object? ResponsibleBServDept { get; set; }


        [JsonPropertyName("responsibleBServDeptId")]
        public int? ResponsibleBServDeptId { get; set; }


        /// <summary>
        /// 
        /// Data Type : assystUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assystUsers" minOccurs="0" name="responsibleBUser" type="assystUserDto"/>
        /// </summary>

        [JsonPropertyName("responsibleBUser")]
        public object? ResponsibleBUser { get; set; }


        [JsonPropertyName("responsibleBUserId")]
        public int? ResponsibleBUserId { get; set; }


        /// <summary>
        /// 
        /// Data Type : servDeptDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceDepartments" minOccurs="0" name="responsibleServDept" type="servDeptDto"/>
        /// </summary>

        [JsonPropertyName("responsibleServDept")]
        public object? ResponsibleServDept { get; set; }


        [JsonPropertyName("responsibleServDeptId")]
        public int? ResponsibleServDeptId { get; set; }


        /// <summary>
        /// 
        /// Data Type : assystUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assystUsers" minOccurs="0" name="responsibleUser" type="assystUserDto"/>
        /// </summary>

        [JsonPropertyName("responsibleUser")]
        public object? ResponsibleUser { get; set; }


        [JsonPropertyName("responsibleUserId")]
        public int? ResponsibleUserId { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="room"/>
         */


        [JsonPropertyName("roomId")]
        public int? RoomId { get; set; }


        [JsonPropertyName("scheduledEndDate")]
        public DateTime? ScheduledEndDate { get; set; }


        [JsonPropertyName("scheduledStartDate")]
        public DateTime? ScheduledStartDate { get; set; }


        /// <summary>
        /// When an event is created from another event this property defines the event which is the seed.  Property/Event is also used when creating tasks outwith processes.  The seed event determines what the new task is linked to and, depending on the client, what SLA is to be initially defaulted
        /// Data Type : eventDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="When an event is created from another event this property defines the event which is the seed.  Property/Event is also used when creating tasks outwith processes.  The seed event determines what the new task is linked to and, depending on the client, what SLA is to be initially defaulted" axios:resourcePath="/events" minOccurs="0" name="seedEvent" type="eventDto"/>
        /// </summary>

        [JsonPropertyName("seedEvent")]
        public object? SeedEvent { get; set; }


        [JsonPropertyName("seedEventId")]
        public int? SeedEventId { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="seriousness"/>
         */


        [JsonPropertyName("seriousnessId")]
        public int? SeriousnessId { get; set; }


        [JsonPropertyName("shortDescription")]
        public string? ShortDescription { get; set; }


        /// <summary>
        /// 
        /// Data Type : siteVisitRequiredEnum
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="siteVisitRequired" type="siteVisitRequiredEnum"/>
        /// </summary>

        [JsonPropertyName("siteVisitRequired")]
        public object? SiteVisitRequired { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="sla"/>
         */


        [JsonPropertyName("slaId")]
        public int? SlaId { get; set; }


        [JsonPropertyName("startProcess")]
        public bool? StartProcess { get; set; }


        [JsonPropertyName("stateActionSeedEvId")]
        public int? StateActionSeedEvId { get; set; }


        /// <summary>
        /// The link reason id used to automatically link a newly created Event with type of EventTypesEnum.NORMALTASK. This field is not persisted.
        /// </summary>

        [JsonPropertyName("taskLinkReasonId")]
        public int? TaskLinkReasonId { get; set; }


        /// <summary>
        /// The id of an EventDto used to seed a newly created Event with type of EventTypesEnum.NORMALTASK. This field is not persisted.
        /// </summary>

        [JsonPropertyName("taskSeedEventId")]
        public int? TaskSeedEventId { get; set; }


        /// <summary>
        /// 
        /// Data Type : servDeptDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceDepartments" minOccurs="0" name="technicalServDept" type="servDeptDto"/>
        /// </summary>

        [JsonPropertyName("technicalServDept")]
        public object? TechnicalServDept { get; set; }


        [JsonPropertyName("technicalServDeptId")]
        public int? TechnicalServDeptId { get; set; }


        /// <summary>
        /// 
        /// Data Type : assystUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assystUsers" minOccurs="0" name="technicalUser" type="assystUserDto"/>
        /// </summary>

        [JsonPropertyName("technicalUser")]
        public object? TechnicalUser { get; set; }


        [JsonPropertyName("technicalUserId")]
        public int? TechnicalUserId { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="templateProcess"/>
         */


        [JsonPropertyName("templateProcessId")]
        public int? TemplateProcessId { get; set; }


        /// <summary>
        /// 
        /// Data Type : priorityDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/priorities" minOccurs="0" name="urgency" type="priorityDto"/>
        /// </summary>

        [JsonPropertyName("urgency")]
        public PriorityDto? Urgency { get; set; }


        [JsonPropertyName("urgencyId")]
        public int? UrgencyId { get; set; }


        [JsonPropertyName("user1FieldChar1")]
        public string? User1FieldChar1 { get; set; }


        [JsonPropertyName("user1FieldChar1Id")]
        public int? User1FieldChar1Id { get; set; }


        [JsonPropertyName("user1FieldChar2")]
        public string? User1FieldChar2 { get; set; }


        [JsonPropertyName("user1FieldChar2Id")]
        public int? User1FieldChar2Id { get; set; }


        [JsonPropertyName("user1FieldChar3")]
        public string? User1FieldChar3 { get; set; }


        [JsonPropertyName("user1FieldChar3Id")]
        public int? User1FieldChar3Id { get; set; }


        [JsonPropertyName("user1FieldDate1")]
        public DateTime? User1FieldDate1 { get; set; }


        [JsonPropertyName("user1FieldDate2")]
        public DateTime? User1FieldDate2 { get; set; }


        [JsonPropertyName("user1FieldDate3")]
        public DateTime? User1FieldDate3 { get; set; }


        [JsonPropertyName("user1FieldDec1")]
        public double? User1FieldDec1 { get; set; }


        [JsonPropertyName("user1FieldDec2")]
        public double? User1FieldDec2 { get; set; }


        [JsonPropertyName("user1FieldDec3")]
        public double? User1FieldDec3 { get; set; }


        [JsonPropertyName("user2FieldChar1")]
        public string? User2FieldChar1 { get; set; }


        [JsonPropertyName("user2FieldChar1Id")]
        public int? User2FieldChar1Id { get; set; }


        [JsonPropertyName("user2FieldChar2")]
        public string? User2FieldChar2 { get; set; }


        [JsonPropertyName("user2FieldChar2Id")]
        public int? User2FieldChar2Id { get; set; }


        [JsonPropertyName("user2FieldChar3")]
        public string? User2FieldChar3 { get; set; }


        [JsonPropertyName("user2FieldChar3Id")]
        public int? User2FieldChar3Id { get; set; }


        [JsonPropertyName("user2FieldDate1")]
        public DateTime? User2FieldDate1 { get; set; }


        [JsonPropertyName("user2FieldDate2")]
        public DateTime? User2FieldDate2 { get; set; }


        [JsonPropertyName("user2FieldDate3")]
        public DateTime? User2FieldDate3 { get; set; }


        [JsonPropertyName("user2FieldDec1")]
        public double? User2FieldDec1 { get; set; }


        [JsonPropertyName("user2FieldDec2")]
        public double? User2FieldDec2 { get; set; }


        [JsonPropertyName("user2FieldDec3")]
        public double? User2FieldDec3 { get; set; }


        [JsonPropertyName("userReference")]
        public string? UserReference { get; set; }

    }

}
