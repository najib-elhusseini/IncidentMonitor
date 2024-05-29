import type { AssystBaseCSGDto } from "./assyst-base";


export interface ServDeptDto extends AssystBaseCSGDto {


  ableToReceiveAuthorisations?: boolean,

  ableToReceiveEvents?: boolean,

  ackCosting?: boolean,

  ackDetail?: boolean,

  ackReqd?: boolean,

  ackTime?: boolean,

  anonymizedName?: string,

  assIntCosting?: boolean,

  assIntDetail?: boolean,

  assIntTime?: boolean,

  assTriggerLevel?: number,

  /**
   * 
Data Type : contactUserDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/contactUsers" minOccurs="0" name="assTriggerUser" type="contactUserDto"/>
  */

  assTriggerUser?: any,

  assTriggerUserId?: number,

  /**
   * Describes all assyst users who are members of this Service Department (either primary or secondary)
Data Type : assystUserDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="Describes all assyst users who are members of this Service Department (either primary or secondary)" axios:resourcePath="/assystUsers" maxOccurs="unbounded" minOccurs="0" name="assystUsers" nillable="true" type="assystUserDto"/>
  */

  assystUsers?: any,

  auditLaneChanges?: boolean,

  autoAssPend?: boolean,

  autoAssign?: boolean,

  autoPopulateItemB?: boolean,

  /**
   * 
Data Type : availabilityDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" maxOccurs="unbounded" minOccurs="0" name="availability" nillable="true" type="availabilityDto"/>
  */

  availability?: any,

  /**
   * 
Data Type : servDeptActionDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceDepartmentActionTypes" maxOccurs="unbounded" minOccurs="0" name="availableActions" nillable="true" type="servDeptActionDto"/>
  */

  availableActions?: any,

  /**
   * 
Data Type : servDeptModelEventDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" maxOccurs="unbounded" minOccurs="0" name="availableModelEvents" nillable="true" type="servDeptModelEventDto"/>
  */

  availableModelEvents?: any,

  changeActions?: boolean,

  clearForm?: boolean,

  closeCosting?: boolean,

  closeDetail?: boolean,

  closeTime?: boolean,

  defLogItem?: boolean,

  /**
   * 
Data Type : slaDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceLevelAgreements" minOccurs="0" name="defaultOla" type="slaDto"/>
  */

  defaultOla?: any,

  defaultOlaId?: number,

  displayAlertsAtEventSave?: boolean,

  displayAlertsDuringLogging?: boolean,

  displayEventNo?: boolean,

  /**
   * 
Data Type : docketDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="docket" type="docketDto"/>
  */

  docket?: any,

  docketDestinationAddress?: string,

  docketId?: number,

  docketType?: number,

  /**
   * 
Data Type : servDeptEmailTemplateDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/servDeptEmailTemplates" maxOccurs="unbounded" minOccurs="0" name="emailTemplates" nillable="true" type="servDeptEmailTemplateDto"/>
  */

  emailTemplates?: any,

  /**
   * 
Data Type : supplierDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/suppliers" minOccurs="0" name="equivSupplier" type="supplierDto"/>
  */

  equivSupplier?: any,

  equivSupplierId?: number,

  /**
   * 
Data Type : durationDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="estimate" type="durationDto"/>
  */

  estimate?: any,

  eventBuilderForCause?: boolean,

  /**
   * 
Data Type : assystUserDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assystUsers" maxOccurs="unbounded" minOccurs="0" name="feedbackManagers" nillable="true" type="assystUserDto"/>
  */

  feedbackManagers?: any,

  groupLicencesInUse?: number,

  incLocation?: number,

  inclAssignmentCount?: boolean,

  mailAffUsrClosing?: boolean,

  mailAffUsrLogging?: boolean,

  mailRepUsrClosing?: boolean,

  mailRepUsrLogging?: boolean,

  majorIncCosting?: boolean,

  majorIncDetail?: boolean,

  majorIncTime?: boolean,

