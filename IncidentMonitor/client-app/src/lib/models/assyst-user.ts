import type { AssystBaseCSGDto, AssystBaseDto } from "./assyst-base";
import type { DepartmentDto } from "./assyst-department";


export interface UserDto extends AssystBaseCSGDto {


    /**
     * 
Data Type : docketDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="docket" type="docketDto"/>
    */

    docket?: any,

    docketId?: number,

    email?: string,

    emailAddress?: string,

    homeTele?: string,

    homeTelephone?: string,

    lastLocationDate?: Date,

    latitude?: number,

    loginName?: string,

    longitude?: number,

    officeExtension?: string,

    officeTelephone?: string,

    officeTelephoneExtension?: string,

    password?: string,
    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="person"/>
     */

    /**
     * 
Data Type : userRoleDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/userRoles" minOccurs="0" name="role" type="userRoleDto"/>
    */

    role?: any,

    roleId?: number,

    staffNumber?: string,

    typeOfUser?: number,
    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="userGroup"/>
     */

    userGroupId?: number,
    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="userImage"/>
     */

    userImageId?: number,
    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="userRole"/>
     */

    userRoleId?: number,
}


export interface AssystUserDto extends UserDto {


    /**
     * 
Data Type : assignableServDeptDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assignableServiceDepartments" maxOccurs="unbounded" minOccurs="0" name="assignableServDeptAssociations" nillable="true" type="assignableServDeptDto"/>
    */

    assignableServDeptAssociations?: any,

    /**
     * 
Data Type : servDeptDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceDepartments" maxOccurs="unbounded" minOccurs="0" name="assignableServDepts" nillable="true" type="servDeptDto"/>
    */

    assignableServDepts?: any,

    /**
     * 
Data Type : availabilityDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" maxOccurs="unbounded" minOccurs="0" name="availability" nillable="true" type="availabilityDto"/>
    */

    availability?: any,

    /**
     * 
Data Type : contactUserDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/contactUsers" maxOccurs="unbounded" minOccurs="0" name="contactUsers" nillable="true" type="contactUserDto"/>
    */

    contactUsers?: any,

    csgsNotVisibleToPrincipal?: boolean,

    /**
     * 
Data Type : assystUserDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assystUsers" minOccurs="0" name="customAlias" type="assystUserDto"/>
    */

    customAlias?: any,

    customAliasId?: number,

    /**
     * 
Data Type : csgMembershipDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/csgMemberships" maxOccurs="unbounded" minOccurs="0" name="customerServiceGroupMemberships" nillable="true" type="csgMembershipDto"/>
    */

    customerServiceGroupMemberships?: any,

    docketBox?: number,
    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="homepage"/>
     */

    homepageId?: number,

    isReportWriter?: boolean,

    mailSystem?: number,

    /**
     * 
Data Type : mailSystemTypesEnum
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="mailSystemEnum" type="mailSystemTypesEnum"/>
    */

    mailSystemEnum?: any,

    manageOwnSVD?: boolean,

    /**
     * 
Data Type : servDeptDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceDepartments" maxOccurs="unbounded" minOccurs="0" name="managedServiceDepartments" nillable="true" type="servDeptDto"/>
    */

    managedServiceDepartments?: any,

    /**
     * 
Data Type : assystUserDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assystUsers" minOccurs="0" name="manager" type="assystUserDto"/>
    */

    manager?: any,

    managerId?: number,

    orderApprovalThreshold?: number,

    /**
     * 
Data Type : assystUserDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assystUsers" minOccurs="0" name="organisationalManager" type="assystUserDto"/>
    */

    organisationalManager?: any,

    organisationalManagerId?: number,

    pagerCode?: string,

    pagerNumber?: string,

    /**
     * 
Data Type : assystUserPermissionsDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="permissions" type="assystUserPermissionsDto"/>
    */

    permissions?: any,

    printAddress?: string,

    /**
     * 
Data Type : privilegeUserDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/privilegeUsers" maxOccurs="unbounded" minOccurs="0" name="privilegeGroupMemberships" nillable="true" type="privilegeUserDto"/>
    */

