using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.Assyst
{

    /// <summary>
    /// Represents the properties of an action that may be set by the system. Properties in this class may be overwritten by the system during an update. Only properties defined by UpdateableActionDto are guaranteed to be honoured
    /// </summary>

    public class AssystActionDto : UpdateableActionDto, IHelpDeskComment
    {


        /// <summary>
        /// Returns the number of times this type of action was taken on the event, up to and including this instance of the action. This count is based on the dataActioned values. This value is not persisted and will return null if prepopulation is not passed
        /// </summary>

        [JsonPropertyName("actionTypeCount")]
        public int? ActionTypeCount { get; set; }


        /// <summary>
        /// Returns the number of times this type of action was taken on the event, up to and including this instance of the action. This count is based on the id values. Because this is based on the ID (which is a surrogate key) it should not be relied upon to defined the chronological position of an action in the history of an event. This value is not persisted and will return null if prepopulation is not passed
        /// </summary>

        [JsonPropertyName("actionTypePosition")]
        public int? ActionTypePosition { get; set; }


        /// <summary>
        /// The supplier performing an action. Will be null/empty if this is not a supplier action.
        /// Data Type : supplierDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="The supplier performing an action. Will be null/empty if this is not a supplier action." axios:resourcePath="/suppliers" minOccurs="0" name="actioningSupplier" type="supplierDto"/>
        /// </summary>

        [JsonPropertyName("actioningSupplier")]
        public object? ActioningSupplier { get; set; }


        [JsonPropertyName("actioningSupplierId")]
        public int? ActioningSupplierId { get; set; }


        [JsonPropertyName("addCurrentAttachmentsWhenSendAsEnabled")]
        public bool? AddCurrentAttachmentsWhenSendAsEnabled { get; set; }


        /// <summary>
        /// The service department to assign to. This only has meaning in assignment actions and does not define the current event assignment, to get that refer to the event directly. This property Will be null/empty if this is not an assignmnet action type.
        /// Data Type : servDeptDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="The service department to assign to. This only has meaning in assignment actions and does not define the current event assignment, to get that refer to the event directly. This property Will be null/empty if this is not an assignmnet action type." axios:resourcePath="/serviceDepartments" minOccurs="0" name="assignedServDept" type="servDeptDto"/>
        /// </summary>

        [JsonPropertyName("assignedServDept")]
        public object? AssignedServDept { get; set; }


        [JsonPropertyName("assignedServDeptId")]
        public int? AssignedServDeptId { get; set; }


        /// <summary>
        /// The user to assign to.  This only has meaning in assignment actions and does not define the current event assignment, to get that refer to the event directly. This property Will be null/empty if this is not an assignmnet action type.
        /// Data Type : assystUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="The user to assign to.  This only has meaning in assignment actions and does not define the current event assignment, to get that refer to the event directly. This property Will be null/empty if this is not an assignmnet action type." axios:resourcePath="/assystUsers" minOccurs="0" name="assignedUser" type="assystUserDto"/>
        /// </summary>

        [JsonPropertyName("assignedUser")]
        public object? AssignedUser { get; set; }


        [JsonPropertyName("assignedUserId")]
        public int? AssignedUserId { get; set; }


        [JsonPropertyName("attachmentsToDelete")]
        public int? AttachmentsToDelete { get; set; }


        [JsonPropertyName("attachmentsToLink")]
        public int? AttachmentsToLink { get; set; }


        [JsonPropertyName("attachmentsToSend")]
        public int? AttachmentsToSend { get; set; }


        [JsonPropertyName("authenticationToken")]
        public string? AuthenticationToken { get; set; }


        /// <summary>
        /// CSV list of email addresses to use as BCC. Applies to actions that use an action type flagged as an email action
        /// </summary>

        [JsonPropertyName("bcc")]
        public string? Bcc { get; set; }


        /// <summary>
        /// CSV list of email addresses to use as CC. Applies to actions that use an action type flagged as an email action
        /// </summary>

        [JsonPropertyName("cc")]
        public string? Cc { get; set; }


        [JsonPropertyName("dateReceived")]
        public DateTime? DateReceived { get; set; }


        /// <summary>
        /// Returns the number of days that have passed since the 1st logged action of the same type as the triggering action. This value is not persisted and will return null if prepopulation is not passed
        /// </summary>

        [JsonPropertyName("daysSinceFirstAction")]
        public int? DaysSinceFirstAction { get; set; }


        /// <summary>
        /// Defines the decision made with this action. Will be null/empty if this action is not a decision action
        /// Data Type : attachedProcessDecisionDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="Defines the decision made with this action. Will be null/empty if this action is not a decision action" axios:resourcePath="/attachedProcessDecisions" minOccurs="0" name="decision" type="attachedProcessDecisionDto"/>
        /// </summary>

        [JsonPropertyName("decision")]
        public object? Decision { get; set; }


        [JsonPropertyName("decisionId")]
        public int? DecisionId { get; set; }


        /// <summary>
        /// Specifies the delegator user for this action. Will be null/empty if this has not come from a delegator user
        /// Data Type : assystUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="Specifies the delegator user for this action. Will be null/empty if this has not come from a delegator user" axios:resourcePath="/assystUsers" minOccurs="0" name="delegatorUser" type="assystUserDto"/>
        /// </summary>

        [JsonPropertyName("delegatorUser")]
        public object? DelegatorUser { get; set; }


        [JsonPropertyName("delegatorUserId")]
        public int? DelegatorUserId { get; set; }


        /// <summary>
        /// Specifies the headers for an email. Applies to actions that use an action type flagged as an email action
        /// Data Type : actionEmailHeaderDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="Specifies the headers for an email. Applies to actions that use an action type flagged as an email action" maxOccurs="unbounded" minOccurs="0" name="emailHeaders" nillable="true" type="actionEmailHeaderDto"/>
        /// </summary>

        [JsonPropertyName("emailHeaders")]
        public object? EmailHeaders { get; set; }


        /// <summary>
        /// Specifies the recipients for an email. Applies to actions that use an action type flagged as an email action
        /// Data Type : actionEmailRecipientDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="Specifies the recipients for an email. Applies to actions that use an action type flagged as an email action" maxOccurs="unbounded" minOccurs="0" name="emailRecipients" nillable="true" type="actionEmailRecipientDto"/>
        /// </summary>

        [JsonPropertyName("emailRecipients")]
        public object? EmailRecipients { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="event"/>
         */

        [JsonPropertyName("event")]
        public EventDto? Event { get; set; }


        [JsonPropertyName("eventId")]
        public int? EventId { get; set; }


        [JsonPropertyName("eventIncDataVersion")]
        public int? EventIncDataVersion { get; set; }


        [JsonPropertyName("eventVersion")]
        public int? EventVersion { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="itemMaintenance"/>
         */


        [JsonPropertyName("itemMaintenanceId")]
        public int? ItemMaintenanceId { get; set; }


        /// <summary>
        /// Specifies the external job associated with this action
        /// </summary>

        [JsonPropertyName("jobCommand")]
        public string? JobCommand { get; set; }


        [JsonPropertyName("jobKill")]
        public bool? JobKill { get; set; }


        [JsonPropertyName("jobQueueOnServer")]
        public bool? JobQueueOnServer { get; set; }


        [JsonPropertyName("jobWaitPeriod")]
        public int? JobWaitPeriod { get; set; }


        [JsonPropertyName("jobWhen")]
        public int? JobWhen { get; set; }


        [JsonPropertyName("jobWindow")]
        public int? JobWindow { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="knowledgeProcedure"/>
         */


        [JsonPropertyName("knowledgeProcedureId")]
        public int? KnowledgeProcedureId { get; set; }


        [JsonPropertyName("lastAction")]
        public bool? LastAction { get; set; }


        [JsonPropertyName("nextAction")]
        public bool? NextAction { get; set; }


        [JsonPropertyName("oleItemId")]
        public int? OleItemId { get; set; }


        [JsonPropertyName("originalActionId")]
        public int? OriginalActionId { get; set; }


        /// <summary>
        /// 
        /// Data Type : actionDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/actions" minOccurs="0" name="parentAction" type="actionDto"/>
        /// </summary>

        [JsonPropertyName("parentAction")]
        public object? ParentAction { get; set; }


        [JsonPropertyName("parentActionId")]
        public int? ParentActionId { get; set; }


        [JsonPropertyName("previousModifyDate")]
        public DateTime? PreviousModifyDate { get; set; }


        [JsonPropertyName("previousModifyId")]
        public string? PreviousModifyId { get; set; }


        /// <summary>
        /// Specifies the reviewing user for this action. Will be null/empty if this is not a review request action
        /// Data Type : assystUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="Specifies the reviewing user for this action. Will be null/empty if this is not a review request action" axios:resourcePath="/assystUsers" minOccurs="0" name="reviewingUser" type="assystUserDto"/>
        /// </summary>

        [JsonPropertyName("reviewingUser")]
        public object? ReviewingUser { get; set; }


        [JsonPropertyName("reviewingUserId")]
        public int? ReviewingUserId { get; set; }


        [JsonPropertyName("sendEmail")]
        public bool? SendEmail { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="sla"/>
         */


        [JsonPropertyName("slaId")]
        public int? SlaId { get; set; }


        /// <summary>
        /// 
        /// Data Type : softLinkedAttachmentDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" maxOccurs="unbounded" minOccurs="0" name="softLinkedAttachments" nillable="true" type="softLinkedAttachmentDto"/>
        /// </summary>

        [JsonPropertyName("softLinkedAttachments")]
        public object? SoftLinkedAttachments { get; set; }


        [JsonPropertyName("sourceEventId")]
        public int? SourceEventId { get; set; }


        [JsonPropertyName("stageId")]
        public int? StageId { get; set; }


        /// <summary>
        /// Specifies the value to use as subject in an email. Applies to actions that use an action type flagged as an email action
        /// </summary>

        [JsonPropertyName("subject")]
        public string? Subject { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="surveyDefinition"/>
         */


        [JsonPropertyName("surveyDefinitionId")]
        public int? SurveyDefinitionId { get; set; }


        /// <summary>
        /// 
        /// Data Type : eventDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/events" minOccurs="0" name="templateEvent" type="eventDto"/>
        /// </summary>

        [JsonPropertyName("templateEvent")]
        public object? TemplateEvent { get; set; }


        /// <summary>
        /// CSV list of email addresses to use as TO. Applies to actions that use an action type flagged as an email action
        /// </summary>

        [JsonPropertyName("to")]
        public string? To { get; set; }


        [JsonPropertyName("uDate1")]
        public DateTime? UDate1 { get; set; }


        [JsonPropertyName("uDate2")]
        public DateTime? UDate2 { get; set; }


        [JsonPropertyName("uDate3")]
        public DateTime? UDate3 { get; set; }


        [JsonPropertyName("uDate4")]
        public DateTime? UDate4 { get; set; }


        [JsonPropertyName("uFlag1")]
        public string? UFlag1 { get; set; }


        [JsonPropertyName("uFlag2")]
        public string? UFlag2 { get; set; }


        [JsonPropertyName("uFlag3")]
        public string? UFlag3 { get; set; }


        [JsonPropertyName("uFlag4")]
        public string? UFlag4 { get; set; }


        [JsonPropertyName("uNum1")]
        public int? UNum1 { get; set; }


        [JsonPropertyName("uNum2")]
        public int? UNum2 { get; set; }


        [JsonPropertyName("uNum3")]
        public int? UNum3 { get; set; }


        [JsonPropertyName("uNum4")]
        public int? UNum4 { get; set; }


        [JsonPropertyName("uString1")]
        public string? UString1 { get; set; }


        [JsonPropertyName("uString2")]
        public string? UString2 { get; set; }

        public string CommentId => $"{Id}";

        public DateTime? CreationDate => DateActioned;

        public string? CreatedBy => null;

        public string? Title => ActionType?.Name ?? "Action";

        public string? PlainTextDescription => RichRemarks?.PlainTextContent ?? null;

        public string? RichTextDescription => RichRemarks?.Content;
    }
}
