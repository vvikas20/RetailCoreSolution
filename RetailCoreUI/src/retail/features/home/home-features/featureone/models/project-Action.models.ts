export interface IProjectAction{
    id : string
    actionName : string
    isActive:boolean
}
export interface IScheduleView{
    id : string
    name : string
}
export class ScheduleAction {
    action: string = '';
    fromProjectId: string = '';
    projectId: string = '';
    toScheduleId: string = '';
    lineItemIds: Array<any> = [];
    quotationIds: Array<string> = [];
    userId:string='';
}
export interface ILineitemDocuments{
    id : string
    lineItemDetailId : string
    fileName:boolean
    documentDescription:string
    uploadedBy:string
    uploadedByName:string
    uploadedOn:string
}
export class DeletLineItemDoc{
    action: string = '';
    fromProjectId: string = '';
    lineItemIds : Array<any> = []
    userId:string='';
}