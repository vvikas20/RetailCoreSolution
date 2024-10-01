export interface IProjectInfo {
    id: string
    projectName: string
    description: string
    phaseId: string
    expectedBidDue: Date
    probability: number
    quote: string
    orderNo: string
    submittal: boolean
    verticalMarketId: string
    purchasingContractor_CompanyCity: string
    accountManager_ContractorRelationship: string
    customerAccountManager: string
    designEngineer_CompanyCity: string
    accountManager_EngineerRelationship: string
    customerManagerOffice: string
    isArchieve: boolean
    isActive: boolean
    createdDate: Date
    createdBy: string
    modifiedDate: Date
    modifiedBy: string
}

export class DeletedProjectDocument {
    projectId: string = ''
    documentListId: Array<any> = []
    userId: string = ''
}

export interface ProjectDocument {
    id: string;
    ProjectId: string;
    FileName: string;
    DocumentDescription: string;
    UploadedBy: string;
    UploadedOn: Date;
}
