

/**
 * Represents the properties of an event.
*/

import type { eventStatus, eventTypesEnum } from "./assyst";
import type { AssystBaseCSGDto } from "./assyst-base";
import type { DepartmentDto, ServDeptDto } from "./assyst-department";
import type { AssystUserDto } from "./assyst-user";
import type { ActionDto } from "./event-action";
import type { IncidentespondedStatus } from "./remedy_force";
import type { ServiceOfferingDto } from "./service-offering";

export interface ClientUpdatableEventDto extends AssystBaseCSGDto {
    /**
     * Defines the list of additional affected users associated with an event.
/// Data Type : contactUserDto
/// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="Defines the list of additional affected users associated with an event." axios:resourcePath="/contactUsers" maxOccurs="unbounded" minOccurs="0" name="additionalAffectedUsers" nillable="true" type="contactUserDto"/>
    */
    additionalAffectedUsers?: any,
    additionalAffectedUsersCount?: number,
    additionalRequirements?: string,
    /**
     * 
/// Data Type : contactUserDto
/// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/contactUsers" minOccurs="0" name="affectedUser" type="contactUserDto"/>
    */
    affectedUser?: any,
    affectedUserEmail?: string,
    affectedUserId?: number,
    /**
     * Setting only the affected user name signifies an anonymous user.
    */

    affectedUserName?: string,


    affectedUserTelephone?: string,


    affectedUserTelephoneExtension?: string,

    assignedServDept?: ServDeptDto,


    assignedServDeptId?: number,




    assignedUser?: AssystUserDto,


    assignedUserId?: number,

    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="attachedProcess"/>
     */


    attachedProcessId?: number,

    authorisationDate?: Date,
    /**
     * 
/// Data Type : contactUserDto
/// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/contactUsers" minOccurs="0" name="authorisingUser" type="contactUserDto"/>
    */
    authorisingUser?: any,
    authorisingUserId?: number,


    callbackRemark?: string,


    callbackRequired?: boolean,

    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="category"/>
     */


    categoryId?: number,


    chargeFlag?: number,


    /**
     * 
/// Data Type : chargeFlagTypesEnum
/// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="chargeFlagEnum" type="chargeFlagTypesEnum"/>
    */

    chargeFlagEnum?: any,

    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="costCentre"/>
     */


    costCentreId?: number,


    /**
     * 
/// Data Type : phaseDto
/// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/phases" minOccurs="0" name="currentPhase" type="phaseDto"/>
    */

    currentPhase?: any,


    dateLogged?: Date,



    department?: DepartmentDto
    departmentId?: number,


    downFlag?: boolean,


    /**
     * 
/// Data Type : durationDto
/// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="estimate" type="durationDto"/>
    */

    estimate?: any,


    eventCost?: number,


    /**
     * 
/// Data Type : csgDto
/// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/csgs" minOccurs="0" name="filteringCsg" type="csgDto"/>
    */

    filteringCsg?: any,


    filteringCsgId?: number,


    /**
     * 
/// Data Type : seriousnessDto
/// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/seriousnesses" minOccurs="0" name="impact" type="seriousnessDto"/>
    */

    impact?: any,


    impactId?: number,

    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="importProfile"/>
     */


    importProfileId?: number,


    incDataVersion?: number,


    /**
     * 
/// Data Type : itemDto
/// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/items" minOccurs="0" name="itemA" type="itemDto"/>
    */

    itemA?: any,


    itemAId?: number,


    /**
     * 
/// Data Type : itemDto
/// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/items" minOccurs="0" name="itemB" type="itemDto"/>
    */

    itemB?: any,


    itemBId?: number,


    justification?: string,


    /**
     * 
/// Data Type : linkedItemGroupDto
/// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/linkedItemGroups" maxOccurs="unbounded" minOccurs="0" name="linkedItemGroups" nillable="true" type="linkedItemGroupDto"/>
    */

    linkedItemGroups?: any,


    linkedItemsCount?: number,


    /**
     * 
/// Data Type : phaseEventDto
/// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/phaseEvents" maxOccurs="unbounded" minOccurs="0" name="phaseEvents" nillable="true" type="phaseEventDto"/>
    */

    phaseEvents?: any,

    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="priority"/>
     */

    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="priorityDerived"/>
     */


