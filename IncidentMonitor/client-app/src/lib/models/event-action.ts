

/**
 * Represents the properties of an action that may be set by the system. Properties in this class may be overwritten by the system during an update. Only properties defined by UpdateableActionDto are guaranteed to be honoured
*/

import type { AssystBaseDto, DurationDto } from "./assyst-base";
import type { EventDto } from "./assyst-event";


export interface ActionDto extends UpdateableActionDto {


    /**
     * Returns the number of times this type of action was taken on the event, up to and including this instance of the action. This count is based on the dataActioned values. This value is not persisted and will return null if prepopulation is not passed
    */

    actionTypeCount?: number,

    /**
     * Returns the number of times this type of action was taken on the event, up to and including this instance of the action. This count is based on the id values. Because this is based on the ID (which is a surrogate key) it should not be relied upon to defined the chronological position of an action in the history of an event. This value is not persisted and will return null if prepopulation is not passed
    */

    actionTypePosition?: number,

    /**
     * The supplier performing an action. Will be null/empty if this is not a supplier action.
Data Type : supplierDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="The supplier performing an action. Will be null/empty if this is not a supplier action." axios:resourcePath="/suppliers" minOccurs="0" name="actioningSupplier" type="supplierDto"/>
    */

    actioningSupplier?: any,

    actioningSupplierId?: number,

    addCurrentAttachmentsWhenSendAsEnabled?: boolean,

    /**
     * The service department to assign to. This only has meaning in assignment actions and does not define the current event assignment, to get that refer to the event directly. This property Will be null/empty if this is not an assignmnet action type.
Data Type : servDeptDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="The service department to assign to. This only has meaning in assignment actions and does not define the current event assignment, to get that refer to the event directly. This property Will be null/empty if this is not an assignmnet action type." axios:resourcePath="/serviceDepartments" minOccurs="0" name="assignedServDept" type="servDeptDto"/>
    */

    assignedServDept?: any,

    assignedServDeptId?: number,

    /**
     * The user to assign to.  This only has meaning in assignment actions and does not define the current event assignment, to get that refer to the event directly. This property Will be null/empty if this is not an assignmnet action type.
Data Type : assystUserDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="The user to assign to.  This only has meaning in assignment actions and does not define the current event assignment, to get that refer to the event directly. This property Will be null/empty if this is not an assignmnet action type." axios:resourcePath="/assystUsers" minOccurs="0" name="assignedUser" type="assystUserDto"/>
    */

    assignedUser?: any,

    assignedUserId?: number,

    attachmentsToDelete?: number,

    attachmentsToLink?: number,

    attachmentsToSend?: number,

    authenticationToken?: string,

    /**
     * CSV list of email addresses to use as BCC. Applies to actions that use an action type flagged as an email action
    */

    bcc?: string,

    /**
     * CSV list of email addresses to use as CC. Applies to actions that use an action type flagged as an email action
    */

    cc?: string,

    dateReceived?: Date,

    /**
     * Returns the number of days that have passed since the 1st logged action of the same type as the triggering action. This value is not persisted and will return null if prepopulation is not passed
    */

    daysSinceFirstAction?: number,

    /**
     * Defines the decision made with this action. Will be null/empty if this action is not a decision action
Data Type : attachedProcessDecisionDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="Defines the decision made with this action. Will be null/empty if this action is not a decision action" axios:resourcePath="/attachedProcessDecisions" minOccurs="0" name="decision" type="attachedProcessDecisionDto"/>
    */

    decision?: any,

    decisionId?: number,

    /**
     * Specifies the delegator user for this action. Will be null/empty if this has not come from a delegator user
Data Type : assystUserDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="Specifies the delegator user for this action. Will be null/empty if this has not come from a delegator user" axios:resourcePath="/assystUsers" minOccurs="0" name="delegatorUser" type="assystUserDto"/>
    */

    delegatorUser?: any,

    delegatorUserId?: number,

    /**
     * Specifies the headers for an email. Applies to actions that use an action type flagged as an email action
Data Type : actionEmailHeaderDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="Specifies the headers for an email. Applies to actions that use an action type flagged as an email action" maxOccurs="unbounded" minOccurs="0" name="emailHeaders" nillable="true" type="actionEmailHeaderDto"/>
    */

    emailHeaders?: any,

    /**
     * Specifies the recipients for an email. Applies to actions that use an action type flagged as an email action
Data Type : actionEmailRecipientDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="Specifies the recipients for an email. Applies to actions that use an action type flagged as an email action" maxOccurs="unbounded" minOccurs="0" name="emailRecipients" nillable="true" type="actionEmailRecipientDto"/>
    */

    emailRecipients?: any,
    event?:EventDto
    eventId?: number,

