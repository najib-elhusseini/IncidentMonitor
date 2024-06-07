using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.Assyst
{

    /// <summary>
    /// Represents the properties of an action.
    /// </summary>
    public class UpdateableActionDto : AssystBaseDto
    {
        /// <summary>
        /// This does not represent a persisted property. It may be used to default the action at logging to supply defaults for this action.
        /// Data Type : importActionProfileDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="This does not represent a persisted property. It may be used to default the action at logging to supply defaults for this action." axios:resourcePath="/importActionProfiles" minOccurs="0" name="actionImportProfile" type="importActionProfileDto"/>
        /// </summary>

        [JsonPropertyName("actionImportProfile")]
        public object? ActionImportProfile { get; set; }


        [JsonPropertyName("actionImportProfileId")]
        public int? ActionImportProfileId { get; set; }


        [JsonPropertyName("actionSuccess")]
        public bool? ActionSuccess { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="actionType"/>
         */

        [JsonPropertyName("actionType")]
        public ActionTypeDto? ActionType { get; set; }

        [JsonPropertyName("actionTypeId")]
        public int? ActionTypeId { get; set; }


        /// <summary>
        /// The user who took this action.
        /// Data Type : assystUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="The user who took this action." axios:resourcePath="/assystUsers" minOccurs="0" name="actionedBy" type="assystUserDto"/>
        /// </summary>

        [JsonPropertyName("actionedBy")]
        public AssystUserDto? ActionedBy { get; set; }


        [JsonPropertyName("actionedById")]
        public int? ActionedById { get; set; }


        /// <summary>
        /// The Service Department of the user who took this action
        /// Data Type : servDeptDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="The Service Department of the user who took this action" axios:resourcePath="/serviceDepartments" minOccurs="0" name="actioningServDept" type="servDeptDto"/>
        /// </summary>

        [JsonPropertyName("actioningServDept")]
        public object? ActioningServDept { get; set; }


        [JsonPropertyName("actioningServDeptId")]
        public int? ActioningServDeptId { get; set; }


        [JsonPropertyName("additionalDetailId")]
        public int? AdditionalDetailId { get; set; }


        [JsonPropertyName("additionalInfo1")]
        public string? AdditionalInfo1 { get; set; }


        [JsonPropertyName("additionalInfo2")]
        public string? AdditionalInfo2 { get; set; }


        [JsonPropertyName("additionalInfo3")]
        public string? AdditionalInfo3 { get; set; }


        [JsonPropertyName("additionalInfo4")]
        public string? AdditionalInfo4 { get; set; }


        /// <summary>
        /// An affected item, if there is one.
        /// Data Type : itemDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="An affected item, if there is one." axios:resourcePath="/items" minOccurs="0" name="affectedItem" type="itemDto"/>
        /// </summary>

        [JsonPropertyName("affectedItem")]
        public object? AffectedItem { get; set; }


        [JsonPropertyName("affectedItemId")]
        public int? AffectedItemId { get; set; }


        /// <summary>
        /// The affected user for this action, if there is one. This does not represent the affected user of the event itself. This is only used if the action type is configured to allow an affected user to be specified.
        /// Data Type : contactUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="The affected user for this action, if there is one. This does not represent the affected user of the event itself. This is only used if the action type is configured to allow an affected user to be specified." axios:resourcePath="/contactUsers" minOccurs="0" name="affectedUser" type="contactUserDto"/>
        /// </summary>

        [JsonPropertyName("affectedUser")]
        public object? AffectedUser { get; set; }


        /// <summary>
        /// The affected user email for this action, if there is one. This does not represent the affected user email of the event itself. This is only used if the action type is configured to allow an affected user to be specified.
        /// </summary>

        [JsonPropertyName("affectedUserEmail")]
        public string? AffectedUserEmail { get; set; }


        /// <summary>
        /// The affected user extension for this action, if there is one. This does not represent the affected user extension of the event itself. This is only used if the action type is configured to allow an affected user to be specified.
        /// </summary>

        [JsonPropertyName("affectedUserExtension")]
        public string? AffectedUserExtension { get; set; }


        [JsonPropertyName("affectedUserId")]
        public int? AffectedUserId { get; set; }


        /// <summary>
        /// The affected user name for this action, if there is one. This does not represent the affected user name of the event itself. This is only used if the action type is configured to allow an affected user to be specified.
        /// </summary>

        [JsonPropertyName("affectedUserName")]
        public string? AffectedUserName { get; set; }


        /// <summary>
        /// The affected user telephone for this action, if there is one. This does not represent the affected user telephone of the event itself. This is only used if the action type is configured to allow an affected user to be specified.
        /// </summary>

        [JsonPropertyName("affectedUserTelephone")]
        public string? AffectedUserTelephone { get; set; }


        [JsonPropertyName("assignmentTime")]
        public DurationDto? AssignmentTime { get; set; }


        /// <summary>
        /// The cause category for this action. This property Will be null/empty if this is not a resolution action type.
        /// Data Type : categoryDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="The cause category for this action. This property Will be null/empty if this is not a resolution action type." axios:resourcePath="/categories" minOccurs="0" name="causeCategory" type="categoryDto"/>
        /// </summary>

        [JsonPropertyName("causeCategory")]
        public object? CauseCategory { get; set; }


        [JsonPropertyName("causeCategoryId")]
        public int? CauseCategoryId { get; set; }


        /// <summary>
        /// The cause category for this action. This property Will be null/empty if this is not a resolution action type.
        /// Data Type : itemDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="The cause category for this action. This property Will be null/empty if this is not a resolution action type." axios:resourcePath="/items" minOccurs="0" name="causeItem" type="itemDto"/>
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


        [JsonPropertyName("dateActioned")]
        public DateTime? DateActioned { get; set; }


        [JsonPropertyName("downTime")]
        public DurationDto? DownTime { get; set; }


        [JsonPropertyName("estimate")]
        public DurationDto? Estimate { get; set; }


        /// <summary>
        /// 
        /// Data Type : importProfileDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/importProfiles" minOccurs="0" name="eventImportProfile" type="importProfileDto"/>
        /// </summary>

        [JsonPropertyName("eventImportProfile")]
        public object? EventImportProfile { get; set; }


        [JsonPropertyName("eventImportProfileId")]
        public int? EventImportProfileId { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="phase"/>
         */


        [JsonPropertyName("phaseId")]
        public int? PhaseId { get; set; }


        [JsonPropertyName("phaseSortOrder")]
        public int? PhaseSortOrder { get; set; }



        [JsonPropertyName("responseTime")]
        public DurationDto? ResponseTime { get; set; }


        [JsonPropertyName("serviceCost")]
        public double? ServiceCost { get; set; }


        [JsonPropertyName("serviceTime")]
        public DurationDto? ServiceTime { get; set; }


        [JsonPropertyName("supplierContact")]
        public string? SupplierContact { get; set; }


        [JsonPropertyName("supplierRef")]
        public string? SupplierRef { get; set; }




        [JsonPropertyName("timeToResolve")]
        public DurationDto? TimeToResolve { get; set; }


        [JsonPropertyName("timeToRespond")]
        public DurationDto? TimeToRespond { get; set; }

    }
}