    priorityDerivedId?: number,


    priorityId?: number,

    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="project"/>
     */


    projectId?: number,


    quantity?: number,


    receiveSourceType?: number,


    /**
     * 
/// Data Type : receiveSourceTypesEnum
/// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="receiveSourceTypeEnum" type="receiveSourceTypesEnum"/>
    */

    receiveSourceTypeEnum?: any,


    /**
     * 
/// Data Type : contactUserDto
/// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/contactUsers" minOccurs="0" name="reportingUser" type="contactUserDto"/>
    */

    reportingUser?: any,


    reportingUserId?: number,


    reportingUserName?: string,


    reportingUserTelephone?: string,


    reportingUserTelephoneExtension?: string,


    requiredByDate?: Date,


    /**
     * 
/// Data Type : servDeptDto
/// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceDepartments" minOccurs="0" name="responsibleBServDept" type="servDeptDto"/>
    */

    responsibleBServDept?: any,


    responsibleBServDeptId?: number,


    /**
     * 
/// Data Type : assystUserDto
/// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assystUsers" minOccurs="0" name="responsibleBUser" type="assystUserDto"/>
    */

    responsibleBUser?: any,


    responsibleBUserId?: number,


    /**
     * 
/// Data Type : servDeptDto
/// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceDepartments" minOccurs="0" name="responsibleServDept" type="servDeptDto"/>
    */

    responsibleServDept?: any,


    responsibleServDeptId?: number,


    /**
     * 
/// Data Type : assystUserDto
/// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assystUsers" minOccurs="0" name="responsibleUser" type="assystUserDto"/>
    */

    responsibleUser?: any,


    responsibleUserId?: number,

    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="room"/>
     */


    roomId?: number,


    scheduledEndDate?: Date,


    scheduledStartDate?: Date,


    /**
     * When an event is created from another event this property defines the event which is the seed.  Property/Event is also used when creating tasks outwith processes.  The seed event determines what the new task is linked to and, depending on the client, what SLA is to be initially defaulted
/// Data Type : eventDto
/// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="When an event is created from another event this property defines the event which is the seed.  Property/Event is also used when creating tasks outwith processes.  The seed event determines what the new task is linked to and, depending on the client, what SLA is to be initially defaulted" axios:resourcePath="/events" minOccurs="0" name="seedEvent" type="eventDto"/>
    */

    seedEvent?: any,


    seedEventId?: number,

    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="seriousness"/>
     */


    seriousnessId?: number,


    shortDescription?: string,


    /**
     * 
/// Data Type : siteVisitRequiredEnum
/// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="siteVisitRequired" type="siteVisitRequiredEnum"/>
    */

    siteVisitRequired?: any,

    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="sla"/>
     */


    slaId?: number,


    startProcess?: boolean,


    stateActionSeedEvId?: number,


    /**
     * The link reason id used to automatically link a newly created Event with type of EventTypesEnum.NORMALTASK. This field is not persisted.
    */

    taskLinkReasonId?: number,


    /**
     * The id of an EventDto used to seed a newly created Event with type of EventTypesEnum.NORMALTASK. This field is not persisted.
    */

    taskSeedEventId?: number,


    /**
     * 
/// Data Type : servDeptDto
/// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceDepartments" minOccurs="0" name="technicalServDept" type="servDeptDto"/>
    */

    technicalServDept?: any,


    technicalServDeptId?: number,


    /**
     * 
/// Data Type : assystUserDto
/// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assystUsers" minOccurs="0" name="technicalUser" type="assystUserDto"/>
    */

    technicalUser?: any,


    technicalUserId?: number,

    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="templateProcess"/>
     */


    templateProcessId?: number,


    /**
     * 
/// Data Type : priorityDto
/// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/priorities" minOccurs="0" name="urgency" type="priorityDto"/>
    */

    urgency?: any,


    urgencyId?: number,


    user1FieldChar1?: string,


    user1FieldChar1Id?: number,


    user1FieldChar2?: string,


    user1FieldChar2Id?: number,


    user1FieldChar3?: string,


    user1FieldChar3Id?: number,


    user1FieldDate1?: Date,


    user1FieldDate2?: Date,


    user1FieldDate3?: Date,


