import type { AssystBaseCSGDto } from "./assyst-base";


export interface ServiceOfferingDto extends AssystBaseCSGDto {


    allowAnonymousUser?: boolean,

    allowFeedback?: boolean,

    /**
     * 
Data Type : serviceOfferingBundleComponentDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:allowedGraphOperations="CREATE, SKIP" axios:graphPath="/serviceOfferingBundleComponents/graph" axios:resourcePath="/serviceOfferingBundleComponents" axios:supportsGraphCollectionDeletion="true" maxOccurs="unbounded" minOccurs="0" name="bundleComponents" nillable="true" type="serviceOfferingBundleComponentDto"/>
    */

    bundleComponents?: any,

    businessDescription?: string,

    canOverrideDefaults?: boolean,

    /**
     * 
Data Type : serviceOfferingCostDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:allowedGraphOperations="CREATE, SKIP" axios:resourcePath="/serviceOfferingCosts" axios:supportsGraphCollectionDeletion="true" maxOccurs="unbounded" minOccurs="0" name="costs" nillable="true" type="serviceOfferingCostDto"/>
    */

    costs?: any,
    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="currency"/>
     */

    currencyId?: number,
    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="customEntityDefinition"/>
     */

    customEntityDefinitionId?: number,

    /**
     * 
Data Type : servDeptDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceDepartments" name="defaultAssignedServDept" type="servDeptDto"/>
    */

    defaultAssignedServDept?: any,

    defaultAssignedServDeptId?: number,

    /**
     * 
Data Type : assystUserDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assystUsers" minOccurs="0" name="defaultAssignedUser" type="assystUserDto"/>
    */

    defaultAssignedUser?: any,

    defaultAssignedUserId?: number,

    /**
     * 
Data Type : categoryDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/categories" name="defaultCategory" type="categoryDto"/>
    */

    defaultCategory?: any,

    defaultCategoryId?: number,

    /**
     * 
Data Type : departmentDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/departments" name="defaultDepartment" type="departmentDto"/>
    */

    defaultDepartment?: any,

    defaultDepartmentId?: number,

    /**
     * 
Data Type : seriousnessDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/seriousnesses" name="defaultImpact" type="seriousnessDto"/>
    */

    defaultImpact?: any,

    defaultImpactId?: number,

    /**
     * 
Data Type : itemDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/items" name="defaultItemA" type="itemDto"/>
    */

    defaultItemA?: any,

    defaultItemAId?: number,

    /**
     * 
Data Type : itemDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/items" minOccurs="0" name="defaultItemB" type="itemDto"/>
    */

    defaultItemB?: any,

    defaultItemBId?: number,

    /**
     * 
Data Type : priorityDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/priorities" name="defaultPriority" type="priorityDto"/>
    */

    defaultPriority?: any,

    defaultPriorityId?: number,

    /**
     * 
Data Type : roomDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/rooms" name="defaultRoom" type="roomDto"/>
    */

    defaultRoom?: any,

    defaultRoomId?: number,

    /**
     * 
Data Type : seriousnessDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/seriousnesses" name="defaultSeriousness" type="seriousnessDto"/>
    */

    defaultSeriousness?: any,

    defaultSeriousnessId?: number,

    /**
     * 
Data Type : siteVisitRequiredEnum
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="defaultSiteVisitRequired" type="siteVisitRequiredEnum"/>
    */

    defaultSiteVisitRequired?: any,

    defaultStartProcess?: boolean,

    /**
     * 
Data Type : templateProcessDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:graphPath="/templateProcesses/graph" axios:resourcePath="/templateProcesses" minOccurs="0" name="defaultTemplateProcess" type="templateProcessDto"/>
    */

    defaultTemplateProcess?: any,

    defaultTemplateProcessId?: number,

    /**
     * 
Data Type : priorityDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/priorities" name="defaultUrgency" type="priorityDto"/>
    */

    defaultUrgency?: any,

    defaultUrgencyId?: number,

    /**
     * 
Data Type : serviceOfferingDemandDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:allowedGraphOperations="CREATE, SKIP" axios:resourcePath="/serviceOfferingDemands" axios:supportsGraphCollectionDeletion="true" maxOccurs="unbounded" minOccurs="0" name="demands" nillable="true" type="serviceOfferingDemandDto"/>
    */