    eventIncDataVersion?: number,

    eventVersion?: number,
    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="itemMaintenance"/>
     */

    itemMaintenanceId?: number,

    /**
     * Specifies the external job associated with this action
    */

    jobCommand?: string,

    jobKill?: boolean,

    jobQueueOnServer?: boolean,

    jobWaitPeriod?: number,

    jobWhen?: number,

    jobWindow?: number,
    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="knowledgeProcedure"/>
     */

    knowledgeProcedureId?: number,

    lastAction?: boolean,

    nextAction?: boolean,

    oleItemId?: number,

    originalActionId?: number,

    /**
     * 
Data Type : actionDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/actions" minOccurs="0" name="parentAction" type="actionDto"/>
    */

    parentAction?: any,

    parentActionId?: number,

    previousModifyDate?: Date,

    previousModifyId?: string,

    /**
     * Specifies the reviewing user for this action. Will be null/empty if this is not a review request action
Data Type : assystUserDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="Specifies the reviewing user for this action. Will be null/empty if this is not a review request action" axios:resourcePath="/assystUsers" minOccurs="0" name="reviewingUser" type="assystUserDto"/>
    */

    reviewingUser?: any,

    reviewingUserId?: number,

    sendEmail?: boolean,
    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="sla"/>
     */

    slaId?: number,

    /**
     * 
Data Type : softLinkedAttachmentDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" maxOccurs="unbounded" minOccurs="0" name="softLinkedAttachments" nillable="true" type="softLinkedAttachmentDto"/>
    */

    softLinkedAttachments?: any,

    sourceEventId?: number,

    stageId?: number,

    /**
     * Specifies the value to use as subject in an email. Applies to actions that use an action type flagged as an email action
    */

    subject?: string,
    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="surveyDefinition"/>
     */

    surveyDefinitionId?: number,

    /**
     * 
Data Type : eventDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/events" minOccurs="0" name="templateEvent" type="eventDto"/>
    */

    templateEvent?: any,

    /**
     * CSV list of email addresses to use as TO. Applies to actions that use an action type flagged as an email action
    */

    to?: string,

    uDate1?: Date,

    uDate2?: Date,

    uDate3?: Date,

    uDate4?: Date,

    uFlag1?: string,

    uFlag2?: string,

    uFlag3?: string,

    uFlag4?: string,

    uNum1?: number,

    uNum2?: number,

    uNum3?: number,

    uNum4?: number,

    uString1?: string,

    uString2?: string,
}



/**
 * Represents the properties of an action.
*/

export interface UpdateableActionDto extends AssystBaseDto {


    /**
     * This does not represent a persisted property. It may be used to default the action at logging to supply defaults for this action.
Data Type : importActionProfileDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="This does not represent a persisted property. It may be used to default the action at logging to supply defaults for this action." axios:resourcePath="/importActionProfiles" minOccurs="0" name="actionImportProfile" type="importActionProfileDto"/>
    */

    actionImportProfile?: any,
    actionImportProfileId?: number,
    actionSuccess?: boolean,
    actionType?: ActionTypeDto,
    actionTypeId?: number,

    /**
     * The user who took this action.
Data Type : assystUserDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="The user who took this action." axios:resourcePath="/assystUsers" minOccurs="0" name="actionedBy" type="assystUserDto"/>
    */

    actionedBy?: any,

    actionedById?: number,

    /**
     * The Service Department of the user who took this action
Data Type : servDeptDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="The Service Department of the user who took this action" axios:resourcePath="/serviceDepartments" minOccurs="0" name="actioningServDept" type="servDeptDto"/>
    */

    actioningServDept?: any,

    actioningServDeptId?: number,

    additionalDetailId?: number,

    additionalInfo1?: string,

    additionalInfo2?: string,

    additionalInfo3?: string,

    additionalInfo4?: string,

    /**
     * An affected item, if there is one.
Data Type : itemDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="An affected item, if there is one." axios:resourcePath="/items" minOccurs="0" name="affectedItem" type="itemDto"/>
    */

    affectedItem?: any,

    affectedItemId?: number,

    /**
     * The affected user for this action, if there is one. This does not represent the affected user of the event itself. This is only used if the action type is configured to allow an affected user to be specified.
Data Type : contactUserDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="The affected user for this action, if there is one. This does not represent the affected user of the event itself. This is only used if the action type is configured to allow an affected user to be specified." axios:resourcePath="/contactUsers" minOccurs="0" name="affectedUser" type="contactUserDto"/>
    */

    affectedUser?: any,

    /**
     * The affected user email for this action, if there is one. This does not represent the affected user email of the event itself. This is only used if the action type is configured to allow an affected user to be specified.
    */

    affectedUserEmail?: string,