    user1FieldDec1?: number,


    user1FieldDec2?: number,


    user1FieldDec3?: number,


    user2FieldChar1?: string,


    user2FieldChar1Id?: number,


    user2FieldChar2?: string,


    user2FieldChar2Id?: number,


    user2FieldChar3?: string,


    user2FieldChar3Id?: number,


    user2FieldDate1?: Date,


    user2FieldDate2?: Date,


    user2FieldDate3?: Date,


    user2FieldDec1?: number,


    user2FieldDec2?: number,


    user2FieldDec3?: number,


    userReference?: string,

}



/**
 * Represents the properties of an event that may be set by the system. Properties in this class may be overwritten by the system during an update. Only properties defined by UpdateableEventDto are guaranteed to be honoured
*/

export interface EventDto extends ClientUpdatableEventDto {


    actTypeId?: number,

    actionCount?: number,

    actionFilteringSuspended?: boolean,

    /**
     * 
Data Type : actionDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/actions" maxOccurs="unbounded" minOccurs="0" name="actions" nillable="true" type="actionDto"/>
    */

    actions?: ActionDto[],

    /**
     * 
Data Type : additionalAffectedUserDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" maxOccurs="unbounded" minOccurs="0" name="additionalAffectedUserDetails" nillable="true" type="additionalAffectedUserDto"/>
    */

    additionalAffectedUserDetails?: any,

    alertStatus?: number,

    /**
     * This is not a persisted property. It can be prepopulated as part of a GET only
Data Type : alertStatusDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="This is not a persisted property. It can be prepopulated as part of a GET only" axios:resourcePath="/alertStatuses" minOccurs="0" name="alertStatusAtLogging" type="alertStatusDto"/>
    */

    alertStatusAtLogging?: any,

    /**
     * 
Data Type : alertStatusTypesEnum
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="alertStatusEnum" type="alertStatusTypesEnum"/>
    */

    alertStatusEnum?: any,

    /**
     * 
Data Type : supplierDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/suppliers" minOccurs="0" name="assignedSupplier" type="supplierDto"/>
    */

    assignedSupplier?: any,

    assignedSupplierId?: number,

    assignmentCount?: number,

    /**
     * 
Data Type : eventDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/events" maxOccurs="unbounded" minOccurs="0" name="bundleComponentEvents" nillable="true" type="eventDto"/>
    */

    bundleComponentEvents?: any,

    bundleComponentSortOrder?: number,

    /**
     * 
Data Type : eventDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/events" minOccurs="0" name="bundleEvent" type="eventDto"/>
    */

    bundleEvent?: any,

    bundleEventFormattedReference?: string,

    bundleEventId?: number,

    bundleType?: number,

    /**
     * 
Data Type : bundleTypesEnum
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="bundleTypeEnum" type="bundleTypesEnum"/>
    */

    bundleTypeEnum?: any,

    callbackDate?: Date,

    /**
     * 
Data Type : assystUserDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assystUsers" minOccurs="0" name="callbackUser" type="assystUserDto"/>
    */

    callbackUser?: any,

    callbackUserId?: number,

    /**
     * 
Data Type : categoryDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/categories" minOccurs="0" name="causeCategory" type="categoryDto"/>
    */

    causeCategory?: any,

    causeCategoryId?: number,

    /**
     * 
Data Type : itemDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/items" minOccurs="0" name="causeItem" type="itemDto"/>
    */

    causeItem?: any,

    causeItemId?: number,
    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="chargeCode"/>
     */

    chargeCodeId?: number,

    /**
     * 
Data Type : eventDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/events" maxOccurs="unbounded" minOccurs="0" name="childEvents" nillable="true" type="eventDto"/>
    */

    childEvents?: any,

    /**
     * 
Data Type : collaborationEventDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" maxOccurs="unbounded" minOccurs="0" name="collaborations" nillable="true" type="collaborationEventDto"/>
    */

    collaborations?: any,

    currencySymbol?: string,

    currentOlaEsc?: number,

    currentSlaEsc?: number,

    /**
     * 
Data Type : actionTypeDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/actionTypes" minOccurs="0" name="currentStage" type="actionTypeDto"/>
    */

    currentStage?: any,

    currentStageId?: number,