    privilegeGroupMemberships?: PrivilegeUserDto[],

    /**
     * 
Data Type : secondaryServDeptDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/secondaryServiceDepartments" maxOccurs="unbounded" minOccurs="0" name="secondaryServDeptAssociations" nillable="true" type="secondaryServDeptDto"/>
    */

    secondaryServDeptAssociations?: any,

    /**
     * 
Data Type : servDeptDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceDepartments" maxOccurs="unbounded" minOccurs="0" name="secondaryServDepts" nillable="true" type="servDeptDto"/>
    */

    secondaryServDepts?: any,

    /**
     * 
Data Type : servDeptDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceDepartments" minOccurs="0" name="servDept" type="servDeptDto"/>
    */

    servDept?: any,

    servDeptId?: number,
    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="shiftDetails"/>
     */

    shiftDetailsId?: number,

    timeZone?: number,

    timeZoneEnabled?: boolean,

    userAliasOnly?: boolean,

    userContact?: string,

    /**
     * Convenience property for setting the User Image. This is the same as setting userImage.imgBlob. Both should not be set together, but userImage.imgBlob will take precedence if this is done. Takes a base64 encoded image.
Data Type : base64Binary
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="Convenience property for setting the User Image. This is the same as setting userImage.imgBlob. Both should not be set together, but userImage.imgBlob will take precedence if this is done. Takes a base64 encoded image." minOccurs="0" name="userImageData" type="xs:base64Binary"/>
    */

    userImageData?: string,
}




export interface PrivilegeUserDto extends AssystBaseDto {

    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="assystUser"/>
     */

    assystUserId?: number,
    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="contactUser"/>
     */
    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="privilegeGroup"/>
     */

    privilegeGroup?: PrivilegeGroupDto,
    privilegeGroupId?: number,
}




export interface PrivilegeGroupDto extends AssystBaseCSGDto {


    /**
     * 
Data Type : activityCategoryPrivDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/privilegeGroupActivityCategories" maxOccurs="unbounded" minOccurs="0" name="activityCategoryPrivileges" nillable="true" type="activityCategoryPrivDto"/>
    */

    activityCategoryPrivileges?: any,

    allActivityCategoryPrivs?: boolean,

    allItemPrivs?: boolean,

    /**
     * 
Data Type : itemPrivDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/privilegeGroupItems" maxOccurs="unbounded" minOccurs="0" name="itemPrivileges" nillable="true" type="itemPrivDto"/>
    */

    itemPrivileges?: any,

    /**
     * 
Data Type : knowledgePrivDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/knowledgePrivileges" maxOccurs="unbounded" minOccurs="0" name="knowledgePrivileges" nillable="true" type="knowledgePrivDto"/>
    */

    knowledgePrivileges?: any,

    /**
     * 
Data Type : privilegeGroupPermissionDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/privilegeGroupPermissions" maxOccurs="unbounded" minOccurs="0" name="permissions" nillable="true" type="privilegeGroupPermissionDto"/>
    */

    permissions?: any,

    /**
     * 
Data Type : privilegeUserDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/privilegeUsers" maxOccurs="unbounded" minOccurs="0" name="privilegeUsers" nillable="true" type="privilegeUserDto"/>
    */

    privilegeUsers?: any,

    /**
     * Property used to determine how many users are associated with a particular privilege group. This property is populated using field prepopulation value 'assystUsersCount'
    */

    privilegeUsersCount?: number,

    /**
     * 
Data Type : privilegeDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/privilegeGroupEntities" maxOccurs="unbounded" minOccurs="0" name="privileges" nillable="true" type="privilegeDto"/>
    */

    privileges?: any,
}



export interface ContactUserDto extends UserDto {


    address1?: string,

    address2?: string,

    address3?: string,

    anetLicence?: boolean,

    anetLicense?: boolean,