    demands?: any,

    detailedDescription?: string,

    displayDefaults?: boolean,

    /**
     * 
Data Type : collaborationDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/collaborations" minOccurs="0" name="feedbackCollaboration" type="collaborationDto"/>
    */

    feedbackCollaboration?: any,

    feedbackCollaborationId?: number,

    followersEnabled?: boolean,

    hiddenInAssystNet?: boolean,

    hiddenInAssystWeb?: boolean,

    iconURL?: string,

    imageURL?: string,

    /**
     * 
Data Type : eventTypesEnum
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="loggedEventType" type="eventTypesEnum"/>
    */

    loggedEventType?: any,

    maximumQuantity?: number,

    metaData?: string,

    mobileUrl?: string,

    /**
     * 
Data Type : serviceDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:graphPath="/serviceCatalog/services/graph" axios:resourcePath="/serviceCatalog/services" minOccurs="0" name="parentService" type="serviceDto"/>
    */

    parentService?: any,

    parentServiceId?: number,

    price?: number,

    priceDescription?: string,

    promotionEndDate?: Date,

    promotionFlag?: boolean,

    promotionStartDate?: Date,

    readOnlyInAssystNet?: boolean,

    readOnlyInAssystWeb?: boolean,

    /**
     * 
Data Type : serviceOfferingContactUserQueryProfileDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:allowedGraphOperations="CREATE, CREATE_OR_UPDATE, CREATE_IF_MISSING, SKIP" axios:graphPath="/serviceOfferingContactUserQueryProfiles/graph" axios:resourcePath="/serviceOfferingContactUserQueryProfiles" axios:supportsGraphCollectionDeletion="true" maxOccurs="unbounded" minOccurs="0" name="serviceOfferingContactUserQueryProfiles" nillable="true" type="serviceOfferingContactUserQueryProfileDto"/>
    */

    serviceOfferingContactUserQueryProfiles?: any,

    /**
     * 
Data Type : serviceOfferingEntityDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceOfferingEntities" maxOccurs="unbounded" minOccurs="0" name="serviceOfferingEntities" nillable="true" type="serviceOfferingEntityDto"/>
    */

    serviceOfferingEntities?: any,

    /**
     * 
Data Type : serviceOfferingLinkDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:graphPath="/serviceOfferingLinks/graph" axios:resourcePath="/serviceOfferingLinks" maxOccurs="unbounded" minOccurs="0" name="serviceOfferingLinks" nillable="true" type="serviceOfferingLinkDto"/>
    */

    serviceOfferingLinks?: any,

    /**
     * 
Data Type : serviceOfferingProductRestrictionDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:graphPath="/serviceOfferingProductRestrictions/graph" axios:resourcePath="/serviceOfferingProductRestrictions" maxOccurs="unbounded" minOccurs="0" name="serviceOfferingProductRestrictions" nillable="true" type="serviceOfferingProductRestrictionDto"/>
    */

    serviceOfferingProductRestrictions?: any,

    /**
     * 
Data Type : serviceOfferingTypesEnum
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="serviceOfferingType" type="serviceOfferingTypesEnum"/>
    */

    serviceOfferingType?: any,

    serviceRequestFlag?: boolean,
    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="sla"/>
     */

    slaBusinessDescription?: string,

    slaDetailedDescription?: string,

    slaId?: number,

    slaSummary?: string,

    sortOrder?: number,

    status?: number,

    suggestedActions?: string,

    summary?: string,

    tileClass?: string,

    /**
     * 
Data Type : assystImageDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/images" minOccurs="0" name="tileImage" type="assystImageDto"/>
    */

    tileImage?: any,

    tileImageId?: number,

    translationModifyDate?: Date,

    /**
     * 
Data Type : serviceOfferingDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:graphPath="/serviceCatalog/serviceOfferings/graph" axios:resourcePath="/serviceCatalog/serviceOfferings" maxOccurs="unbounded" minOccurs="0" name="translations" nillable="true" type="serviceOfferingDto"/>
    */

    translations?: any,

    url?: string,
}