    currentSupplierEsc?: number,
    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="customEntityDefinition"/>
     */

    databaseServerDateTime?: Date,

    dateAssignedToSupplier?: Date,

    dateEventClosed?: Date,

    dateLocked?: Date,

    dateOfLastAssignment?: Date,

    dateServDeptAcknowledged?: Date,

    /**
     * 
Data Type : attachedProcessDecisionDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/attachedProcessDecisions" maxOccurs="unbounded" minOccurs="0" name="decisionAnswers" nillable="true" type="attachedProcessDecisionDto"/>
    */

    decisionAnswers?: any,

    /**
     * Specifies the delegate user for this event. Will be null/empty if this has not come from a delegate user
Data Type : assystUserDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="Specifies the delegate user for this event. Will be null/empty if this has not come from a delegate user" axios:resourcePath="/assystUsers" minOccurs="0" name="delegateUser" type="assystUserDto"/>
    */

    delegateUser?: any,

    delegateUserId?: number,

    /**
     * 
Data Type : geographicCoordinatesDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="derivedCoordinates" type="geographicCoordinatesDto"/>
    */

    derivedCoordinates?: any,

    deskartesSolId?: number,

    /**
     * 
Data Type : durationDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="downTime" type="durationDto"/>
    */

    downTime?: any,

    earliestPossibleSlaResolveDue?: Date,

    /**
     * 
Data Type : durationDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="elapsedTime" type="durationDto"/>
    */

    elapsedTime?: any,

    /**
     * 
Data Type : durationDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="eventLoggingTime" type="durationDto"/>
    */

    eventLoggingTime?: any,

    eventRef?: number,

    eventState?: number,
    /**
     * 
Data Type : eventStateTypesEnum
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="eventStateEnum" type="eventStateTypesEnum"/>
    */
    eventStateEnum?: string | any | eventStatus,
    eventStatus?: eventStatus,
    /**
     * 
Data Type : eventStatusTypesEnum
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="eventStatusEnum" type="eventStatusTypesEnum"/>
    */
    eventStatusEnum?: any,
    eventTimezoneDateTime?: Date,

    eventType?: number,
    eventTypeEnum?: eventTypesEnum,

    externalKnowledgeDocumentId?: string,

    externalKnowledgeProblemId?: number,

    extraEventDescGroupId?: number,
    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="formDefinition"/>
     */

    /**
     * 
Data Type : customisationDetailsDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="formDefinitionPropertyExpressions" type="customisationDetailsDto"/>
    */

    formDefinitionPropertyExpressions?: any,

    formattedReference?: string,
    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="holidayPlan"/>
     */

    holidayPlanId?: number,

    incChkRef?: number,

    isLinkedEvent?: boolean,

    isLocked?: boolean,

    /**
     * 
Data Type : actionDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/actions" maxOccurs="unbounded" minOccurs="0" name="knowledgeActions" nillable="true" type="actionDto"/>
    */

    knowledgeActions?: any,
    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="knowledgeProcedure"/>
     */

    knowledgeProcedureId?: number,

    /**
     * 
Data Type : servDeptDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceDepartments" minOccurs="0" name="lastAcknowledgingServDept" type="servDeptDto"/>
    */

    lastAcknowledgingServDept?: any,

    lastAcknowledgingServDeptId?: number,

    /**
     * 
Data Type : actionDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/actions" minOccurs="0" name="lastAction" type="actionDto"/>
    */

    lastAction?: any,

    lastActionDate?: Date,

    lastActionServDeptSC?: string,

    /**
     * 
Data Type : actionTypeDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/actionTypes" minOccurs="0" name="lastActionType" type="actionTypeDto"/>
    */

    lastActionType?: any,

    lastActionTypeId?: number,

    lastActionUserSC?: string,

    /**
     * 
Data Type : servDeptDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceDepartments" minOccurs="0" name="lastCallBackServDept" type="servDeptDto"/>
    */

    lastCallBackServDept?: any,

    lastCallBackServDeptId?: number,

    /**
     * 
Data Type : servDeptDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceDepartments" minOccurs="0" name="lastClosingServDept" type="servDeptDto"/>
    */

    lastClosingServDept?: any,

    lastClosingServDeptId?: number,