  /**
   * 
Data Type : assystUserDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assystUsers" maxOccurs="unbounded" minOccurs="0" name="managers" nillable="true" type="assystUserDto"/>
  */

  managers?: any,

  mandCauseCat?: boolean,

  mandCauseItem?: boolean,

  mandChangeCallBackRemark?: boolean,

  mandChangeShortDesc?: boolean,

  mandCharge?: boolean,

  mandDept?: boolean,

  mandExt?: boolean,

  mandIncidentCallBackRemark?: boolean,

  mandIncidentShortDesc?: boolean,

  mandProblemCallBackRemark?: boolean,

  mandProblemShortDesc?: boolean,

  mandReportingUser?: boolean,

  mandRequiredBy?: boolean,

  mandRoom?: boolean,

  mandScheduledEndDate?: boolean,

  mandScheduledStartDate?: boolean,

  mandTele?: boolean,

  /**
   * Describes the assyst users who are members of this Service Department through their secondary Service Department
Data Type : secondaryServDeptDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="Describes the assyst users who are members of this Service Department through their secondary Service Department" axios:resourcePath="/secondaryServiceDepartments" maxOccurs="unbounded" minOccurs="0" name="members" nillable="true" type="secondaryServDeptDto"/>
  */

  members?: any,

  /**
   * 
Data Type : modelEventDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/modelEvents" maxOccurs="unbounded" minOccurs="0" name="modelEvents" nillable="true" type="modelEventDto"/>
  */

  modelEvents?: any,

  /**
   * 
Data Type : servDeptDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceDepartments" minOccurs="0" name="nextSvd" type="servDeptDto"/>
  */

  nextSvd?: any,

  nextSvdId?: number,

  normalActCosting?: boolean,

  normalActDetail?: boolean,

  normalActTime?: boolean,

  pendingCosting?: boolean,

  pendingDetail?: boolean,

  pendingDock?: boolean,

  pendingTime?: boolean,

  prePopulateLoggingDate?: boolean,

  remoteDesktop?: boolean,

  reopenCosting?: boolean,

  reopenDetail?: boolean,

  reopenTime?: boolean,

  resolutionActionForAuthorisationTask?: number,

  resolutionActionForKnowledgeSolve?: number,

  restrictLogging?: boolean,

  /**
   * 
Data Type : servDeptGroupDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="servDeptGroup" type="servDeptGroupDto"/>
  */

  servDeptGroup?: any,

  servDeptGroupId?: number,

  setState?: boolean,
  /**
   * Ref object discarded 
   * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="shiftDetails"/>
   */

  shiftDetailsId?: number,

  specSla?: boolean,

  statusCosting?: boolean,

  statusDetail?: boolean,

  statusTime?: boolean,

  suggestSla?: boolean,

  suppActCosting?: boolean,

  suppActDetail?: boolean,

  suppActTime?: boolean,

  suppAssCosting?: boolean,

  suppAssDetail?: boolean,

  suppAssTime?: boolean,

  suppReopenCosting?: boolean,

  suppReopenDetail?: boolean,

  suppReopenTime?: boolean,

  suppRespCosting?: boolean,

  suppRespDetail?: boolean,

  suppRespTime?: boolean,

  suppRslveCosting?: boolean,

  suppRslveDetail?: boolean,

  suppRslveTime?: boolean,
  /**
   * Ref object discarded 
   * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="taskboard"/>
   */

  taskboardId?: number,

  timeZoneEnabled?: boolean,

  timeZoneOffset?: number,

  translationModifyDate?: Date,

  /**
   * 
Data Type : servDeptDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceDepartments" maxOccurs="unbounded" minOccurs="0" name="translations" nillable="true" type="servDeptDto"/>
  */

  translations?: any,

  uFlag2?: boolean,

  uFlag3?: boolean,

  uFlag4?: boolean,

  useUsrItem?: boolean,

  /**
   * 
Data Type : durationDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="userCapacity" type="durationDto"/>
  */

  userCapacity?: any,

  usrSc?: boolean,
}



export interface DepartmentDto extends AssystBaseCSGDto {