    /**
     * 
   Data Type : assystUserDto
   Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:deprecated="true" axios:replacementField="userAlias" axios:resourcePath="/assystUsers" minOccurs="0" name="assystUserAlias" type="assystUserDto"/>
    */

    assystUserAlias?: any,

    assystUserAliasId?: number,

    assystUserAliasShortCode?: string,

    contactBleep?: boolean,

    contactFax?: boolean,

    contactMail?: boolean,

    contactPageNo?: string,

    contactPrint?: boolean,

    contactTele?: boolean,
    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="costCentre"/>
     */

    costCentreId?: number,

    country?: string,

    /**
     * 
   Data Type : slaDto
   Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:deprecated="true" axios:replacementField="sla" axios:resourcePath="/serviceLevelAgreements" minOccurs="0" name="defaultSla" type="slaDto"/>
    */

    defaultSla?: any,

    defaultSlaId?: number,

    /**
     * 
   Data Type : delegationLinkDto
   Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/delegationLinks" maxOccurs="unbounded" minOccurs="0" name="delegateUsers" nillable="true" type="delegationLinkDto"/>
    */

    delegateUsers?: any,
    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="department"/>
     */

    department?: DepartmentDto,

    departmentId?: number,

    /**
     * 
   Data Type : assystUserDto
   Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assystUsers" minOccurs="0" name="equivalentUser" type="assystUserDto"/>
    */

    equivalentUser?: any,

    equivalentUserId?: number,

    firstName?: string,

    homeEmailAddress?: string,

    internalId?: string,
    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="licenceRole"/>
     */

    licenceRoleId?: number,

    /**
     * 
   Data Type : contactUserDto
   Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/contactUsers" minOccurs="0" name="manager" type="contactUserDto"/>
    */

    manager?: any,

    managerId?: number,

    /**
     * 
   Data Type : messageReadDto
   Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/messageReads" maxOccurs="unbounded" minOccurs="0" name="messages" nillable="true" type="messageReadDto"/>
    */

    messages?: any,

    middleName?: string,

    orderApprovalThreshold?: number,

    /**
     * 
   Data Type : contactUserDto
   Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/contactUsers" minOccurs="0" name="organisationalManager" type="contactUserDto"/>
    */

    organisationalManager?: any,

    organisationalManagerId?: number,

    personalMobile?: string,

    postCode?: string,

    postTown?: string,
    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="room"/>
     */

    roomId?: number,

    salutation?: string,
    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="sla"/>
     */

    slaId?: number,

    surname?: string,

    title?: string,

    uniqueReference?: string,

    /**
     * 
   Data Type : assystUserDto
   Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assystUsers" minOccurs="0" name="userAlias" type="assystUserDto"/>
    */

    userAlias?: any,

    userAliasId?: number,

    /**
     * Convenience property for setting the User Image. This is the same as setting userImage.imgBlob. Both should not be set together, but userImage.imgBlob will take precedence if this is done. Takes a base64 encoded image.
   Data Type : base64Binary
   Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:description="Convenience property for setting the User Image. This is the same as setting userImage.imgBlob. Both should not be set together, but userImage.imgBlob will take precedence if this is done. Takes a base64 encoded image." minOccurs="0" name="userImageData" type="xs:base64Binary"/>
    */

    userImageData?: string,

    /**
     * 
   Data Type : userItemDto
   Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/userItems" maxOccurs="unbounded" minOccurs="0" name="userItems" nillable="true" type="userItemDto"/>
    */

    userItems?: any,

    /**
     * 
   Data Type : contactUserQueryProfileDto
   Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/contactUserQueryProfiles" maxOccurs="unbounded" minOccurs="0" name="userProfileGroups" nillable="true" type="contactUserQueryProfileDto"/>
    */

    userProfileGroups?: any,

    /**
     * 
   Data Type : userSkillDto
   Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/userSkills" maxOccurs="unbounded" minOccurs="0" name="userSkills" nillable="true" type="userSkillDto"/>
    */

    userSkills?: any,

    usrFlag1?: string,

    usrFlag2?: string,

    workMobile?: string,
}
