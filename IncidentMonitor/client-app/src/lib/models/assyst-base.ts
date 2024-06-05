import type { RichTextFieldDto } from "./assyst";

export interface DurationDto {
    value?: number | undefined,
    isSetToNull?: boolean | undefined
}


export interface GraphObjectBase {
    pseudoId?: number,
    /**
     * 
Data Type : resolvingParameterDto
/// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" maxOccurs="unbounded" minOccurs="0" name="resolvingParameters" nillable="true" type="resolvingParameterDto"/>
    */

    resolvingParameters?: any,

}

export interface AssystDto extends GraphObjectBase {


    /**
     * 
Data Type : attachmentDto
/// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" maxOccurs="unbounded" minOccurs="0" name="attachmentsForLinking" nillable="true" type="attachmentDto"/>
    */

    attachmentsForLinking?: any,


    bulkOperation?: boolean,


    cacheable?: boolean,


    dataLocale?: string,


    /**
     * 
Data Type : entityDefinitionDto
/// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="entityDefinition" type="entityDefinitionDto"/>
    */

    entityDefinition?: any,


    entityDefinitionId?: number,


    entityDefinitionType?: number,


    id?: number,


    /**
     * 
Data Type : jobDto
/// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="jobCommandForCreate" type="jobDto"/>
    */

    jobCommandForCreate?: any,


    /**
     * 
Data Type : jobDto
/// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="jobCommandForDelete" type="jobDto"/>
    */

    jobCommandForDelete?: any,


    /**
     * 
Data Type : jobDto
/// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="jobCommandForUpdate" type="jobDto"/>
    */

    jobCommandForUpdate?: any,


    maxRecordsCount?: number,


    objectAvailable?: boolean,


    /**
     * 
Data Type : objectGraphInstruction
/// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="objectGraphInstruction" type="objectGraphInstruction"/>
    */

    objectGraphInstruction?: any,


    /**
     * 
Data Type : jobDto
/// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" maxOccurs="unbounded" minOccurs="0" name="onDemandFormJobs" nillable="true" type="jobDto"/>
    */

    onDemandFormJobs?: any,


    parentVersion?: number,


    partOfTruncatedDataset?: boolean,


    /**
     * 
Data Type : assystDto
/// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:axios="http://www.axiossystems.com/assystREST/schema" axios:resourcePath="/query" minOccurs="0" name="previousVersionDto" type="assystDto"/>
    */

    previousVersionDto?: any,


    resolveNestedObjects?: boolean,


    systemRecordFlag?: boolean,


    totalRecordsCount?: number,


    version?: number,


    /**
     * 
Data Type : webCustomPropertyValueDto
/// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" maxOccurs="unbounded" minOccurs="0" name="customFields" type="webCustomPropertyValueDto"/>
    */

    customFields?: any,


    /**
     * 
Data Type : windowsCustomFieldPropertyValueDto
/// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" maxOccurs="unbounded" minOccurs="0" name="windowsCustomFields" type="windowsCustomFieldPropertyValueDto"/>
    */

    windowsCustomFields?: any,


    /**
     * 
Data Type : windowsCustomLookupPropertyValueDto
/// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" maxOccurs="unbounded" minOccurs="0" name="windowsCustomLookups" type="windowsCustomLookupPropertyValueDto"/>
    */

    windowsCustomLookups?: any,

}


export interface AssystBaseDto extends AssystDto {


    /**
     * 
Data Type : attachmentDto
/// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" maxOccurs="unbounded" minOccurs="0" name="attachments" nillable="true" type="attachmentDto"/>
    */

    attachments?: any,


    /**
     * 
Data Type : webCustomColumnDto
/// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" maxOccurs="unbounded" minOccurs="0" name="customColumns" nillable="true" type="webCustomColumnDto"/>
    */

    customColumns?: any,


    discontinued?: boolean,

    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="image"/>
     */


    imageId?: number,


    modifyDate?: Date,


    modifyId?: string,


    name?: string,


    remarks?: string,


    /**
     * 
Data Type : richTextFieldDto
/// Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" name="richRemarks" type="richTextFieldDto"/>
    */

    richRemarks?: RichTextFieldDto,


    shortCode?: string,

}


export interface AssystBaseCSGDto extends AssystBaseDto {

    /**
     * Ref object discarded 
     * <xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" minOccurs="0" ref="csg"/>
     */


    csgActive?: boolean,


    csgEnabled?: boolean,


    csgId?: number,


    csgShortCode?: string,

}



