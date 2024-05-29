export type AssystSettings = {
    id: number,
    userName?: string,
    password?: string,
    baseUrl?: string
}

export enum eventTypesEnum {
    INCIDENT = "INCIDENT",
    CHANGE = "CHANGE",
    PROBLEM = "PROBLEM",
    NORMALTASK = "NORMALTASK",
    DECISIONTASK = "DECISIONTASK",
    AUTHORISATIONTASK = "AUTHORISATIONTASK",
    SERVICEREQUEST = "SERVICEREQUEST",
    ORDER = "ORDER",
}

export enum eventStatus {
    OPEN = "OPEN",
    CLOSED = "CLOSED",
    PENDING = "PENDING",
    SUBMITTED = "SUBMITTED",
}



export enum AssystEventActionTypes {
    AcknowledgmentActionTypeId = 3,
    WaitingOnCustomerInputActionTypeId = 189,
    CustomerInputReceivedActionTypeId = 190,
    CommentActionTypeId = 434
}


        
export interface RichTextFieldDto {                                
    content?:string,     
    plainTextContent?:string,
     
 /**
  * 
Data Type : attachmentDto
Element:<xs:element xmlns:xs="http://www.w3.org/2001/XMLSchema" maxOccurs="unbounded" minOccurs="0" name="unsavedInlineImages" nillable="true" type="attachmentDto"/>
 */
    unsavedInlineImages?:any,
 }
 


