using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.Assyst
{


    public static class ActionTypeIds
    {
        public static int AcknowledgmentActionTypeId => 3;
        public static int WaitingOnCustomerInputActionTypeId => 189;
        public static int CustomerInputReceivedActionTypeId => 190;
        public static int CommentActionTypeId => 434;
        public static int AdditionalInformationActionTypeId => 42;
    }


    public class ActionTypeDto : AssystBaseDto
    {


        [JsonPropertyName("acknowledgementRequired")]
        public bool? AcknowledgementRequired { get; set; }


        /// <summary>
        /// 
        /// Data Type : actionTypeCategory
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="actionTypeCategory" type="actionTypeCategory"/>
        /// </summary>

        [JsonPropertyName("actionTypeCategory")]
        public object? ActionTypeCategory { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="activityCategory"/>
         */


        [JsonPropertyName("activityCategoryId")]
        public int? ActivityCategoryId { get; set; }


        [JsonPropertyName("affectedUserAllowed")]
        public bool? AffectedUserAllowed { get; set; }


        [JsonPropertyName("affectedUserMandatory")]
        public bool? AffectedUserMandatory { get; set; }


        /// <summary>
        /// 
        /// Data Type : servDeptActionDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceDepartmentActionTypes" maxOccurs="unbounded" minOccurs="0" name="availableServDepts" nillable="true" type="servDeptActionDto"/>
        /// </summary>

        [JsonPropertyName("availableServDepts")]
        public object? AvailableServDepts { get; set; }


        [JsonPropertyName("clockActionFlag")]
        public bool? ClockActionFlag { get; set; }


        /// <summary>
        /// 
        /// Data Type : attachedProcessDecisionDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/attachedProcessDecisions" maxOccurs="unbounded" minOccurs="0" name="decisions" nillable="true" type="attachedProcessDecisionDto"/>
        /// </summary>

        [JsonPropertyName("decisions")]
        public object? Decisions { get; set; }


        [JsonPropertyName("emailActionFlag")]
        public bool? EmailActionFlag { get; set; }


        [JsonPropertyName("futureActionFlag")]
        public bool? FutureActionFlag { get; set; }


        [JsonPropertyName("isConflictAware")]
        public bool? IsConflictAware { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="job"/>
         */

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="knowledgeProcedure"/>
         */


        [JsonPropertyName("knowledgeProcedureId")]
        public int? KnowledgeProcedureId { get; set; }


        [JsonPropertyName("lockingStatus")]
        public int? LockingStatus { get; set; }


        [JsonPropertyName("mailAffectedUser")]
        public bool? MailAffectedUser { get; set; }


        [JsonPropertyName("mailLoggingServDept")]
        public bool? MailLoggingServDept { get; set; }


        [JsonPropertyName("mailLoggingUser")]
        public bool? MailLoggingUser { get; set; }


        [JsonPropertyName("mailReportingUser")]
        public bool? MailReportingUser { get; set; }


        [JsonPropertyName("mailServDept")]
        public bool? MailServDept { get; set; }


        [JsonPropertyName("mandatoryDescription")]
        public bool? MandatoryDescription { get; set; }


        [JsonPropertyName("normalActionFlag")]
        public bool? NormalActionFlag { get; set; }


        [JsonPropertyName("popupActionFlag")]
        public bool? PopupActionFlag { get; set; }


        [JsonPropertyName("privateActionFlag")]
        public bool? PrivateActionFlag { get; set; }


        [JsonPropertyName("showInImpactExplorer")]
        public bool? ShowInImpactExplorer { get; set; }


        /// <summary>
        /// 
        /// Data Type : attachedProcessStageDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/attachedProcessStages" minOccurs="0" name="stage" type="attachedProcessStageDto"/>
        /// </summary>

        [JsonPropertyName("stage")]
        public object? Stage { get; set; }


        [JsonPropertyName("stageActionFlag")]
        public bool? StageActionFlag { get; set; }


        [JsonPropertyName("stageId")]
        public int? StageId { get; set; }


        [JsonPropertyName("stateActionFlag")]
        public bool? StateActionFlag { get; set; }


        [JsonPropertyName("suggestedActionFlag")]
        public bool? SuggestedActionFlag { get; set; }


        [JsonPropertyName("supplierActionFlag")]
        public bool? SupplierActionFlag { get; set; }


        [JsonPropertyName("systemActionFlag")]
        public bool? SystemActionFlag { get; set; }


        [JsonPropertyName("translationModifyDate")]
        public DateTime? TranslationModifyDate { get; set; }


        /// <summary>
        /// 
        /// Data Type : actionTypeDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/actionTypes" maxOccurs="unbounded" minOccurs="0" name="translations" nillable="true" type="actionTypeDto"/>
        /// </summary>

        [JsonPropertyName("translations")]
        public object? Translations { get; set; }


        [JsonPropertyName("userStatus")]
        public int? UserStatus { get; set; }


        [JsonPropertyName("userStatusActionFlag")]
        public bool? UserStatusActionFlag { get; set; }


        [JsonPropertyName("validateStageDurations")]
        public bool? ValidateStageDurations { get; set; }

    }

}
