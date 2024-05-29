export interface IHelpDeskComment {
    commentId: string,
    creationDate?: Date
    createdBy?: string,
    title?: string,
    plainTextDescription?: string,
    richTextDescription?: string,
    selected?:boolean
}