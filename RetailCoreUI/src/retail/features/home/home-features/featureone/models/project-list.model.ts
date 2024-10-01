export interface ProjectListView{
    id:string
    projectStatus: boolean
    projectName : string
    projectPhaseName : string
    createdOn : Date
    createdBy: string
    modifiedBy: string
    updatedOn: Date
    Probability:number
    ExpectedBidDueDate:Date
    DELETEDOn:Date
}

export class ProjectSearchParameter{
    projectStatus:number = 0
    quickSearchValue:number= 0
    basicSearchValue:string = ''
    userGuidValue:string = ''
    IsDeleted:number=0
    IsOtherEmployeeProject:boolean = false
}

export class DeletedProjectParameter {
    projectListId: Array<string> = []
    userId: string = ''
}

export class AddProjectUserParameter {
    projectId: string = ''
    userIdList: Array<string> = []
    createdUserId: string = ''
}