  address1?: string,

  address2?: string,

  address3?: string,

  /**
   * 
 Data Type : departmentContactDto
 Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/departmentContacts" maxOccurs="unbounded" minOccurs="0" name="contacts" nillable="true" type="departmentContactDto"/>
  */

  contacts?: any,

  country?: string,

  defaultDepartment?: boolean,

  /**
   * 
 Data Type : departmentNameDto
 Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/departmentNames" minOccurs="0" name="departmentDepartmentName" type="departmentNameDto"/>
  */

  departmentDepartmentName?: any,

  departmentDepartmentNameId?: number,

  departmentDepartmentShortCode?: string,

  departmentName?: string,

  departmentNameName?: string,

  departmentShortCode?: string,

  fax?: string,

  incClearanceDays?: number,

  licenceCount?: number,

  /**
   * 
 Data Type : contactUserDto
 Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/contactUsers" minOccurs="0" name="manager" type="contactUserDto"/>
  */

  manager?: any,

  managerId?: number,

  postCode?: string,

  postTown?: string,
  sectionDepartmentName?: string,
  sectionDepartmentShortCode?: string,
  section?: SectionDto,
  sectionId?: number,

  /**
   * 
 Data Type : departmentSlaDto
 Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/departmentSlas" maxOccurs="unbounded" minOccurs="0" name="slas" nillable="true" type="departmentSlaDto"/>
  */

  slas?: any,

  telephone?: string,

  telex?: string,
  sectionName?: string
}




export interface SectionDto extends AssystBaseCSGDto {


  address1?: string,

  address2?: string,

  address3?: string,
  /**
   * Ref object discarded 
   * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="branch"/>
   */

  branchId?: number,

  /**
   * 
 Data Type : contactUserDto
 Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/contactUsers" maxOccurs="unbounded" minOccurs="0" name="contacts" nillable="true" type="contactUserDto"/>
  */

  contacts?: any,

  country?: string,

  /**
   * 
 Data Type : sectionRelationshipDto
 Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" maxOccurs="unbounded" minOccurs="0" name="customers" nillable="true" type="sectionRelationshipDto"/>
  */

  customers?: any,

  /**
   * 
 Data Type : departmentDto
 Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/departments" minOccurs="0" name="defaultDepartment" type="departmentDto"/>
  */

  defaultDepartment?: any,

  /**
   * 
 Data Type : slaDto
 Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceLevelAgreements" minOccurs="0" name="defaultSla" type="slaDto"/>
  */

  defaultSla?: any,

  defaultSlaId?: number,

  /**
   * 
 Data Type : supplierDto
 Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/suppliers" minOccurs="0" name="dfltInsurer" type="supplierDto"/>
  */

  dfltInsurer?: any,

  dfltInsurerId?: number,

  fax?: string,
  /**
   * Ref object discarded 
   * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="holidayPlan"/>
   */

  holidayPlanId?: number,

  licenceCount?: number,

  /**
   * 
 Data Type : contactUserDto
 Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/contactUsers" minOccurs="0" name="manager" type="contactUserDto"/>
  */

  manager?: any,

  managerId?: number,

  /**
   * 
 Data Type : sectionRelationshipDto
 Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" maxOccurs="unbounded" minOccurs="0" name="partners" nillable="true" type="sectionRelationshipDto"/>
  */

  partners?: any,

  postCode?: string,

  postTown?: string,
  /**
   * Ref object discarded 
   * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="sectionClass"/>
   */

  sectionClassId?: number,

  /**
   * 
 Data Type : sectionContactDto
 Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/sectionContacts" maxOccurs="unbounded" minOccurs="0" name="sectionContacts" nillable="true" type="sectionContactDto"/>
  */

  sectionContacts?: any,

  telephone?: string,

  telex?: string,

  translationModifyDate?: Date,

  /**
   * 
 Data Type : sectionDto
 Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/sections" maxOccurs="unbounded" minOccurs="0" name="translations" nillable="true" type="sectionDto"/>
  */

  translations?: any,
}