    /**
     * 
Data Type : assystUserDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assystUsers" minOccurs="0" name="lastClosingUser" type="assystUserDto"/>
    */

    lastClosingUser?: any,

    lastClosingUserId?: number,

    /**
     * 
Data Type : servDeptDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceDepartments" minOccurs="0" name="lastResolvingServDept" type="servDeptDto"/>
    */

    lastResolvingServDept?: any,

    lastResolvingServDeptId?: number,

    /**
     * 
Data Type : assystUserDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assystUsers" minOccurs="0" name="lastResolvingUser" type="assystUserDto"/>
    */

    lastResolvingUser?: any,

    lastResolvingUserId?: number,

    /**
     * 
Data Type : assystUserDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assystUsers" minOccurs="0" name="lastReviewingUser" type="assystUserDto"/>
    */

    lastReviewingUser?: any,

    lastReviewingUserId?: number,

    lastSlaClockStop?: Date,

    lastSupplierActionTypeId?: number,

    lastSupplierClockStop?: Date,

    /**
     * 
Data Type : knowledgeProcedureDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/knowledgeProcedures" minOccurs="0" name="lifecycleKnowledgeProcedure" type="knowledgeProcedureDto"/>
    */

    lifecycleKnowledgeProcedure?: any,

    lifecycleKnowledgeProcedureId?: number,

    /**
     * 
Data Type : linkedEventGroupDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/linkedEventGroups" maxOccurs="unbounded" minOccurs="0" name="linkedEventGroups" nillable="true" type="linkedEventGroupDto"/>
    */

    linkedEventGroups?: any,

    linkedEventsCount?: number,

    /**
     * 
Data Type : itemDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/items" maxOccurs="unbounded" minOccurs="0" name="linkedItems" nillable="true" type="itemDto"/>
    */

    linkedItems?: any,

    /**
     * 
Data Type : contactUserDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/contactUsers" minOccurs="0" name="loggingContactUser" type="contactUserDto"/>
    */

    loggingContactUser?: any,

    loggingContactUserId?: number,

    /**
     * 
Data Type : servDeptDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceDepartments" minOccurs="0" name="loggingServDept" type="servDeptDto"/>
    */

    loggingServDept?: any,

    loggingServDeptId?: number,

    /**
     * 
Data Type : assystUserDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assystUsers" minOccurs="0" name="loggingUser" type="assystUserDto"/>
    */

    loggingUser?: any,

    loggingUserId?: number,

    /**
     * 
Data Type : eventDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/events" minOccurs="0" name="majorIncident" type="eventDto"/>
    */

    majorIncident?: any,

    majorIncidentFlag?: boolean,

    majorIncidentId?: number,

    /**
     * 
Data Type : actionDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/actions" minOccurs="0" name="nextAction" type="actionDto"/>
    */

    nextAction?: any,

    nextActionDue?: Date,

    nextActionServDeptN?: string,

    nextActionServDeptSC?: string,

    /**
     * 
Data Type : actionTypeDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/actionTypes" minOccurs="0" name="nextActionType" type="actionTypeDto"/>
    */

    nextActionType?: any,

    nextActionTypeId?: number,

    nextActionUserN?: string,

    nextActionUserSC?: string,

    /**
     * 
Data Type : olaDerivedPropertiesDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="olaDerivedProperties" type="olaDerivedPropertiesDto"/>
    */

    olaDerivedProperties?: any,

    olaEsc10Breach?: boolean,

    olaEsc10Due?: Date,

    olaEsc1Breach?: boolean,

    olaEsc1Due?: Date,

    olaEsc2Breach?: boolean,

    olaEsc2Due?: Date,

    olaEsc3Breach?: boolean,

    olaEsc3Due?: Date,

    olaEsc4Breach?: boolean,

    olaEsc4Due?: Date,

    olaEsc5Breach?: boolean,

    olaEsc5Due?: Date,

    olaEsc6Breach?: boolean,

    olaEsc6Due?: Date,

    olaEsc7Breach?: boolean,

    olaEsc7Due?: Date,

    olaEsc8Breach?: boolean,

    olaEsc8Due?: Date,

    olaEsc9Breach?: boolean,

    olaEsc9Due?: Date,

    olaFriEnd?: Date,