    /**
     * The affected user extension for this action, if there is one. This does not represent the affected user extension of the event itself. This is only used if the action type is configured to allow an affected user to be specified.
    */

    affectedUserExtension?: string,

    affectedUserId?: number,

    /**
     * The affected user name for this action, if there is one. This does not represent the affected user name of the event itself. This is only used if the action type is configured to allow an affected user to be specified.
    */

    affectedUserName?: string,

    /**
     * The affected user telephone for this action, if there is one. This does not represent the affected user telephone of the event itself. This is only used if the action type is configured to allow an affected user to be specified.
    */

    affectedUserTelephone?: string,

    /**
     * 
Data Type : durationDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="assignmentTime" type="durationDto"/>
    */

    assignmentTime?: any,

    /**
     * The cause category for this action. This property Will be null/empty if this is not a resolution action type.
Data Type : categoryDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="The cause category for this action. This property Will be null/empty if this is not a resolution action type." axios:resourcePath="/categories" minOccurs="0" name="causeCategory" type="categoryDto"/>
    */

    causeCategory?: any,

    causeCategoryId?: number,

    /**
     * The cause category for this action. This property Will be null/empty if this is not a resolution action type.
Data Type : itemDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="The cause category for this action. This property Will be null/empty if this is not a resolution action type." axios:resourcePath="/items" minOccurs="0" name="causeItem" type="itemDto"/>
    */

    causeItem?: any,

    causeItemId?: number,
    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="chargeCode"/>
     */

    chargeCodeId?: number,

    dateActioned?: Date,

    /**
     * 
Data Type : durationDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="downTime" type="durationDto"/>
    */

    downTime?: any,

    /**
     * 
Data Type : durationDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="estimate" type="durationDto"/>
    */

    estimate?: any,

    /**
     * 
Data Type : importProfileDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/importProfiles" minOccurs="0" name="eventImportProfile" type="importProfileDto"/>
    */

    eventImportProfile?: any,

    eventImportProfileId?: number,
    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="phase"/>
     */

    phaseId?: number,
    phaseSortOrder?: number,
    responseTime?: DurationDto,
    serviceCost?: number,
    serviceTime?: DurationDto,
    supplierContact?: string,
    supplierRef?: string,
    timeToResolve?: DurationDto,
    timeToRespond?: DurationDto,
}



export interface ActionTypeDto extends AssystBaseDto {


    acknowledgementRequired?: boolean,

    /**
     * 
   Data Type : actionTypeCategory
   Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="actionTypeCategory" type="actionTypeCategory"/>
    */

    actionTypeCategory?: any,
    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="activityCategory"/>
     */

    activityCategoryId?: number,

    affectedUserAllowed?: boolean,

    affectedUserMandatory?: boolean,

    /**
     * 
   Data Type : servDeptActionDto
   Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceDepartmentActionTypes" maxOccurs="unbounded" minOccurs="0" name="availableServDepts" nillable="true" type="servDeptActionDto"/>
    */

    availableServDepts?: any,

    clockActionFlag?: boolean,

    /**
     * 
   Data Type : attachedProcessDecisionDto
   Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/attachedProcessDecisions" maxOccurs="unbounded" minOccurs="0" name="decisions" nillable="true" type="attachedProcessDecisionDto"/>
    */

    decisions?: any,

    emailActionFlag?: boolean,

    futureActionFlag?: boolean,

    isConflictAware?: boolean,
    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="job"/>
     */
    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="knowledgeProcedure"/>
     */

    knowledgeProcedureId?: number,

    lockingStatus?: number,

    mailAffectedUser?: boolean,

    mailLoggingServDept?: boolean,

    mailLoggingUser?: boolean,

    mailReportingUser?: boolean,

    mailServDept?: boolean,

    mandatoryDescription?: boolean,

    normalActionFlag?: boolean,

    popupActionFlag?: boolean,

    privateActionFlag?: boolean,

    showInImpactExplorer?: boolean,

    /**
     * 
   Data Type : attachedProcessStageDto
   Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/attachedProcessStages" minOccurs="0" name="stage" type="attachedProcessStageDto"/>
    */

    stage?: any,

    stageActionFlag?: boolean,

    stageId?: number,

    stateActionFlag?: boolean,

    suggestedActionFlag?: boolean,

    supplierActionFlag?: boolean,

    systemActionFlag?: boolean,

    translationModifyDate?: Date,

    /**
     * 
   Data Type : actionTypeDto
   Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/actionTypes" maxOccurs="unbounded" minOccurs="0" name="translations" nillable="true" type="actionTypeDto"/>
    */

    translations?: any,

    userStatus?: number,

    userStatusActionFlag?: boolean,

    validateStageDurations?: boolean,
}
