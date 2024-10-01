export class ProjectScheduleLineitem {
    projectId: string = '';
    scheduleId: string = '';
    productFamilyID: string = '';
    newUnitID: string = '';
    existingUnitID: string = '';
    modelID: string = '';
    tag:string='';
    quantity:number=0;
    perfVerified:boolean=false;
    priceVerified:boolean=false;
    submittalReq:boolean=false;
    quotationID:string='';
    orderID:string='';
    createdBy:string='';
}