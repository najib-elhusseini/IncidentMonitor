using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.Assyst
{


    /// <summary>
    /// Represents the properties of an event that may be set by the system. Properties in this class may be overwritten by the system during an update. Only properties defined by UpdateableEventDto are guaranteed to be honoured
    /// </summary>

    public class EventDto : ClientUpdatableEventDto, IHelpDeskTicket
    {


        [JsonPropertyName("actTypeId")]
        public int? ActTypeId { get; set; }


        [JsonPropertyName("actionCount")]
        public int? ActionCount { get; set; }


        [JsonPropertyName("actionFilteringSuspended")]
        public bool? ActionFilteringSuspended { get; set; }


        /// <summary>
        /// 
        /// Data Type : actionDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/actions" maxOccurs="unbounded" minOccurs="0" name="actions" nillable="true" type="actionDto"/>
        /// </summary>

        [JsonPropertyName("actions")]
        public List<AssystActionDto>? Actions { get; set; }


        /// <summary>
        /// 
        /// Data Type : additionalAffectedUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" maxOccurs="unbounded" minOccurs="0" name="additionalAffectedUserDetails" nillable="true" type="additionalAffectedUserDto"/>
        /// </summary>

        [JsonPropertyName("additionalAffectedUserDetails")]
        public object? AdditionalAffectedUserDetails { get; set; }


        [JsonPropertyName("alertStatus")]
        public int? AlertStatus { get; set; }


        /// <summary>
        /// This is not a persisted property. It can be prepopulated as part of a GET only
        /// Data Type : alertStatusDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="This is not a persisted property. It can be prepopulated as part of a GET only" axios:resourcePath="/alertStatuses" minOccurs="0" name="alertStatusAtLogging" type="alertStatusDto"/>
        /// </summary>

        [JsonPropertyName("alertStatusAtLogging")]
        public object? AlertStatusAtLogging { get; set; }


        /// <summary>
        /// 
        /// Data Type : alertStatusTypesEnum
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="alertStatusEnum" type="alertStatusTypesEnum"/>
        /// </summary>

        [JsonPropertyName("alertStatusEnum")]
        public object? AlertStatusEnum { get; set; }


        /// <summary>
        /// 
        /// Data Type : supplierDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/suppliers" minOccurs="0" name="assignedSupplier" type="supplierDto"/>
        /// </summary>

        [JsonPropertyName("assignedSupplier")]
        public object? AssignedSupplier { get; set; }


        [JsonPropertyName("assignedSupplierId")]
        public int? AssignedSupplierId { get; set; }


        [JsonPropertyName("assignmentCount")]
        public int? AssignmentCount { get; set; }


        /// <summary>
        /// 
        /// Data Type : eventDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/events" maxOccurs="unbounded" minOccurs="0" name="bundleComponentEvents" nillable="true" type="eventDto"/>
        /// </summary>

        [JsonPropertyName("bundleComponentEvents")]
        public object? BundleComponentEvents { get; set; }


        [JsonPropertyName("bundleComponentSortOrder")]
        public int? BundleComponentSortOrder { get; set; }

        
        /// <summary>
        /// 
        /// Data Type : eventDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/events" minOccurs="0" name="bundleEvent" type="eventDto"/>
        /// </summary>

        [JsonPropertyName("bundleEvent")]
        public object? BundleEvent { get; set; }


        [JsonPropertyName("bundleEventFormattedReference")]
        public string? BundleEventFormattedReference { get; set; }


        [JsonPropertyName("bundleEventId")]
        public int? BundleEventId { get; set; }


        [JsonPropertyName("bundleType")]
        public int? BundleType { get; set; }


        /// <summary>
        /// 
        /// Data Type : bundleTypesEnum
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="bundleTypeEnum" type="bundleTypesEnum"/>
        /// </summary>

        [JsonPropertyName("bundleTypeEnum")]
        public object? BundleTypeEnum { get; set; }


        [JsonPropertyName("callbackDate")]
        public DateTime? CallbackDate { get; set; }


        /// <summary>
        /// 
        /// Data Type : assystUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assystUsers" minOccurs="0" name="callbackUser" type="assystUserDto"/>
        /// </summary>

        [JsonPropertyName("callbackUser")]
        public object? CallbackUser { get; set; }


        [JsonPropertyName("callbackUserId")]
        public int? CallbackUserId { get; set; }


        /// <summary>
        /// 
        /// Data Type : categoryDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/categories" minOccurs="0" name="causeCategory" type="categoryDto"/>
        /// </summary>

        [JsonPropertyName("causeCategory")]
        public object? CauseCategory { get; set; }


        [JsonPropertyName("causeCategoryId")]
        public int? CauseCategoryId { get; set; }


        /// <summary>
        /// 
        /// Data Type : itemDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/items" minOccurs="0" name="causeItem" type="itemDto"/>
        /// </summary>

        [JsonPropertyName("causeItem")]
        public object? CauseItem { get; set; }


        [JsonPropertyName("causeItemId")]
        public int? CauseItemId { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="chargeCode"/>
         */


        [JsonPropertyName("chargeCodeId")]
        public int? ChargeCodeId { get; set; }


        /// <summary>
        /// 
        /// Data Type : eventDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/events" maxOccurs="unbounded" minOccurs="0" name="childEvents" nillable="true" type="eventDto"/>
        /// </summary>

        [JsonPropertyName("childEvents")]
        public object? ChildEvents { get; set; }


        /// <summary>
        /// 
        /// Data Type : collaborationEventDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" maxOccurs="unbounded" minOccurs="0" name="collaborations" nillable="true" type="collaborationEventDto"/>
        /// </summary>

        [JsonPropertyName("collaborations")]
        public object? Collaborations { get; set; }


        [JsonPropertyName("currencySymbol")]
        public string? CurrencySymbol { get; set; }


        [JsonPropertyName("currentOlaEsc")]
        public int? CurrentOlaEsc { get; set; }


        [JsonPropertyName("currentSlaEsc")]
        public int? CurrentSlaEsc { get; set; }


        /// <summary>
        /// 
        /// Data Type : actionTypeDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/actionTypes" minOccurs="0" name="currentStage" type="actionTypeDto"/>
        /// </summary>

        [JsonPropertyName("currentStage")]
        public object? CurrentStage { get; set; }


        [JsonPropertyName("currentStageId")]
        public int? CurrentStageId { get; set; }


        [JsonPropertyName("currentSupplierEsc")]
        public int? CurrentSupplierEsc { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="customEntityDefinition"/>
         */




        [JsonPropertyName("databaseServerDateTime")]
        public DateTime? DatabaseServerDateTime { get; set; }


        [JsonPropertyName("dateAssignedToSupplier")]
        public DateTime? DateAssignedToSupplier { get; set; }


        [JsonPropertyName("dateEventClosed")]
        public DateTime? DateEventClosed { get; set; }


        [JsonPropertyName("dateLocked")]
        public DateTime? DateLocked { get; set; }


        [JsonPropertyName("dateOfLastAssignment")]
        public DateTime? DateOfLastAssignment { get; set; }


        [JsonPropertyName("dateServDeptAcknowledged")]
        public DateTime? DateServDeptAcknowledged { get; set; }


        /// <summary>
        /// 
        /// Data Type : attachedProcessDecisionDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/attachedProcessDecisions" maxOccurs="unbounded" minOccurs="0" name="decisionAnswers" nillable="true" type="attachedProcessDecisionDto"/>
        /// </summary>

        [JsonPropertyName("decisionAnswers")]
        public object? DecisionAnswers { get; set; }


        /// <summary>
        /// Specifies the delegate user for this event. Will be null/empty if this has not come from a delegate user
        /// Data Type : assystUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="Specifies the delegate user for this event. Will be null/empty if this has not come from a delegate user" axios:resourcePath="/assystUsers" minOccurs="0" name="delegateUser" type="assystUserDto"/>
        /// </summary>

        [JsonPropertyName("delegateUser")]
        public object? DelegateUser { get; set; }


        [JsonPropertyName("delegateUserId")]
        public int? DelegateUserId { get; set; }


        /// <summary>
        /// 
        /// Data Type : geographicCoordinatesDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="derivedCoordinates" type="geographicCoordinatesDto"/>
        /// </summary>

        [JsonPropertyName("derivedCoordinates")]
        public object? DerivedCoordinates { get; set; }


        [JsonPropertyName("deskartesSolId")]
        public int? DeskartesSolId { get; set; }


        /// <summary>
        /// 
        /// Data Type : durationDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="downTime" type="durationDto"/>
        /// </summary>

        [JsonPropertyName("downTime")]
        public object? DownTime { get; set; }


        [JsonPropertyName("earliestPossibleSlaResolveDue")]
        public DateTime? EarliestPossibleSlaResolveDue { get; set; }


        /// <summary>
        /// 
        /// Data Type : durationDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="elapsedTime" type="durationDto"/>
        /// </summary>

        [JsonPropertyName("elapsedTime")]
        public object? ElapsedTime { get; set; }


        /// <summary>
        /// 
        /// Data Type : durationDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="eventLoggingTime" type="durationDto"/>
        /// </summary>

        [JsonPropertyName("eventLoggingTime")]
        public object? EventLoggingTime { get; set; }


        [JsonPropertyName("eventRef")]
        public int? EventRef { get; set; }


        [JsonPropertyName("eventState")]
        public int? EventState { get; set; }




        [JsonPropertyName("eventStateEnum")]
        [JsonConverter(typeof(EventStateTypesEnumJsonConverter))]
        public EventStateTypesEnum? EventStateEnum { get; set; }


        [JsonPropertyName("eventStatus")]
        public int? EventStatus { get; set; }



        [JsonPropertyName("eventStatusEnum")]
        [JsonConverter(typeof(EventStatusTypesEnumJsonConverter))]
        public EventStatusTypesEnum? EventStatusEnum { get; set; }


        [JsonPropertyName("eventTimezoneDateTime")]
        public DateTime? EventTimezoneDateTime { get; set; }


        [JsonPropertyName("eventType")]
        public int? EventType { get; set; }



        [JsonPropertyName("eventTypeEnum")]
        [JsonConverter(typeof(EventTypesJsonConverter))]
        public EventTypes? EventTypeEnum { get; set; }


        [JsonPropertyName("externalKnowledgeDocumentId")]
        public string? ExternalKnowledgeDocumentId { get; set; }


        [JsonPropertyName("externalKnowledgeProblemId")]
        public int? ExternalKnowledgeProblemId { get; set; }


        [JsonPropertyName("extraEventDescGroupId")]
        public int? ExtraEventDescGroupId { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="formDefinition"/>
         */


        /// <summary>
        /// 
        /// Data Type : customisationDetailsDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="formDefinitionPropertyExpressions" type="customisationDetailsDto"/>
        /// </summary>

        [JsonPropertyName("formDefinitionPropertyExpressions")]
        public object? FormDefinitionPropertyExpressions { get; set; }


        [JsonPropertyName("formattedReference")]
        public string? FormattedReference { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="holidayPlan"/>
         */


        [JsonPropertyName("holidayPlanId")]
        public int? HolidayPlanId { get; set; }


        [JsonPropertyName("incChkRef")]
        public int? IncChkRef { get; set; }


        [JsonPropertyName("isLinkedEvent")]
        public bool? IsLinkedEvent { get; set; }


        [JsonPropertyName("isLocked")]
        public bool? IsLocked { get; set; }


        /// <summary>
        /// 
        /// Data Type : actionDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/actions" maxOccurs="unbounded" minOccurs="0" name="knowledgeActions" nillable="true" type="actionDto"/>
        /// </summary>

        [JsonPropertyName("knowledgeActions")]
        public object? KnowledgeActions { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="knowledgeProcedure"/>
         */


        [JsonPropertyName("knowledgeProcedureId")]
        public int? KnowledgeProcedureId { get; set; }


        /// <summary>
        /// 
        /// Data Type : servDeptDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceDepartments" minOccurs="0" name="lastAcknowledgingServDept" type="servDeptDto"/>
        /// </summary>

        [JsonPropertyName("lastAcknowledgingServDept")]
        public object? LastAcknowledgingServDept { get; set; }


        [JsonPropertyName("lastAcknowledgingServDeptId")]
        public int? LastAcknowledgingServDeptId { get; set; }


        /// <summary>
        /// 
        /// Data Type : actionDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/actions" minOccurs="0" name="lastAction" type="actionDto"/>
        /// </summary>

        [JsonPropertyName("lastAction")]
        public object? LastAction { get; set; }


        [JsonPropertyName("lastActionDate")]
        public DateTime? LastActionDate { get; set; }


        [JsonPropertyName("lastActionServDeptSC")]
        public string? LastActionServDeptSC { get; set; }


        /// <summary>
        /// 
        /// Data Type : actionTypeDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/actionTypes" minOccurs="0" name="lastActionType" type="actionTypeDto"/>
        /// </summary>

        [JsonPropertyName("lastActionType")]
        public object? LastActionType { get; set; }


        [JsonPropertyName("lastActionTypeId")]
        public int? LastActionTypeId { get; set; }


        [JsonPropertyName("lastActionUserSC")]
        public string? LastActionUserSC { get; set; }


        /// <summary>
        /// 
        /// Data Type : servDeptDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceDepartments" minOccurs="0" name="lastCallBackServDept" type="servDeptDto"/>
        /// </summary>

        [JsonPropertyName("lastCallBackServDept")]
        public object? LastCallBackServDept { get; set; }


        [JsonPropertyName("lastCallBackServDeptId")]
        public int? LastCallBackServDeptId { get; set; }


        /// <summary>
        /// 
        /// Data Type : servDeptDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceDepartments" minOccurs="0" name="lastClosingServDept" type="servDeptDto"/>
        /// </summary>

        [JsonPropertyName("lastClosingServDept")]
        public object? LastClosingServDept { get; set; }


        [JsonPropertyName("lastClosingServDeptId")]
        public int? LastClosingServDeptId { get; set; }


        /// <summary>
        /// 
        /// Data Type : assystUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assystUsers" minOccurs="0" name="lastClosingUser" type="assystUserDto"/>
        /// </summary>

        [JsonPropertyName("lastClosingUser")]
        public object? LastClosingUser { get; set; }


        [JsonPropertyName("lastClosingUserId")]
        public int? LastClosingUserId { get; set; }


        /// <summary>
        /// 
        /// Data Type : servDeptDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceDepartments" minOccurs="0" name="lastResolvingServDept" type="servDeptDto"/>
        /// </summary>

        [JsonPropertyName("lastResolvingServDept")]
        public object? LastResolvingServDept { get; set; }


        [JsonPropertyName("lastResolvingServDeptId")]
        public int? LastResolvingServDeptId { get; set; }


        /// <summary>
        /// 
        /// Data Type : assystUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assystUsers" minOccurs="0" name="lastResolvingUser" type="assystUserDto"/>
        /// </summary>

        [JsonPropertyName("lastResolvingUser")]
        public object? LastResolvingUser { get; set; }


        [JsonPropertyName("lastResolvingUserId")]
        public int? LastResolvingUserId { get; set; }


        /// <summary>
        /// 
        /// Data Type : assystUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assystUsers" minOccurs="0" name="lastReviewingUser" type="assystUserDto"/>
        /// </summary>

        [JsonPropertyName("lastReviewingUser")]
        public object? LastReviewingUser { get; set; }


        [JsonPropertyName("lastReviewingUserId")]
        public int? LastReviewingUserId { get; set; }


        [JsonPropertyName("lastSlaClockStop")]
        public DateTime? LastSlaClockStop { get; set; }


        [JsonPropertyName("lastSupplierActionTypeId")]
        public int? LastSupplierActionTypeId { get; set; }


        [JsonPropertyName("lastSupplierClockStop")]
        public DateTime? LastSupplierClockStop { get; set; }


        /// <summary>
        /// 
        /// Data Type : knowledgeProcedureDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/knowledgeProcedures" minOccurs="0" name="lifecycleKnowledgeProcedure" type="knowledgeProcedureDto"/>
        /// </summary>

        [JsonPropertyName("lifecycleKnowledgeProcedure")]
        public object? LifecycleKnowledgeProcedure { get; set; }


        [JsonPropertyName("lifecycleKnowledgeProcedureId")]
        public int? LifecycleKnowledgeProcedureId { get; set; }


        /// <summary>
        /// 
        /// Data Type : linkedEventGroupDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/linkedEventGroups" maxOccurs="unbounded" minOccurs="0" name="linkedEventGroups" nillable="true" type="linkedEventGroupDto"/>
        /// </summary>

        [JsonPropertyName("linkedEventGroups")]
        public object? LinkedEventGroups { get; set; }


        [JsonPropertyName("linkedEventsCount")]
        public int? LinkedEventsCount { get; set; }


        /// <summary>
        /// 
        /// Data Type : itemDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/items" maxOccurs="unbounded" minOccurs="0" name="linkedItems" nillable="true" type="itemDto"/>
        /// </summary>

        [JsonPropertyName("linkedItems")]
        public object? LinkedItems { get; set; }


        /// <summary>
        /// 
        /// Data Type : contactUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/contactUsers" minOccurs="0" name="loggingContactUser" type="contactUserDto"/>
        /// </summary>

        [JsonPropertyName("loggingContactUser")]
        public object? LoggingContactUser { get; set; }


        [JsonPropertyName("loggingContactUserId")]
        public int? LoggingContactUserId { get; set; }


        /// <summary>
        /// 
        /// Data Type : servDeptDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceDepartments" minOccurs="0" name="loggingServDept" type="servDeptDto"/>
        /// </summary>

        [JsonPropertyName("loggingServDept")]
        public object? LoggingServDept { get; set; }


        [JsonPropertyName("loggingServDeptId")]
        public int? LoggingServDeptId { get; set; }


        /// <summary>
        /// 
        /// Data Type : assystUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assystUsers" minOccurs="0" name="loggingUser" type="assystUserDto"/>
        /// </summary>

        [JsonPropertyName("loggingUser")]
        public object? LoggingUser { get; set; }


        [JsonPropertyName("loggingUserId")]
        public int? LoggingUserId { get; set; }


        /// <summary>
        /// 
        /// Data Type : eventDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/events" minOccurs="0" name="majorIncident" type="eventDto"/>
        /// </summary>

        [JsonPropertyName("majorIncident")]
        public object? MajorIncident { get; set; }


        [JsonPropertyName("majorIncidentFlag")]
        public bool? MajorIncidentFlag { get; set; }


        [JsonPropertyName("majorIncidentId")]
        public int? MajorIncidentId { get; set; }


        /// <summary>
        /// 
        /// Data Type : actionDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/actions" minOccurs="0" name="nextAction" type="actionDto"/>
        /// </summary>

        [JsonPropertyName("nextAction")]
        public object? NextAction { get; set; }


        [JsonPropertyName("nextActionDue")]
        public DateTime? NextActionDue { get; set; }


        [JsonPropertyName("nextActionServDeptN")]
        public string? NextActionServDeptN { get; set; }


        [JsonPropertyName("nextActionServDeptSC")]
        public string? NextActionServDeptSC { get; set; }


        /// <summary>
        /// 
        /// Data Type : actionTypeDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/actionTypes" minOccurs="0" name="nextActionType" type="actionTypeDto"/>
        /// </summary>

        [JsonPropertyName("nextActionType")]
        public object? NextActionType { get; set; }


        [JsonPropertyName("nextActionTypeId")]
        public int? NextActionTypeId { get; set; }


        [JsonPropertyName("nextActionUserN")]
        public string? NextActionUserN { get; set; }


        [JsonPropertyName("nextActionUserSC")]
        public string? NextActionUserSC { get; set; }


        /// <summary>
        /// 
        /// Data Type : olaDerivedPropertiesDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="olaDerivedProperties" type="olaDerivedPropertiesDto"/>
        /// </summary>

        [JsonPropertyName("olaDerivedProperties")]
        public object? OlaDerivedProperties { get; set; }


        [JsonPropertyName("olaEsc10Breach")]
        public bool? OlaEsc10Breach { get; set; }


        [JsonPropertyName("olaEsc10Due")]
        public DateTime? OlaEsc10Due { get; set; }


        [JsonPropertyName("olaEsc1Breach")]
        public bool? OlaEsc1Breach { get; set; }


        [JsonPropertyName("olaEsc1Due")]
        public DateTime? OlaEsc1Due { get; set; }


        [JsonPropertyName("olaEsc2Breach")]
        public bool? OlaEsc2Breach { get; set; }


        [JsonPropertyName("olaEsc2Due")]
        public DateTime? OlaEsc2Due { get; set; }


        [JsonPropertyName("olaEsc3Breach")]
        public bool? OlaEsc3Breach { get; set; }


        [JsonPropertyName("olaEsc3Due")]
        public DateTime? OlaEsc3Due { get; set; }


        [JsonPropertyName("olaEsc4Breach")]
        public bool? OlaEsc4Breach { get; set; }


        [JsonPropertyName("olaEsc4Due")]
        public DateTime? OlaEsc4Due { get; set; }


        [JsonPropertyName("olaEsc5Breach")]
        public bool? OlaEsc5Breach { get; set; }


        [JsonPropertyName("olaEsc5Due")]
        public DateTime? OlaEsc5Due { get; set; }


        [JsonPropertyName("olaEsc6Breach")]
        public bool? OlaEsc6Breach { get; set; }


        [JsonPropertyName("olaEsc6Due")]
        public DateTime? OlaEsc6Due { get; set; }


        [JsonPropertyName("olaEsc7Breach")]
        public bool? OlaEsc7Breach { get; set; }


        [JsonPropertyName("olaEsc7Due")]
        public DateTime? OlaEsc7Due { get; set; }


        [JsonPropertyName("olaEsc8Breach")]
        public bool? OlaEsc8Breach { get; set; }


        [JsonPropertyName("olaEsc8Due")]
        public DateTime? OlaEsc8Due { get; set; }


        [JsonPropertyName("olaEsc9Breach")]
        public bool? OlaEsc9Breach { get; set; }


        [JsonPropertyName("olaEsc9Due")]
        public DateTime? OlaEsc9Due { get; set; }


        [JsonPropertyName("olaFriEnd")]
        public DateTime? OlaFriEnd { get; set; }


        [JsonPropertyName("olaFriStart")]
        public DateTime? OlaFriStart { get; set; }


        [JsonPropertyName("olaMonEnd")]
        public DateTime? OlaMonEnd { get; set; }


        [JsonPropertyName("olaMonStart")]
        public DateTime? OlaMonStart { get; set; }


        [JsonPropertyName("olaResolveDue")]
        public DateTime? OlaResolveDue { get; set; }


        [JsonPropertyName("olaResponseDue")]
        public DateTime? OlaResponseDue { get; set; }


        [JsonPropertyName("olaSatEnd")]
        public DateTime? OlaSatEnd { get; set; }


        [JsonPropertyName("olaSatStart")]
        public DateTime? OlaSatStart { get; set; }


        [JsonPropertyName("olaSunEnd")]
        public DateTime? OlaSunEnd { get; set; }


        [JsonPropertyName("olaSunStart")]
        public DateTime? OlaSunStart { get; set; }


        [JsonPropertyName("olaThrEnd")]
        public DateTime? OlaThrEnd { get; set; }


        [JsonPropertyName("olaThrStart")]
        public DateTime? OlaThrStart { get; set; }


        /// <summary>
        /// 
        /// Data Type : durationDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="olaTotalTimeClockStopped" type="durationDto"/>
        /// </summary>

        [JsonPropertyName("olaTotalTimeClockStopped")]
        public object? OlaTotalTimeClockStopped { get; set; }


        [JsonPropertyName("olaTueEnd")]
        public DateTime? OlaTueEnd { get; set; }


        [JsonPropertyName("olaTueStart")]
        public DateTime? OlaTueStart { get; set; }


        [JsonPropertyName("olaWedEnd")]
        public DateTime? OlaWedEnd { get; set; }


        [JsonPropertyName("olaWedStart")]
        public DateTime? OlaWedStart { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="order"/>
         */


        /// <summary>
        /// 
        /// Data Type : eventDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/events" maxOccurs="unbounded" minOccurs="0" name="orderComponentEvents" nillable="true" type="eventDto"/>
        /// </summary>

        [JsonPropertyName("orderComponentEvents")]
        public object? OrderComponentEvents { get; set; }


        [JsonPropertyName("orderId")]
        public int? OrderId { get; set; }


        [JsonPropertyName("orderRef")]
        public string? OrderRef { get; set; }


        /// <summary>
        /// Defines the first Service Department this Event was assigned to
        /// Data Type : servDeptDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="Defines the first Service Department this Event was assigned to" axios:resourcePath="/serviceDepartments" minOccurs="0" name="originalAssignedServDept" type="servDeptDto"/>
        /// </summary>

        [JsonPropertyName("originalAssignedServDept")]
        public object? OriginalAssignedServDept { get; set; }


        [JsonPropertyName("originalAssignedServDeptId")]
        public int? OriginalAssignedServDeptId { get; set; }


        [JsonPropertyName("originalAssignedServDeptSC")]
        public string? OriginalAssignedServDeptSC { get; set; }


        /// <summary>
        /// Defines the first assyst User this Event was assigned to
        /// Data Type : assystUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="Defines the first assyst User this Event was assigned to" axios:resourcePath="/assystUsers" minOccurs="0" name="originalAssignedUser" type="assystUserDto"/>
        /// </summary>

        [JsonPropertyName("originalAssignedUser")]
        public object? OriginalAssignedUser { get; set; }


        [JsonPropertyName("originalAssignedUserId")]
        public int? OriginalAssignedUserId { get; set; }


        /// <summary>
        /// 
        /// Data Type : eventDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/events" minOccurs="0" name="parentEvent" type="eventDto"/>
        /// </summary>

        [JsonPropertyName("parentEvent")]
        public object? ParentEvent { get; set; }


        [JsonPropertyName("parentEventId")]
        public int? ParentEventId { get; set; }


        /// <summary>
        /// Defines the parent stage for this event. This property is only used with Task events and will be null/empty otherwise
        /// Data Type : attachedProcessStageDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="Defines the parent stage for this event. This property is only used with Task events and will be null/empty otherwise" axios:resourcePath="/attachedProcessStages" minOccurs="0" name="parentStage" type="attachedProcessStageDto"/>
        /// </summary>

        [JsonPropertyName("parentStage")]
        public object? ParentStage { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="purchaseOrder"/>
         */


        [JsonPropertyName("purchaseOrderId")]
        public int? PurchaseOrderId { get; set; }


        /// <summary>
        /// 
        /// Data Type : attachedProcessTaskDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/attachedProcessTasks" minOccurs="0" name="relatedTaskInfo" type="attachedProcessTaskDto"/>
        /// </summary>

        [JsonPropertyName("relatedTaskInfo")]
        public object? RelatedTaskInfo { get; set; }


        [JsonPropertyName("remarksEnteredBySystem")]
        public bool? RemarksEnteredBySystem { get; set; }


        [JsonPropertyName("resolutionActual")]
        public DateTime? ResolutionActual { get; set; }


        [JsonPropertyName("resolutionBreached")]
        public bool? ResolutionBreached { get; set; }


        [JsonPropertyName("resolutionDue")]
        public DateTime? ResolutionDue { get; set; }


        /// <summary>
        /// 
        /// Data Type : durationDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="resolveTimeToGo" type="durationDto"/>
        /// </summary>

        [JsonPropertyName("resolveTimeToGo")]
        public object? ResolveTimeToGo { get; set; }


        [JsonPropertyName("responseActual")]
        public DateTime? ResponseActual { get; set; }


        [JsonPropertyName("responseDue")]
        public DateTime? ResponseDue { get; set; }


        [JsonPropertyName("responsibleUserName")]
        public string? ResponsibleUserName { get; set; }


        /// <summary>
        /// 
        /// Data Type : assystUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assystUsers" minOccurs="0" name="reviewingUser" type="assystUserDto"/>
        /// </summary>

        [JsonPropertyName("reviewingUser")]
        public object? ReviewingUser { get; set; }


        [JsonPropertyName("reviewingUserId")]
        public int? ReviewingUserId { get; set; }


        [JsonPropertyName("rfcExpiryDate")]
        public DateTime? RfcExpiryDate { get; set; }


        [JsonPropertyName("servDeptAcknowledgementRequired")]
        public bool? ServDeptAcknowledgementRequired { get; set; }


        [JsonPropertyName("serviceOffering")]
        public ServiceOfferingDto? ServiceOffering { get; set; }


        [JsonPropertyName("serviceOfferingId")]
        public int? ServiceOfferingId { get; set; }


        [JsonPropertyName("skipAmendPriorityValidation")]
        public bool? SkipAmendPriorityValidation { get; set; }


        [JsonPropertyName("skipAmendSeriousnessValidation")]
        public bool? SkipAmendSeriousnessValidation { get; set; }


        [JsonPropertyName("skipExistingEventLink")]
        public bool? SkipExistingEventLink { get; set; }


        /// <summary>
        /// 
        /// Data Type : eventSLAChangedByTypes
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="slaChangedBy" type="eventSLAChangedByTypes"/>
        /// </summary>

        [JsonPropertyName("slaChangedBy")]
        public object? SlaChangedBy { get; set; }


        /// <summary>
        /// 
        /// Data Type : slaDerivedPropertiesDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="slaDerivedProperties" type="slaDerivedPropertiesDto"/>
        /// </summary>

        [JsonPropertyName("slaDerivedProperties")]
        public object? SlaDerivedProperties { get; set; }


        [JsonPropertyName("slaEsc10Breach")]
        public bool? SlaEsc10Breach { get; set; }


        [JsonPropertyName("slaEsc10Due")]
        public DateTime? SlaEsc10Due { get; set; }


        [JsonPropertyName("slaEsc1Breach")]
        public bool? SlaEsc1Breach { get; set; }


        [JsonPropertyName("slaEsc1Due")]
        public DateTime? SlaEsc1Due { get; set; }


        [JsonPropertyName("slaEsc2Breach")]
        public bool? SlaEsc2Breach { get; set; }


        [JsonPropertyName("slaEsc2Due")]
        public DateTime? SlaEsc2Due { get; set; }


        [JsonPropertyName("slaEsc3Breach")]
        public bool? SlaEsc3Breach { get; set; }


        [JsonPropertyName("slaEsc3Due")]
        public DateTime? SlaEsc3Due { get; set; }


        [JsonPropertyName("slaEsc4Breach")]
        public bool? SlaEsc4Breach { get; set; }


        [JsonPropertyName("slaEsc4Due")]
        public DateTime? SlaEsc4Due { get; set; }


        [JsonPropertyName("slaEsc5Breach")]
        public bool? SlaEsc5Breach { get; set; }


        [JsonPropertyName("slaEsc5Due")]
        public DateTime? SlaEsc5Due { get; set; }


        [JsonPropertyName("slaEsc6Breach")]
        public bool? SlaEsc6Breach { get; set; }


        [JsonPropertyName("slaEsc6Due")]
        public DateTime? SlaEsc6Due { get; set; }


        [JsonPropertyName("slaEsc7Breach")]
        public bool? SlaEsc7Breach { get; set; }


        [JsonPropertyName("slaEsc7Due")]
        public DateTime? SlaEsc7Due { get; set; }


        [JsonPropertyName("slaEsc8Breach")]
        public bool? SlaEsc8Breach { get; set; }


        [JsonPropertyName("slaEsc8Due")]
        public DateTime? SlaEsc8Due { get; set; }


        [JsonPropertyName("slaEsc9Breach")]
        public bool? SlaEsc9Breach { get; set; }


        [JsonPropertyName("slaEsc9Due")]
        public DateTime? SlaEsc9Due { get; set; }


        [JsonPropertyName("slaFriEnd")]
        public DateTime? SlaFriEnd { get; set; }


        [JsonPropertyName("slaFriStart")]
        public DateTime? SlaFriStart { get; set; }


        [JsonPropertyName("slaMonEnd")]
        public DateTime? SlaMonEnd { get; set; }


        [JsonPropertyName("slaMonStart")]
        public DateTime? SlaMonStart { get; set; }


        [JsonPropertyName("slaResolutionDue")]
        public DateTime? SlaResolutionDue { get; set; }


        [JsonPropertyName("slaSatEnd")]
        public DateTime? SlaSatEnd { get; set; }


        [JsonPropertyName("slaSatStart")]
        public DateTime? SlaSatStart { get; set; }


        [JsonPropertyName("slaShortCode")]
        public string? SlaShortCode { get; set; }


        [JsonPropertyName("slaSunEnd")]
        public DateTime? SlaSunEnd { get; set; }


        [JsonPropertyName("slaSunStart")]
        public DateTime? SlaSunStart { get; set; }


        [JsonPropertyName("slaThrEnd")]
        public DateTime? SlaThrEnd { get; set; }


        [JsonPropertyName("slaThrStart")]
        public DateTime? SlaThrStart { get; set; }


        [JsonPropertyName("slaTimeType")]
        public int? SlaTimeType { get; set; }


        /// <summary>
        /// 
        /// Data Type : slaTimeTypesEnum
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="slaTimeTypeEnum" type="slaTimeTypesEnum"/>
        /// </summary>

        [JsonPropertyName("slaTimeTypeEnum")]
        public object? SlaTimeTypeEnum { get; set; }


        [JsonPropertyName("slaTueEnd")]
        public DateTime? SlaTueEnd { get; set; }


        [JsonPropertyName("slaTueStart")]
        public DateTime? SlaTueStart { get; set; }


        [JsonPropertyName("slaWedEnd")]
        public DateTime? SlaWedEnd { get; set; }


        [JsonPropertyName("slaWedStart")]
        public DateTime? SlaWedStart { get; set; }


        [JsonPropertyName("subEventType")]
        public int? SubEventType { get; set; }


        /// <summary>
        /// 
        /// Data Type : subEventTypesEnum
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="subEventTypeEnum" type="subEventTypesEnum"/>
        /// </summary>

        [JsonPropertyName("subEventTypeEnum")]
        public object? SubEventTypeEnum { get; set; }


        /// <summary>
        /// 
        /// Data Type : holidayPlanDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/holidayPlans" minOccurs="0" name="supHolidayPlan" type="holidayPlanDto"/>
        /// </summary>

        [JsonPropertyName("supHolidayPlan")]
        public object? SupHolidayPlan { get; set; }


        [JsonPropertyName("supHolidayPlanId")]
        public int? SupHolidayPlanId { get; set; }


        /// <summary>
        /// 
        /// Data Type : supplierDerivedPropertiesDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="supplierDerivedProperties" type="supplierDerivedPropertiesDto"/>
        /// </summary>

        [JsonPropertyName("supplierDerivedProperties")]
        public object? SupplierDerivedProperties { get; set; }


        [JsonPropertyName("supplierEsc10Breach")]
        public bool? SupplierEsc10Breach { get; set; }


        [JsonPropertyName("supplierEsc10Due")]
        public DateTime? SupplierEsc10Due { get; set; }


        [JsonPropertyName("supplierEsc1Breach")]
        public bool? SupplierEsc1Breach { get; set; }


        [JsonPropertyName("supplierEsc1Due")]
        public DateTime? SupplierEsc1Due { get; set; }


        [JsonPropertyName("supplierEsc2Breach")]
        public bool? SupplierEsc2Breach { get; set; }


        [JsonPropertyName("supplierEsc2Due")]
        public DateTime? SupplierEsc2Due { get; set; }


        [JsonPropertyName("supplierEsc3Breach")]
        public bool? SupplierEsc3Breach { get; set; }


        [JsonPropertyName("supplierEsc3Due")]
        public DateTime? SupplierEsc3Due { get; set; }


        [JsonPropertyName("supplierEsc4Breach")]
        public bool? SupplierEsc4Breach { get; set; }


        [JsonPropertyName("supplierEsc4Due")]
        public DateTime? SupplierEsc4Due { get; set; }


        [JsonPropertyName("supplierEsc5Breach")]
        public bool? SupplierEsc5Breach { get; set; }


        [JsonPropertyName("supplierEsc5Due")]
        public DateTime? SupplierEsc5Due { get; set; }


        [JsonPropertyName("supplierEsc6Breach")]
        public bool? SupplierEsc6Breach { get; set; }


        [JsonPropertyName("supplierEsc6Due")]
        public DateTime? SupplierEsc6Due { get; set; }


        [JsonPropertyName("supplierEsc7Breach")]
        public bool? SupplierEsc7Breach { get; set; }


        [JsonPropertyName("supplierEsc7Due")]
        public DateTime? SupplierEsc7Due { get; set; }


        [JsonPropertyName("supplierEsc8Breach")]
        public bool? SupplierEsc8Breach { get; set; }


        [JsonPropertyName("supplierEsc8Due")]
        public DateTime? SupplierEsc8Due { get; set; }


        [JsonPropertyName("supplierEsc9Breach")]
        public bool? SupplierEsc9Breach { get; set; }


        [JsonPropertyName("supplierEsc9Due")]
        public DateTime? SupplierEsc9Due { get; set; }


        [JsonPropertyName("supplierRef")]
        public string? SupplierRef { get; set; }


        [JsonPropertyName("supplierResolutionActual")]
        public DateTime? SupplierResolutionActual { get; set; }


        [JsonPropertyName("supplierResolutionDue")]
        public DateTime? SupplierResolutionDue { get; set; }


        [JsonPropertyName("supplierResponseActual")]
        public DateTime? SupplierResponseActual { get; set; }


        [JsonPropertyName("supplierResponseDue")]
        public DateTime? SupplierResponseDue { get; set; }


        /// <summary>
        /// 
        /// Data Type : slaDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceLevelAgreements" minOccurs="0" name="supplierSla" type="slaDto"/>
        /// </summary>

        [JsonPropertyName("supplierSla")]
        public object? SupplierSla { get; set; }


        [JsonPropertyName("supplierSlaFriEnd")]
        public DateTime? SupplierSlaFriEnd { get; set; }


        [JsonPropertyName("supplierSlaFriStart")]
        public DateTime? SupplierSlaFriStart { get; set; }


        [JsonPropertyName("supplierSlaId")]
        public int? SupplierSlaId { get; set; }


        [JsonPropertyName("supplierSlaMonEnd")]
        public DateTime? SupplierSlaMonEnd { get; set; }


        [JsonPropertyName("supplierSlaMonStart")]
        public DateTime? SupplierSlaMonStart { get; set; }


        [JsonPropertyName("supplierSlaSatEnd")]
        public DateTime? SupplierSlaSatEnd { get; set; }


        [JsonPropertyName("supplierSlaSatStart")]
        public DateTime? SupplierSlaSatStart { get; set; }


        [JsonPropertyName("supplierSlaShortCode")]
        public string? SupplierSlaShortCode { get; set; }


        [JsonPropertyName("supplierSlaSunEnd")]
        public DateTime? SupplierSlaSunEnd { get; set; }


        [JsonPropertyName("supplierSlaSunStart")]
        public DateTime? SupplierSlaSunStart { get; set; }


        [JsonPropertyName("supplierSlaThrEnd")]
        public DateTime? SupplierSlaThrEnd { get; set; }


        [JsonPropertyName("supplierSlaThrStart")]
        public DateTime? SupplierSlaThrStart { get; set; }


        [JsonPropertyName("supplierSlaTimeType")]
        public int? SupplierSlaTimeType { get; set; }


        /// <summary>
        /// 
        /// Data Type : slaTimeTypesEnum
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="supplierSlaTimeTypeEnum" type="slaTimeTypesEnum"/>
        /// </summary>

        [JsonPropertyName("supplierSlaTimeTypeEnum")]
        public object? SupplierSlaTimeTypeEnum { get; set; }


        [JsonPropertyName("supplierSlaTueEnd")]
        public DateTime? SupplierSlaTueEnd { get; set; }


        [JsonPropertyName("supplierSlaTueStart")]
        public DateTime? SupplierSlaTueStart { get; set; }


        [JsonPropertyName("supplierSlaWedEnd")]
        public DateTime? SupplierSlaWedEnd { get; set; }


        [JsonPropertyName("supplierSlaWedStart")]
        public DateTime? SupplierSlaWedStart { get; set; }


        /// <summary>
        /// 
        /// Data Type : supplierStatusEnum
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="supplierStatusEnum" type="supplierStatusEnum"/>
        /// </summary>

        [JsonPropertyName("supplierStatusEnum")]
        public object? SupplierStatusEnum { get; set; }


        /// <summary>
        /// 
        /// Data Type : durationDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="supplierTimeToResolveActual" type="durationDto"/>
        /// </summary>

        [JsonPropertyName("supplierTimeToResolveActual")]
        public object? SupplierTimeToResolveActual { get; set; }


        /// <summary>
        /// 
        /// Data Type : durationDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="supplierTimeToResolveSla" type="durationDto"/>
        /// </summary>

        [JsonPropertyName("supplierTimeToResolveSla")]
        public object? SupplierTimeToResolveSla { get; set; }


        /// <summary>
        /// 
        /// Data Type : durationDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="supplierTimeToRespondActual" type="durationDto"/>
        /// </summary>

        [JsonPropertyName("supplierTimeToRespondActual")]
        public object? SupplierTimeToRespondActual { get; set; }


        /// <summary>
        /// 
        /// Data Type : durationDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="supplierTimeToRespondSla" type="durationDto"/>
        /// </summary>

        [JsonPropertyName("supplierTimeToRespondSla")]
        public object? SupplierTimeToRespondSla { get; set; }


        /// <summary>
        /// 
        /// Data Type : surveyRequestDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/surveyRequests" maxOccurs="unbounded" minOccurs="0" name="surveyRequests" nillable="true" type="surveyRequestDto"/>
        /// </summary>

        [JsonPropertyName("surveyRequests")]
        public object? SurveyRequests { get; set; }


        [JsonPropertyName("svdResolutionActual")]
        public DateTime? SvdResolutionActual { get; set; }


        /// <summary>
        /// Defines the OLA used with this event. This property is only used when events have been assigned to Service Departments that define OLAs and will be null/empty otherwise
        /// Data Type : slaDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="Defines the OLA used with this event. This property is only used when events have been assigned to Service Departments that define OLAs and will be null/empty otherwise" axios:resourcePath="/serviceLevelAgreements" minOccurs="0" name="svdSla" type="slaDto"/>
        /// </summary>

        [JsonPropertyName("svdSla")]
        public object? SvdSla { get; set; }


        [JsonPropertyName("svdSlaId")]
        public int? SvdSlaId { get; set; }


        /// <summary>
        /// 
        /// Data Type : assystUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assystUsers" minOccurs="0" name="terminalLockingUser" type="assystUserDto"/>
        /// </summary>

        [JsonPropertyName("terminalLockingUser")]
        public object? TerminalLockingUser { get; set; }


        [JsonPropertyName("terminalLockingUserId")]
        public int? TerminalLockingUserId { get; set; }


        /// <summary>
        /// 
        /// Data Type : durationDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="timeToCallbackSla" type="durationDto"/>
        /// </summary>

        [JsonPropertyName("timeToCallbackSla")]
        public object? TimeToCallbackSla { get; set; }


        /// <summary>
        /// 
        /// Data Type : durationDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="timeToResolveActual" type="durationDto"/>
        /// </summary>

        [JsonPropertyName("timeToResolveActual")]
        public object? TimeToResolveActual { get; set; }


        /// <summary>
        /// 
        /// Data Type : durationDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="timeToResolveSla" type="durationDto"/>
        /// </summary>

        [JsonPropertyName("timeToResolveSla")]
        public object? TimeToResolveSla { get; set; }


        /// <summary>
        /// 
        /// Data Type : durationDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="timeToRespondSla" type="durationDto"/>
        /// </summary>

        [JsonPropertyName("timeToRespondSla")]
        public object? TimeToRespondSla { get; set; }


        [JsonPropertyName("totalAttachmentCount")]
        public int? TotalAttachmentCount { get; set; }


        [JsonPropertyName("totalBundlePrice")]
        public double? TotalBundlePrice { get; set; }


        [JsonPropertyName("totalCost")]
        public double? TotalCost { get; set; }


        [JsonPropertyName("totalPrice")]
        public double? TotalPrice { get; set; }


        [JsonPropertyName("totalServiceCost")]
        public double? TotalServiceCost { get; set; }


        /// <summary>
        /// 
        /// Data Type : durationDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="totalServiceTime" type="durationDto"/>
        /// </summary>

        [JsonPropertyName("totalServiceTime")]
        public object? TotalServiceTime { get; set; }


        /// <summary>
        /// 
        /// Data Type : durationDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="totalTimeClockStopped" type="durationDto"/>
        /// </summary>

        [JsonPropertyName("totalTimeClockStopped")]
        public object? TotalTimeClockStopped { get; set; }


        /// <summary>
        /// 
        /// Data Type : durationDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="totalTimeSupplierClockStopped" type="durationDto"/>
        /// </summary>

        [JsonPropertyName("totalTimeSupplierClockStopped")]
        public object? TotalTimeSupplierClockStopped { get; set; }


        [JsonPropertyName("uflag1")]
        public bool? Uflag1 { get; set; }


        [JsonPropertyName("uflag2")]
        public bool? Uflag2 { get; set; }


        [JsonPropertyName("uflag3")]
        public string? Uflag3 { get; set; }


        [JsonPropertyName("uflag4")]
        public string? Uflag4 { get; set; }


        [JsonPropertyName("uflag6")]
        public string? Uflag6 { get; set; }


        [JsonPropertyName("uflag7")]
        public string? Uflag7 { get; set; }


        [JsonPropertyName("uflag8")]
        public string? Uflag8 { get; set; }


        [JsonPropertyName("unitBundlePrice")]
        public double? UnitBundlePrice { get; set; }


        [JsonPropertyName("unitCost")]
        public double? UnitCost { get; set; }


        [JsonPropertyName("unitPrice")]
        public double? UnitPrice { get; set; }


        [JsonPropertyName("unum6")]
        public int? Unum6 { get; set; }


        [JsonPropertyName("unum7")]
        public int? Unum7 { get; set; }


        /// <summary>
        /// 
        /// Data Type : actionTypeDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/actionTypes" minOccurs="0" name="userStatus" type="actionTypeDto"/>
        /// </summary>

        [JsonPropertyName("userStatus")]
        public object? UserStatus { get; set; }


        [JsonPropertyName("userStatusId")]
        public int? UserStatusId { get; set; }


        [JsonPropertyName("ustring2")]
        public string? Ustring2 { get; set; }


        [JsonPropertyName("verifyAuthoriseAction")]
        public bool? VerifyAuthoriseAction { get; set; }


        [JsonPropertyName("verifyDoNotAuthoriseAction")]
        public bool? VerifyDoNotAuthoriseAction { get; set; }


        [JsonPropertyName("webCustomPropertiesDescription")]
        public string? WebCustomPropertiesDescription { get; set; }



        [JsonPropertyName("customerCaseId")]
        public string CustomerCaseId
        {
            get
            {
                if (CustomFields == null || !CustomFields.Any())
                {
                    return string.Empty;
                }

                var field = CustomFields.FirstOrDefault(cf => cf?.CustomFieldShortCode == "CUSTOMER CASE ID");
                if (field == null)
                {
                    return string.Empty;
                }
                return field.StringValue ?? string.Empty;



            }
        }

        /// <summary>
        /// This is a custom field not present in Assyst
        /// It is a flag to signify that a particular event is acknowledged
        /// </summary>
        [JsonPropertyName("acknowledged")]
        public bool Acknowledged
        {
            get
            {
                if (CallbackRequired == false)
                {
                    return true;
                }
                return CallbackUserId != 0;
            }
        }

        [JsonPropertyName("eventAcknowledgedStatus")]
        public EventAcknowledgedStatus EventAcknowledgedStatus { get; set; }



        public EventAcknowledgedStatus GetEventAcknowledgedStatus(IHelpDeskObject helpDeskUser)
        {

            if (DateLogged == null)
            {
                return EventAcknowledgedStatus.Unknown;
            }
            if (!CallbackRequired == true)
            {
                return EventAcknowledgedStatus.CallbackNotRequired;
            }

            var responded = Acknowledged;

            var offset = helpDeskUser.TimeZoneOffset ?? 0;
            var userNow = DateTime.UtcNow.AddHours(offset);
            var incidentCreationDate = DateLogged.Value
                .ToUniversalTime().AddHours(offset);

            bool isWithinShift;
            // If it is not in the same day
            if (userNow.Year != incidentCreationDate.Year ||
                userNow.Month != incidentCreationDate.Month ||
                userNow.Day != incidentCreationDate.Day)
            {
                isWithinShift = false;
            }
            else
            {
                isWithinShift = helpDeskUser.IsWithinShift(incidentCreationDate);
            }
            var result = isWithinShift switch
            {
                true => responded ? EventAcknowledgedStatus.RespondedInShift : EventAcknowledgedStatus.UnrespondedInShift,
                false => responded ? EventAcknowledgedStatus.RespondedNotInShift : EventAcknowledgedStatus.UnsrespondedNotInShift,
            };

            return result;

        }



        public string? TicketId => $"{Id}";

        public string? TicketNumber => $"{FormattedReference}";

        public string? TicketAffectedUserId => $"{AffectedUserId}";

        public string? TicketAffectedUserEmail
        {
            get => AffectedUserEmail;
            set
            {
                AffectedUserEmail = value;
            }
        }
        public string? TicketAssignedUser
        {
            get
            {
                if (AssignedUser != null)
                {
                    return AssignedUser.Email;
                }
                return null;
            }
            set
            {
                if (AssignedUser != null)
                {
                    AssignedUser.Email = value;
                }

            }
        }

        public string? TicketCreatedBy => ModifyId;

        public string? TicketShortDescription
        {
            get => ShortDescription;
            set
            {
                ShortDescription = value;
            }
        }

        public string? TicketFullDescription
        {
            get
            {
                return RichRemarks?.Content ?? Remarks;
            }
            set
            {
                if (RichRemarks != null)
                {
                    RichRemarks.Content = value;
                }
                else
                {
                    Remarks = value;
                }
            }
        }

        public DateTime? TicketCreationDate => DateLogged;



        public HelpDeskSeriousness? HelpDeskImpact
        {
            get
            {
                var result = ImpactId switch
                {
                    17 => HelpDeskSeriousness.Critical,
                    14 => HelpDeskSeriousness.Major,
                    3 => HelpDeskSeriousness.Moderate,
                    16 => HelpDeskSeriousness.Minor,
                    21 => HelpDeskSeriousness.Request,
                    _ => HelpDeskSeriousness.Request
                };

                return result;
            }
            set
            {
                ImpactId = value switch
                {
                    HelpDeskSeriousness.Critical => 17,
                    HelpDeskSeriousness.Major => 14,
                    HelpDeskSeriousness.Moderate => 3,
                    HelpDeskSeriousness.Minor => 16,
                    _ => 21
                };
            }
        }

        public HelpDeskSeriousness? HelpDeskUrgency
        {
            get
            {
                return UrgencyId switch
                {
                    13 => HelpDeskSeriousness.Critical,
                    14 => HelpDeskSeriousness.Major,
                    3 => HelpDeskSeriousness.Moderate,
                    15 => HelpDeskSeriousness.Minor,
                    19 => HelpDeskSeriousness.Request,
                    _ => HelpDeskSeriousness.Request
                };
            }
            set
            {
                UrgencyId = value switch
                {
                    HelpDeskSeriousness.Critical => 13,
                    HelpDeskSeriousness.Major => 14,
                    HelpDeskSeriousness.Moderate => 3,
                    HelpDeskSeriousness.Minor => 15,
                    _ => 19,
                };
            }
        }

        public IEnumerable<IHelpDeskComment> Comments => Actions ?? new();
    }



}
