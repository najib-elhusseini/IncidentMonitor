using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.Assyst
{
    public class ServDeptDto : AssystBaseCSGDto
    {


        [JsonPropertyName("ableToReceiveAuthorisations")]
        public bool? AbleToReceiveAuthorisations { get; set; }


        [JsonPropertyName("ableToReceiveEvents")]
        public bool? AbleToReceiveEvents { get; set; }


        [JsonPropertyName("ackCosting")]
        public bool? AckCosting { get; set; }


        [JsonPropertyName("ackDetail")]
        public bool? AckDetail { get; set; }


        [JsonPropertyName("ackReqd")]
        public bool? AckReqd { get; set; }


        [JsonPropertyName("ackTime")]
        public bool? AckTime { get; set; }


        [JsonPropertyName("anonymizedName")]
        public string? AnonymizedName { get; set; }


        [JsonPropertyName("assIntCosting")]
        public bool? AssIntCosting { get; set; }


        [JsonPropertyName("assIntDetail")]
        public bool? AssIntDetail { get; set; }


        [JsonPropertyName("assIntTime")]
        public bool? AssIntTime { get; set; }


        [JsonPropertyName("assTriggerLevel")]
        public int? AssTriggerLevel { get; set; }


        /// <summary>
        /// 
        /// Data Type : contactUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/contactUsers" minOccurs="0" name="assTriggerUser" type="contactUserDto"/>
        /// </summary>

        [JsonPropertyName("assTriggerUser")]
        public object? AssTriggerUser { get; set; }


        [JsonPropertyName("assTriggerUserId")]
        public int? AssTriggerUserId { get; set; }


        /// <summary>
        /// Describes all assyst users who are members of this Service Department (either primary or secondary)
        /// Data Type : assystUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="Describes all assyst users who are members of this Service Department (either primary or secondary)" axios:resourcePath="/assystUsers" maxOccurs="unbounded" minOccurs="0" name="assystUsers" nillable="true" type="assystUserDto"/>
        /// </summary>

        [JsonPropertyName("assystUsers")]
        public object? AssystUsers { get; set; }


        [JsonPropertyName("auditLaneChanges")]
        public bool? AuditLaneChanges { get; set; }


        [JsonPropertyName("autoAssPend")]
        public bool? AutoAssPend { get; set; }


        [JsonPropertyName("autoAssign")]
        public bool? AutoAssign { get; set; }


        [JsonPropertyName("autoPopulateItemB")]
        public bool? AutoPopulateItemB { get; set; }


        /// <summary>
        /// 
        /// Data Type : availabilityDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" maxOccurs="unbounded" minOccurs="0" name="availability" nillable="true" type="availabilityDto"/>
        /// </summary>

        [JsonPropertyName("availability")]
        public object? Availability { get; set; }


        /// <summary>
        /// 
        /// Data Type : servDeptActionDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceDepartmentActionTypes" maxOccurs="unbounded" minOccurs="0" name="availableActions" nillable="true" type="servDeptActionDto"/>
        /// </summary>

        [JsonPropertyName("availableActions")]
        public object? AvailableActions { get; set; }


        /// <summary>
        /// 
        /// Data Type : servDeptModelEventDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" maxOccurs="unbounded" minOccurs="0" name="availableModelEvents" nillable="true" type="servDeptModelEventDto"/>
        /// </summary>

        [JsonPropertyName("availableModelEvents")]
        public object? AvailableModelEvents { get; set; }


        [JsonPropertyName("changeActions")]
        public bool? ChangeActions { get; set; }


        [JsonPropertyName("clearForm")]
        public bool? ClearForm { get; set; }


        [JsonPropertyName("closeCosting")]
        public bool? CloseCosting { get; set; }


        [JsonPropertyName("closeDetail")]
        public bool? CloseDetail { get; set; }


        [JsonPropertyName("closeTime")]
        public bool? CloseTime { get; set; }


        [JsonPropertyName("defLogItem")]
        public bool? DefLogItem { get; set; }


        /// <summary>
        /// 
        /// Data Type : slaDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceLevelAgreements" minOccurs="0" name="defaultOla" type="slaDto"/>
        /// </summary>

        [JsonPropertyName("defaultOla")]
        public object? DefaultOla { get; set; }


        [JsonPropertyName("defaultOlaId")]
        public int? DefaultOlaId { get; set; }


        [JsonPropertyName("displayAlertsAtEventSave")]
        public bool? DisplayAlertsAtEventSave { get; set; }


        [JsonPropertyName("displayAlertsDuringLogging")]
        public bool? DisplayAlertsDuringLogging { get; set; }


        [JsonPropertyName("displayEventNo")]
        public bool? DisplayEventNo { get; set; }


        /// <summary>
        /// 
        /// Data Type : docketDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="docket" type="docketDto"/>
        /// </summary>

        [JsonPropertyName("docket")]
        public object? Docket { get; set; }


        [JsonPropertyName("docketDestinationAddress")]
        public string? DocketDestinationAddress { get; set; }


        [JsonPropertyName("docketId")]
        public int? DocketId { get; set; }


        [JsonPropertyName("docketType")]
        public int? DocketType { get; set; }


        /// <summary>
        /// 
        /// Data Type : servDeptEmailTemplateDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/servDeptEmailTemplates" maxOccurs="unbounded" minOccurs="0" name="emailTemplates" nillable="true" type="servDeptEmailTemplateDto"/>
        /// </summary>

        [JsonPropertyName("emailTemplates")]
        public object? EmailTemplates { get; set; }


        /// <summary>
        /// 
        /// Data Type : supplierDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/suppliers" minOccurs="0" name="equivSupplier" type="supplierDto"/>
        /// </summary>

        [JsonPropertyName("equivSupplier")]
        public object? EquivSupplier { get; set; }


        [JsonPropertyName("equivSupplierId")]
        public int? EquivSupplierId { get; set; }


        /// <summary>
        /// 
        /// Data Type : durationDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="estimate" type="durationDto"/>
        /// </summary>

        [JsonPropertyName("estimate")]
        public object? Estimate { get; set; }


        [JsonPropertyName("eventBuilderForCause")]
        public bool? EventBuilderForCause { get; set; }


        /// <summary>
        /// 
        /// Data Type : assystUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assystUsers" maxOccurs="unbounded" minOccurs="0" name="feedbackManagers" nillable="true" type="assystUserDto"/>
        /// </summary>

        [JsonPropertyName("feedbackManagers")]
        public object? FeedbackManagers { get; set; }


        [JsonPropertyName("groupLicencesInUse")]
        public int? GroupLicencesInUse { get; set; }


        [JsonPropertyName("incLocation")]
        public int? IncLocation { get; set; }


        [JsonPropertyName("inclAssignmentCount")]
        public bool? InclAssignmentCount { get; set; }


        [JsonPropertyName("mailAffUsrClosing")]
        public bool? MailAffUsrClosing { get; set; }


        [JsonPropertyName("mailAffUsrLogging")]
        public bool? MailAffUsrLogging { get; set; }


        [JsonPropertyName("mailRepUsrClosing")]
        public bool? MailRepUsrClosing { get; set; }


        [JsonPropertyName("mailRepUsrLogging")]
        public bool? MailRepUsrLogging { get; set; }


        [JsonPropertyName("majorIncCosting")]
        public bool? MajorIncCosting { get; set; }


        [JsonPropertyName("majorIncDetail")]
        public bool? MajorIncDetail { get; set; }


        [JsonPropertyName("majorIncTime")]
        public bool? MajorIncTime { get; set; }


        /// <summary>
        /// 
        /// Data Type : assystUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assystUsers" maxOccurs="unbounded" minOccurs="0" name="managers" nillable="true" type="assystUserDto"/>
        /// </summary>

        [JsonPropertyName("managers")]
        public object? Managers { get; set; }


        [JsonPropertyName("mandCauseCat")]
        public bool? MandCauseCat { get; set; }


        [JsonPropertyName("mandCauseItem")]
        public bool? MandCauseItem { get; set; }


        [JsonPropertyName("mandChangeCallBackRemark")]
        public bool? MandChangeCallBackRemark { get; set; }


        [JsonPropertyName("mandChangeShortDesc")]
        public bool? MandChangeShortDesc { get; set; }


        [JsonPropertyName("mandCharge")]
        public bool? MandCharge { get; set; }


        [JsonPropertyName("mandDept")]
        public bool? MandDept { get; set; }


        [JsonPropertyName("mandExt")]
        public bool? MandExt { get; set; }


        [JsonPropertyName("mandIncidentCallBackRemark")]
        public bool? MandIncidentCallBackRemark { get; set; }


        [JsonPropertyName("mandIncidentShortDesc")]
        public bool? MandIncidentShortDesc { get; set; }


        [JsonPropertyName("mandProblemCallBackRemark")]
        public bool? MandProblemCallBackRemark { get; set; }


        [JsonPropertyName("mandProblemShortDesc")]
        public bool? MandProblemShortDesc { get; set; }


        [JsonPropertyName("mandReportingUser")]
        public bool? MandReportingUser { get; set; }


        [JsonPropertyName("mandRequiredBy")]
        public bool? MandRequiredBy { get; set; }


        [JsonPropertyName("mandRoom")]
        public bool? MandRoom { get; set; }


        [JsonPropertyName("mandScheduledEndDate")]
        public bool? MandScheduledEndDate { get; set; }


        [JsonPropertyName("mandScheduledStartDate")]
        public bool? MandScheduledStartDate { get; set; }


        [JsonPropertyName("mandTele")]
        public bool? MandTele { get; set; }


        /// <summary>
        /// Describes the assyst users who are members of this Service Department through their secondary Service Department
        /// Data Type : secondaryServDeptDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="Describes the assyst users who are members of this Service Department through their secondary Service Department" axios:resourcePath="/secondaryServiceDepartments" maxOccurs="unbounded" minOccurs="0" name="members" nillable="true" type="secondaryServDeptDto"/>
        /// </summary>

        [JsonPropertyName("members")]
        public object? Members { get; set; }


        /// <summary>
        /// 
        /// Data Type : modelEventDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/modelEvents" maxOccurs="unbounded" minOccurs="0" name="modelEvents" nillable="true" type="modelEventDto"/>
        /// </summary>

        [JsonPropertyName("modelEvents")]
        public object? ModelEvents { get; set; }


        /// <summary>
        /// 
        /// Data Type : servDeptDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceDepartments" minOccurs="0" name="nextSvd" type="servDeptDto"/>
        /// </summary>

        [JsonPropertyName("nextSvd")]
        public object? NextSvd { get; set; }


        [JsonPropertyName("nextSvdId")]
        public int? NextSvdId { get; set; }


        [JsonPropertyName("normalActCosting")]
        public bool? NormalActCosting { get; set; }


        [JsonPropertyName("normalActDetail")]
        public bool? NormalActDetail { get; set; }


        [JsonPropertyName("normalActTime")]
        public bool? NormalActTime { get; set; }


        [JsonPropertyName("pendingCosting")]
        public bool? PendingCosting { get; set; }


        [JsonPropertyName("pendingDetail")]
        public bool? PendingDetail { get; set; }


        [JsonPropertyName("pendingDock")]
        public bool? PendingDock { get; set; }


        [JsonPropertyName("pendingTime")]
        public bool? PendingTime { get; set; }


        [JsonPropertyName("prePopulateLoggingDate")]
        public bool? PrePopulateLoggingDate { get; set; }


        [JsonPropertyName("remoteDesktop")]
        public bool? RemoteDesktop { get; set; }


        [JsonPropertyName("reopenCosting")]
        public bool? ReopenCosting { get; set; }


        [JsonPropertyName("reopenDetail")]
        public bool? ReopenDetail { get; set; }


        [JsonPropertyName("reopenTime")]
        public bool? ReopenTime { get; set; }


        [JsonPropertyName("resolutionActionForAuthorisationTask")]
        public int? ResolutionActionForAuthorisationTask { get; set; }


        [JsonPropertyName("resolutionActionForKnowledgeSolve")]
        public int? ResolutionActionForKnowledgeSolve { get; set; }


        [JsonPropertyName("restrictLogging")]
        public bool? RestrictLogging { get; set; }


        /// <summary>
        /// 
        /// Data Type : servDeptGroupDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="servDeptGroup" type="servDeptGroupDto"/>
        /// </summary>

        [JsonPropertyName("servDeptGroup")]
        public object? ServDeptGroup { get; set; }


        [JsonPropertyName("servDeptGroupId")]
        public int? ServDeptGroupId { get; set; }


        [JsonPropertyName("setState")]
        public bool? SetState { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="shiftDetails"/>
         */


        [JsonPropertyName("shiftDetailsId")]
        public int? ShiftDetailsId { get; set; }


        [JsonPropertyName("specSla")]
        public bool? SpecSla { get; set; }


        [JsonPropertyName("statusCosting")]
        public bool? StatusCosting { get; set; }


        [JsonPropertyName("statusDetail")]
        public bool? StatusDetail { get; set; }


        [JsonPropertyName("statusTime")]
        public bool? StatusTime { get; set; }


        [JsonPropertyName("suggestSla")]
        public bool? SuggestSla { get; set; }


        [JsonPropertyName("suppActCosting")]
        public bool? SuppActCosting { get; set; }


        [JsonPropertyName("suppActDetail")]
        public bool? SuppActDetail { get; set; }


        [JsonPropertyName("suppActTime")]
        public bool? SuppActTime { get; set; }


        [JsonPropertyName("suppAssCosting")]
        public bool? SuppAssCosting { get; set; }


        [JsonPropertyName("suppAssDetail")]
        public bool? SuppAssDetail { get; set; }


        [JsonPropertyName("suppAssTime")]
        public bool? SuppAssTime { get; set; }


        [JsonPropertyName("suppReopenCosting")]
        public bool? SuppReopenCosting { get; set; }


        [JsonPropertyName("suppReopenDetail")]
        public bool? SuppReopenDetail { get; set; }


        [JsonPropertyName("suppReopenTime")]
        public bool? SuppReopenTime { get; set; }


        [JsonPropertyName("suppRespCosting")]
        public bool? SuppRespCosting { get; set; }


        [JsonPropertyName("suppRespDetail")]
        public bool? SuppRespDetail { get; set; }


        [JsonPropertyName("suppRespTime")]
        public bool? SuppRespTime { get; set; }


        [JsonPropertyName("suppRslveCosting")]
        public bool? SuppRslveCosting { get; set; }


        [JsonPropertyName("suppRslveDetail")]
        public bool? SuppRslveDetail { get; set; }


        [JsonPropertyName("suppRslveTime")]
        public bool? SuppRslveTime { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="taskboard"/>
         */


        [JsonPropertyName("taskboardId")]
        public int? TaskboardId { get; set; }


        [JsonPropertyName("timeZoneEnabled")]
        public bool? TimeZoneEnabled { get; set; }


        [JsonPropertyName("timeZoneOffset")]
        public double? TimeZoneOffset { get; set; }


        [JsonPropertyName("translationModifyDate")]
        public DateTime? TranslationModifyDate { get; set; }


        /// <summary>
        /// 
        /// Data Type : servDeptDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceDepartments" maxOccurs="unbounded" minOccurs="0" name="translations" nillable="true" type="servDeptDto"/>
        /// </summary>

        [JsonPropertyName("translations")]
        public object? Translations { get; set; }


        [JsonPropertyName("uFlag2")]
        public bool? UFlag2 { get; set; }


        [JsonPropertyName("uFlag3")]
        public bool? UFlag3 { get; set; }


        [JsonPropertyName("uFlag4")]
        public bool? UFlag4 { get; set; }


        [JsonPropertyName("useUsrItem")]
        public bool? UseUsrItem { get; set; }


        /// <summary>
        /// 
        /// Data Type : durationDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="userCapacity" type="durationDto"/>
        /// </summary>

        [JsonPropertyName("userCapacity")]
        public object? UserCapacity { get; set; }


        [JsonPropertyName("usrSc")]
        public bool? UsrSc { get; set; }

    }

}