    olaFriStart?: Date,

    olaMonEnd?: Date,

    olaMonStart?: Date,

    olaResolveDue?: Date,

    olaResponseDue?: Date,

    olaSatEnd?: Date,

    olaSatStart?: Date,

    olaSunEnd?: Date,

    olaSunStart?: Date,

    olaThrEnd?: Date,

    olaThrStart?: Date,

    /**
     * 
Data Type : durationDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="olaTotalTimeClockStopped" type="durationDto"/>
    */

    olaTotalTimeClockStopped?: any,

    olaTueEnd?: Date,

    olaTueStart?: Date,

    olaWedEnd?: Date,

    olaWedStart?: Date,
    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="order"/>
     */

    /**
     * 
Data Type : eventDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/events" maxOccurs="unbounded" minOccurs="0" name="orderComponentEvents" nillable="true" type="eventDto"/>
    */

    orderComponentEvents?: any,

    orderId?: number,

    orderRef?: string,

    /**
     * Defines the first Service Department this Event was assigned to
Data Type : servDeptDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="Defines the first Service Department this Event was assigned to" axios:resourcePath="/serviceDepartments" minOccurs="0" name="originalAssignedServDept" type="servDeptDto"/>
    */

    originalAssignedServDept?: any,

    originalAssignedServDeptId?: number,

    originalAssignedServDeptSC?: string,

    /**
     * Defines the first assyst User this Event was assigned to
Data Type : assystUserDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="Defines the first assyst User this Event was assigned to" axios:resourcePath="/assystUsers" minOccurs="0" name="originalAssignedUser" type="assystUserDto"/>
    */

    originalAssignedUser?: any,

    originalAssignedUserId?: number,

    /**
     * 
Data Type : eventDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/events" minOccurs="0" name="parentEvent" type="eventDto"/>
    */

    parentEvent?: any,

    parentEventId?: number,

    /**
     * Defines the parent stage for this event. This property is only used with Task events and will be null/empty otherwise
Data Type : attachedProcessStageDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="Defines the parent stage for this event. This property is only used with Task events and will be null/empty otherwise" axios:resourcePath="/attachedProcessStages" minOccurs="0" name="parentStage" type="attachedProcessStageDto"/>
    */

    parentStage?: any,
    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="purchaseOrder"/>
     */

    purchaseOrderId?: number,

    /**
     * 
Data Type : attachedProcessTaskDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/attachedProcessTasks" minOccurs="0" name="relatedTaskInfo" type="attachedProcessTaskDto"/>
    */

    relatedTaskInfo?: any,

    remarksEnteredBySystem?: boolean,

    resolutionActual?: Date,

    resolutionBreached?: boolean,

    resolutionDue?: Date,

    /**
     * 
Data Type : durationDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="resolveTimeToGo" type="durationDto"/>
    */

    resolveTimeToGo?: any,

    responseActual?: Date,

    responseDue?: Date,

    responsibleUserName?: string,

    /**
     * 
Data Type : assystUserDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assystUsers" minOccurs="0" name="reviewingUser" type="assystUserDto"/>
    */

    reviewingUser?: any,

    reviewingUserId?: number,

    rfcExpiryDate?: Date,

    servDeptAcknowledgementRequired?: boolean,
    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="serviceOffering"/>
     */

    serviceOffering?:ServiceOfferingDto,

    serviceOfferingId?: number,

    skipAmendPriorityValidation?: boolean,

    skipAmendSeriousnessValidation?: boolean,

    skipExistingEventLink?: boolean,

    /**
     * 
Data Type : eventSLAChangedByTypes
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="slaChangedBy" type="eventSLAChangedByTypes"/>
    */

    slaChangedBy?: any,

    /**
     * 
Data Type : slaDerivedPropertiesDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="slaDerivedProperties" type="slaDerivedPropertiesDto"/>
    */

    slaDerivedProperties?: any,

    slaEsc10Breach?: boolean,

    slaEsc10Due?: Date,

    slaEsc1Breach?: boolean,

    slaEsc1Due?: Date,

    slaEsc2Breach?: boolean,

    slaEsc2Due?: Date,

    slaEsc3Breach?: boolean,

    slaEsc3Due?: Date,

