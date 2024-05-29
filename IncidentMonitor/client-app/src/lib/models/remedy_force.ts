export interface RemedyForceSettings {
    id: number,
    tokenEndPoint?: string,
    instanceUrl?: string,
    token?: string,
    grantType?: string,
    clientId?: string,
    clientSecret?: string,
    userName?: string,
    password?: string,
    accessToken?: string,
}

export interface RemedyForceAttributes {
    type?: string,
    url?: string
}

export interface RemedyForceObject {
    attributes?: RemedyForceAttributes,
    Id?: string,
    CreatedDate?: string,
    Name?: string,
}

export interface RemedyForceUser extends RemedyForceObject {
    Username?: string,
    LastName?: string,
    FirstName?: string,

}

export interface Account extends RemedyForceObject {

}

export interface RF_Status extends RemedyForceObject {

}

export interface RF_Impact extends RemedyForceObject {

}
export interface RF_Urgency extends RemedyForceObject { }

export interface RemedyForceHistoryEntry extends RemedyForceObject {
    IncidentId?: string,
    BMCServiceDesk__description__c?: string,
    BMCServiceDesk__note__c?: string,
    BMCServiceDesk__RichTextNote__c?: string,
    CreatedBy?: RemedyForceUser,

}

export interface RemedyForceIncident extends RemedyForceObject {
    Title__c?: string,
    BMCServiceDesk__Client_Account__c?: string,
    OwnerId?: string,
    IsDeleted?: boolean,
    CreatedById?: string,
    CreatedBy?: RemedyForceUser,
    BMCServiceDesk__FKOpenBy__r?: RemedyForceUser,//staf
    BMCServiceDesk__FKClient__r?: RemedyForceUser,//client
    BMCServiceDesk__FKAccount__r?: Account,
    BMCServiceDesk__queueName__c?: string,
    BMCServiceDesk__Queue__c?: string,
    BMCServiceDesk__FKStatus__r?: RF_Status,
    BMCServiceDesk__FKImpact__r?: RF_Impact,
    BMCServiceDesk__FKUrgency__r?: RF_Urgency,
    BMCServiceDesk__shortDescription__c?: string,
    BMCServiceDesk__incidentDescription__c?: string,
    BMCServiceDesk__respondedDateTime__c?: string,
    BMCServiceDesk__Launch_console__c?: string,


    BMCServiceDesk__Incident_Histories__r?: RemedyForceHistoryEntry[],

    InstanceUrl?: string,
    IncidentStatus?: IncidentespondedStatus,
    BMCServiceDesk__closeDateTime__c?: string,
    BMCServiceDesk__dueDateTime__c?: string,
    BMCServiceDesk__openDateTime__c?: string,
    BMCServiceDesk__Closed_By__c?: string,
    BMCServiceDesk__TotalWorkTime__c?: number,
    System_Category_del__c?: string,
    IFS_Functional_Flow__c?: string,
    Customer_Case_ID__c?: string,
    Environment__c?: string,


    Track__c?: string,
    Customer_Request_Type__c?: string,
    Cost_Center__c?: string,
    IFS_Case_ID__c?: string
    BMCServiceDesk__Status_ID__c?: string,
    CRIM__c?: boolean,



}

export interface RemedyForceTask extends RemedyForceObject {
    CreatedDate?: string,

    BMCServiceDesk__Client_Account__c?: string,

    BMCServiceDesk__Client_ID__c?: string,

    BMCServiceDesk__taskDescription__c?: string,

    BMCServiceDesk__shortDescription__c?: string,
    Incident_Title__c?: string,

    Incident_Account__c?: string,

    BA_Responsible_Incident_Staff__c?: string,

    TaskHistories?: TaskHistory[]

    BMCServiceDesk__FKOpenBy__r?: RemedyForceUser,//staf
    BMCServiceDesk__FKStatus__r?: RF_Status,
    bmcservicedesk__fkimpact__r?: RF_Impact,
    bmcservicedesk__fkurgency__r?: RF_Urgency,
    BMCServiceDesk__FKIncident__r?: RemedyForceIncident


}

export interface TaskHistory extends RemedyForceObject {
    CreatedDate?: string

    BMCServiceDesk__note__c?: string
}


export enum IncidentespondedStatus {
    Unknown = 0,
    UnrespondedInShift,
    RespondedInShift,
    UnsrespondedNotInShift,
    RespondedNotInShift,
    CallbackNotRequired,
}

