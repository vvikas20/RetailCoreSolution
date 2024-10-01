export class SupportTicket { 
    Id: string='';    
    IssueTypeId: string ='';
    IssueAreaId: string ='';
    ProjectId: string ='';
    ProductId: string ='';
    IssueDetails: string ='';
    ModelNumber: string ='';
    PriorityId: string ='';
    EmailNotification: boolean = false;    
    CreatedBy: string ='';       
}

export interface ISupportTicket {
    id: string,
    issueID: number,
    issueTypeId: string,
    issueType: string, 
    issueAreaId: string,   
    issueArea: string,
    projectId: string,
    projectName: string,
    productId: string,
    productName: string,
    modelNumber: string,
    customerName: string,
    priorityId: string,
    priorityName: string,
    issueDetails: string,
    emailNotification: boolean,
    userName: string,
    raisedOn: string,
    raisedBy: string,
    assignedTo: boolean,
    status: string,
    resolution: string,
    isEditable: boolean,
    isAction: boolean    
}

export class viewSupportTicket {     
    issueType: string ='';
    issueArea: string ='';
    attachment: string ='';
    issuDetails: string ='';          
}