    slaEsc4Breach?: boolean,

    slaEsc4Due?: Date,

    slaEsc5Breach?: boolean,

    slaEsc5Due?: Date,

    slaEsc6Breach?: boolean,

    slaEsc6Due?: Date,

    slaEsc7Breach?: boolean,

    slaEsc7Due?: Date,

    slaEsc8Breach?: boolean,

    slaEsc8Due?: Date,

    slaEsc9Breach?: boolean,

    slaEsc9Due?: Date,

    slaFriEnd?: Date,

    slaFriStart?: Date,

    slaMonEnd?: Date,

    slaMonStart?: Date,

    slaResolutionDue?: Date,

    slaSatEnd?: Date,

    slaSatStart?: Date,

    slaShortCode?: string,

    slaSunEnd?: Date,

    slaSunStart?: Date,

    slaThrEnd?: Date,

    slaThrStart?: Date,

    slaTimeType?: number,

    /**
     * 
Data Type : slaTimeTypesEnum
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="slaTimeTypeEnum" type="slaTimeTypesEnum"/>
    */

    slaTimeTypeEnum?: any,

    slaTueEnd?: Date,

    slaTueStart?: Date,

    slaWedEnd?: Date,

    slaWedStart?: Date,

    subEventType?: number,

    /**
     * 
Data Type : subEventTypesEnum
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="subEventTypeEnum" type="subEventTypesEnum"/>
    */

    subEventTypeEnum?: any,

    /**
     * 
Data Type : holidayPlanDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/holidayPlans" minOccurs="0" name="supHolidayPlan" type="holidayPlanDto"/>
    */

    supHolidayPlan?: any,

    supHolidayPlanId?: number,

    /**
     * 
Data Type : supplierDerivedPropertiesDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="supplierDerivedProperties" type="supplierDerivedPropertiesDto"/>
    */

    supplierDerivedProperties?: any,

    supplierEsc10Breach?: boolean,

    supplierEsc10Due?: Date,

    supplierEsc1Breach?: boolean,

    supplierEsc1Due?: Date,

    supplierEsc2Breach?: boolean,

    supplierEsc2Due?: Date,

    supplierEsc3Breach?: boolean,

    supplierEsc3Due?: Date,

    supplierEsc4Breach?: boolean,

    supplierEsc4Due?: Date,

    supplierEsc5Breach?: boolean,

    supplierEsc5Due?: Date,

    supplierEsc6Breach?: boolean,

    supplierEsc6Due?: Date,

    supplierEsc7Breach?: boolean,

    supplierEsc7Due?: Date,

    supplierEsc8Breach?: boolean,

    supplierEsc8Due?: Date,

    supplierEsc9Breach?: boolean,

    supplierEsc9Due?: Date,

    supplierRef?: string,

    supplierResolutionActual?: Date,

    supplierResolutionDue?: Date,

    supplierResponseActual?: Date,

    supplierResponseDue?: Date,

    /**
     * 
Data Type : slaDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceLevelAgreements" minOccurs="0" name="supplierSla" type="slaDto"/>
    */

    supplierSla?: any,

    supplierSlaFriEnd?: Date,

    supplierSlaFriStart?: Date,

    supplierSlaId?: number,

    supplierSlaMonEnd?: Date,

    supplierSlaMonStart?: Date,

    supplierSlaSatEnd?: Date,

    supplierSlaSatStart?: Date,

    supplierSlaShortCode?: string,

    supplierSlaSunEnd?: Date,

    supplierSlaSunStart?: Date,

    supplierSlaThrEnd?: Date,

    supplierSlaThrStart?: Date,

    supplierSlaTimeType?: number,

    /**
     * 
Data Type : slaTimeTypesEnum
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="supplierSlaTimeTypeEnum" type="slaTimeTypesEnum"/>
    */

    supplierSlaTimeTypeEnum?: any,

    supplierSlaTueEnd?: Date,

    supplierSlaTueStart?: Date,

    supplierSlaWedEnd?: Date,

    supplierSlaWedStart?: Date,

    /**
     * 
Data Type : supplierStatusEnum
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="supplierStatusEnum" type="supplierStatusEnum"/>
    */

    supplierStatusEnum?: any,

