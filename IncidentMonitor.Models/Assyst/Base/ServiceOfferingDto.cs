using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IncidentMonitor.Models.Assyst
{


    public class ServiceOfferingDto : AssystBaseCSGDto
    {


        [JsonPropertyName("allowAnonymousUser")]
        public bool? AllowAnonymousUser { get; set; }


        [JsonPropertyName("allowFeedback")]
        public bool? AllowFeedback { get; set; }


        /// <summary>
        /// 
        /// Data Type : serviceOfferingBundleComponentDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:allowedGraphOperations="CREATE, SKIP" axios:graphPath="/serviceOfferingBundleComponents/graph" axios:resourcePath="/serviceOfferingBundleComponents" axios:supportsGraphCollectionDeletion="true" maxOccurs="unbounded" minOccurs="0" name="bundleComponents" nillable="true" type="serviceOfferingBundleComponentDto"/>
        /// </summary>

        [JsonPropertyName("bundleComponents")]
        public object? BundleComponents { get; set; }


        [JsonPropertyName("businessDescription")]
        public string? BusinessDescription { get; set; }


        [JsonPropertyName("canOverrideDefaults")]
        public bool? CanOverrideDefaults { get; set; }


        /// <summary>
        /// 
        /// Data Type : serviceOfferingCostDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:allowedGraphOperations="CREATE, SKIP" axios:resourcePath="/serviceOfferingCosts" axios:supportsGraphCollectionDeletion="true" maxOccurs="unbounded" minOccurs="0" name="costs" nillable="true" type="serviceOfferingCostDto"/>
        /// </summary>

        [JsonPropertyName("costs")]
        public object? Costs { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="currency"/>
         */


        [JsonPropertyName("currencyId")]
        public int? CurrencyId { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="customEntityDefinition"/>
         */


        [JsonPropertyName("customEntityDefinitionId")]
        public int? CustomEntityDefinitionId { get; set; }


        /// <summary>
        /// 
        /// Data Type : servDeptDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceDepartments" name="defaultAssignedServDept" type="servDeptDto"/>
        /// </summary>

        [JsonPropertyName("defaultAssignedServDept")]
        public object? DefaultAssignedServDept { get; set; }


        [JsonPropertyName("defaultAssignedServDeptId")]
        public int? DefaultAssignedServDeptId { get; set; }


        /// <summary>
        /// 
        /// Data Type : assystUserDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/assystUsers" minOccurs="0" name="defaultAssignedUser" type="assystUserDto"/>
        /// </summary>

        [JsonPropertyName("defaultAssignedUser")]
        public object? DefaultAssignedUser { get; set; }


        [JsonPropertyName("defaultAssignedUserId")]
        public int? DefaultAssignedUserId { get; set; }


        /// <summary>
        /// 
        /// Data Type : categoryDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/categories" name="defaultCategory" type="categoryDto"/>
        /// </summary>

        [JsonPropertyName("defaultCategory")]
        public object? DefaultCategory { get; set; }


        [JsonPropertyName("defaultCategoryId")]
        public int? DefaultCategoryId { get; set; }


        /// <summary>
        /// 
        /// Data Type : departmentDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/departments" name="defaultDepartment" type="departmentDto"/>
        /// </summary>

        [JsonPropertyName("defaultDepartment")]
        public object? DefaultDepartment { get; set; }


        [JsonPropertyName("defaultDepartmentId")]
        public int? DefaultDepartmentId { get; set; }


        /// <summary>
        /// 
        /// Data Type : seriousnessDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/seriousnesses" name="defaultImpact" type="seriousnessDto"/>
        /// </summary>

        [JsonPropertyName("defaultImpact")]
        public object? DefaultImpact { get; set; }


        [JsonPropertyName("defaultImpactId")]
        public int? DefaultImpactId { get; set; }


        /// <summary>
        /// 
        /// Data Type : itemDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/items" name="defaultItemA" type="itemDto"/>
        /// </summary>

        [JsonPropertyName("defaultItemA")]
        public object? DefaultItemA { get; set; }


        [JsonPropertyName("defaultItemAId")]
        public int? DefaultItemAId { get; set; }


        /// <summary>
        /// 
        /// Data Type : itemDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/items" minOccurs="0" name="defaultItemB" type="itemDto"/>
        /// </summary>

        [JsonPropertyName("defaultItemB")]
        public object? DefaultItemB { get; set; }


        [JsonPropertyName("defaultItemBId")]
        public int? DefaultItemBId { get; set; }


        /// <summary>
        /// 
        /// Data Type : priorityDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/priorities" name="defaultPriority" type="priorityDto"/>
        /// </summary>

        [JsonPropertyName("defaultPriority")]
        public object? DefaultPriority { get; set; }


        [JsonPropertyName("defaultPriorityId")]
        public int? DefaultPriorityId { get; set; }


        /// <summary>
        /// 
        /// Data Type : roomDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/rooms" name="defaultRoom" type="roomDto"/>
        /// </summary>

        [JsonPropertyName("defaultRoom")]
        public object? DefaultRoom { get; set; }


        [JsonPropertyName("defaultRoomId")]
        public int? DefaultRoomId { get; set; }


        /// <summary>
        /// 
        /// Data Type : seriousnessDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/seriousnesses" name="defaultSeriousness" type="seriousnessDto"/>
        /// </summary>

        [JsonPropertyName("defaultSeriousness")]
        public object? DefaultSeriousness { get; set; }


        [JsonPropertyName("defaultSeriousnessId")]
        public int? DefaultSeriousnessId { get; set; }


        /// <summary>
        /// 
        /// Data Type : siteVisitRequiredEnum
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="defaultSiteVisitRequired" type="siteVisitRequiredEnum"/>
        /// </summary>

        [JsonPropertyName("defaultSiteVisitRequired")]
        public object? DefaultSiteVisitRequired { get; set; }


        [JsonPropertyName("defaultStartProcess")]
        public bool? DefaultStartProcess { get; set; }


        /// <summary>
        /// 
        /// Data Type : templateProcessDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:graphPath="/templateProcesses/graph" axios:resourcePath="/templateProcesses" minOccurs="0" name="defaultTemplateProcess" type="templateProcessDto"/>
        /// </summary>

        [JsonPropertyName("defaultTemplateProcess")]
        public object? DefaultTemplateProcess { get; set; }


        [JsonPropertyName("defaultTemplateProcessId")]
        public int? DefaultTemplateProcessId { get; set; }


        /// <summary>
        /// 
        /// Data Type : priorityDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/priorities" name="defaultUrgency" type="priorityDto"/>
        /// </summary>

        [JsonPropertyName("defaultUrgency")]
        public object? DefaultUrgency { get; set; }


        [JsonPropertyName("defaultUrgencyId")]
        public int? DefaultUrgencyId { get; set; }


        /// <summary>
        /// 
        /// Data Type : serviceOfferingDemandDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:allowedGraphOperations="CREATE, SKIP" axios:resourcePath="/serviceOfferingDemands" axios:supportsGraphCollectionDeletion="true" maxOccurs="unbounded" minOccurs="0" name="demands" nillable="true" type="serviceOfferingDemandDto"/>
        /// </summary>

        [JsonPropertyName("demands")]
        public object? Demands { get; set; }


        [JsonPropertyName("detailedDescription")]
        public string? DetailedDescription { get; set; }


        [JsonPropertyName("displayDefaults")]
        public bool? DisplayDefaults { get; set; }


        /// <summary>
        /// 
        /// Data Type : collaborationDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/collaborations" minOccurs="0" name="feedbackCollaboration" type="collaborationDto"/>
        /// </summary>

        [JsonPropertyName("feedbackCollaboration")]
        public object? FeedbackCollaboration { get; set; }


        [JsonPropertyName("feedbackCollaborationId")]
        public int? FeedbackCollaborationId { get; set; }


        [JsonPropertyName("followersEnabled")]
        public bool? FollowersEnabled { get; set; }


        [JsonPropertyName("hiddenInAssystNet")]
        public bool? HiddenInAssystNet { get; set; }


        [JsonPropertyName("hiddenInAssystWeb")]
        public bool? HiddenInAssystWeb { get; set; }


        [JsonPropertyName("iconURL")]
        public string? IconURL { get; set; }


        [JsonPropertyName("imageURL")]
        public string? ImageURL { get; set; }


        /// <summary>
        /// 
        /// Data Type : eventTypesEnum
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="loggedEventType" type="eventTypesEnum"/>
        /// </summary>

        [JsonPropertyName("loggedEventType")]
        public object? LoggedEventType { get; set; }


        [JsonPropertyName("maximumQuantity")]
        public int? MaximumQuantity { get; set; }


        [JsonPropertyName("metaData")]
        public string? MetaData { get; set; }


        [JsonPropertyName("mobileUrl")]
        public string? MobileUrl { get; set; }


        /// <summary>
        /// 
        /// Data Type : serviceDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:graphPath="/serviceCatalog/services/graph" axios:resourcePath="/serviceCatalog/services" minOccurs="0" name="parentService" type="serviceDto"/>
        /// </summary>

        [JsonPropertyName("parentService")]
        public object? ParentService { get; set; }


        [JsonPropertyName("parentServiceId")]
        public int? ParentServiceId { get; set; }


        [JsonPropertyName("price")]
        public double? Price { get; set; }


        [JsonPropertyName("priceDescription")]
        public string? PriceDescription { get; set; }


        [JsonPropertyName("promotionEndDate")]
        public DateTime? PromotionEndDate { get; set; }


        [JsonPropertyName("promotionFlag")]
        public bool? PromotionFlag { get; set; }


        [JsonPropertyName("promotionStartDate")]
        public DateTime? PromotionStartDate { get; set; }


        [JsonPropertyName("readOnlyInAssystNet")]
        public bool? ReadOnlyInAssystNet { get; set; }


        [JsonPropertyName("readOnlyInAssystWeb")]
        public bool? ReadOnlyInAssystWeb { get; set; }


        /// <summary>
        /// 
        /// Data Type : serviceOfferingContactUserQueryProfileDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:allowedGraphOperations="CREATE, CREATE_OR_UPDATE, CREATE_IF_MISSING, SKIP" axios:graphPath="/serviceOfferingContactUserQueryProfiles/graph" axios:resourcePath="/serviceOfferingContactUserQueryProfiles" axios:supportsGraphCollectionDeletion="true" maxOccurs="unbounded" minOccurs="0" name="serviceOfferingContactUserQueryProfiles" nillable="true" type="serviceOfferingContactUserQueryProfileDto"/>
        /// </summary>

        [JsonPropertyName("serviceOfferingContactUserQueryProfiles")]
        public object? ServiceOfferingContactUserQueryProfiles { get; set; }


        /// <summary>
        /// 
        /// Data Type : serviceOfferingEntityDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/serviceOfferingEntities" maxOccurs="unbounded" minOccurs="0" name="serviceOfferingEntities" nillable="true" type="serviceOfferingEntityDto"/>
        /// </summary>

        [JsonPropertyName("serviceOfferingEntities")]
        public object? ServiceOfferingEntities { get; set; }


        /// <summary>
        /// 
        /// Data Type : serviceOfferingLinkDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:graphPath="/serviceOfferingLinks/graph" axios:resourcePath="/serviceOfferingLinks" maxOccurs="unbounded" minOccurs="0" name="serviceOfferingLinks" nillable="true" type="serviceOfferingLinkDto"/>
        /// </summary>

        [JsonPropertyName("serviceOfferingLinks")]
        public object? ServiceOfferingLinks { get; set; }


        /// <summary>
        /// 
        /// Data Type : serviceOfferingProductRestrictionDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:graphPath="/serviceOfferingProductRestrictions/graph" axios:resourcePath="/serviceOfferingProductRestrictions" maxOccurs="unbounded" minOccurs="0" name="serviceOfferingProductRestrictions" nillable="true" type="serviceOfferingProductRestrictionDto"/>
        /// </summary>

        [JsonPropertyName("serviceOfferingProductRestrictions")]
        public object? ServiceOfferingProductRestrictions { get; set; }


        /// <summary>
        /// 
        /// Data Type : serviceOfferingTypesEnum
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="serviceOfferingType" type="serviceOfferingTypesEnum"/>
        /// </summary>

        [JsonPropertyName("serviceOfferingType")]
        public object? ServiceOfferingType { get; set; }


        [JsonPropertyName("serviceRequestFlag")]
        public bool? ServiceRequestFlag { get; set; }

        /**
         * Ref object discarded 
         * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="sla"/>
         */


        [JsonPropertyName("slaBusinessDescription")]
        public string? SlaBusinessDescription { get; set; }


        [JsonPropertyName("slaDetailedDescription")]
        public string? SlaDetailedDescription { get; set; }


        [JsonPropertyName("slaId")]
        public int? SlaId { get; set; }


        [JsonPropertyName("slaSummary")]
        public string? SlaSummary { get; set; }


        [JsonPropertyName("sortOrder")]
        public int? SortOrder { get; set; }


        [JsonPropertyName("status")]
        public int? Status { get; set; }


        [JsonPropertyName("suggestedActions")]
        public string? SuggestedActions { get; set; }


        [JsonPropertyName("summary")]
        public string? Summary { get; set; }


        [JsonPropertyName("tileClass")]
        public string? TileClass { get; set; }


        /// <summary>
        /// 
        /// Data Type : assystImageDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/images" minOccurs="0" name="tileImage" type="assystImageDto"/>
        /// </summary>

        [JsonPropertyName("tileImage")]
        public object? TileImage { get; set; }


        [JsonPropertyName("tileImageId")]
        public int? TileImageId { get; set; }


        [JsonPropertyName("translationModifyDate")]
        public DateTime? TranslationModifyDate { get; set; }


        /// <summary>
        /// 
        /// Data Type : serviceOfferingDto
        /// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:graphPath="/serviceCatalog/serviceOfferings/graph" axios:resourcePath="/serviceCatalog/serviceOfferings" maxOccurs="unbounded" minOccurs="0" name="translations" nillable="true" type="serviceOfferingDto"/>
        /// </summary>

        [JsonPropertyName("translations")]
        public object? Translations { get; set; }


        [JsonPropertyName("url")]
        public string? Url { get; set; }

    }

}