    /**
     * 
Data Type : durationDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="supplierTimeToResolveActual" type="durationDto"/>
    */

    supplierTimeToResolveActual?: any,

    /**
     * 
Data Type : durationDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="supplierTimeToResolveSla" type="durationDto"/>
    */

    supplierTimeToResolveSla?: any,

    /**
     * 
Data Type : durationDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="supplierTimeToRespondActual" type="durationDto"/>
    */

    supplierTimeToRespondActual?: any,

    /**
     * 
Data Type : durationDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="supplierTimeToRespondSla" type="durationDto"/>
    */

    supplierTimeToRespondSla?: any,

    /**
     * 
Data Type : surveyRequestDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/surveyRequests" maxOccurs="unbounded" minOccurs="0" name="surveyRequests" nillable="true" type="surveyRequestDto"/>
    */

    surveyRequests?: any,

    svdResolutionActual?: Date,

    /**
     * Defines the OLA used with this event. This property is only used when events have been assigned to Service Departments that define OLAs and will be null/empty otherwise
Data Type : slaDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="Defines the OLA used with this event. This property is only used when events have been assigned to Service Departments that define OLAs and will be null/empty otherwise" axios:resourcePath="/serviceLevelAgreements" minOccurs="0" name="svdSla" type="slaDto"/>
    */

    svdSla?: any,

    svdSlaId?: number,

    /**
     * 
Data Type : assystUserDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assystUsers" minOccurs="0" name="terminalLockingUser" type="assystUserDto"/>
    */

    terminalLockingUser?: any,

    terminalLockingUserId?: number,

    /**
     * 
Data Type : durationDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="timeToCallbackSla" type="durationDto"/>
    */

    timeToCallbackSla?: any,

    /**
     * 
Data Type : durationDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="timeToResolveActual" type="durationDto"/>
    */

    timeToResolveActual?: any,

    /**
     * 
Data Type : durationDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="timeToResolveSla" type="durationDto"/>
    */

    timeToResolveSla?: any,

    /**
     * 
Data Type : durationDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="timeToRespondSla" type="durationDto"/>
    */

    timeToRespondSla?: any,

    totalAttachmentCount?: number,

    totalBundlePrice?: number,

    totalCost?: number,

    totalPrice?: number,

    totalServiceCost?: number,

    /**
     * 
Data Type : durationDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="totalServiceTime" type="durationDto"/>
    */

    totalServiceTime?: any,

    /**
     * 
Data Type : durationDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="totalTimeClockStopped" type="durationDto"/>
    */

    totalTimeClockStopped?: any,

    /**
     * 
Data Type : durationDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="totalTimeSupplierClockStopped" type="durationDto"/>
    */

    totalTimeSupplierClockStopped?: any,

    uflag1?: boolean,

    uflag2?: boolean,

    uflag3?: string,

    uflag4?: string,

    uflag6?: string,

    uflag7?: string,

    uflag8?: string,

    unitBundlePrice?: number,

    unitCost?: number,

    unitPrice?: number,

    unum6?: number,

    unum7?: number,

    /**
     * 
Data Type : actionTypeDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/actionTypes" minOccurs="0" name="userStatus" type="actionTypeDto"/>
    */

    userStatus?: any,

    userStatusId?: number,

    ustring2?: string,

    verifyAuthoriseAction?: boolean,

    verifyDoNotAuthoriseAction?: boolean,

    webCustomPropertiesDescription?: string,
    acknowledged?: boolean,
    eventAcknowledgedStatus?: IncidentespondedStatus,
}


export function getEventFormattedStatus(event: EventDto): string {
    switch (event.eventStatusEnum) {
        case 'OPEN':
            if (event.lastSlaClockStop === undefined || event.lastSlaClockStop === null) {
                return 'Open'
            }
            return 'Awaiting Customer';
        case 'PENDING':
            return 'Resolved';
        case 'CLOSED':
            return 'Closed'
        default:
            return 'Unknown';
    }
    //{#if event.lastSlaClockStop && event.eventStatusEnum === 'OPEN'}
    // ON HOLD
    // {:else if event.eventStatusEnum === 'PENDING'}
    //     RESOLVED
    // {:else}
    //     {event.eventStatusEnum}
    // {/if}

}