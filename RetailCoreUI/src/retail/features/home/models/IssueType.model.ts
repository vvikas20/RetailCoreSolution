export interface IIssueType{
    Id:string;
    Name:string;
}
export interface IIssueTypeUser{
    UserId:string;
    IssueTypeId:string;
    IssueTypeMappingId:string;
    Name:string;
    IssueType:string;
    CompanyName:string
    CreatedOn:Date;

}

export class issueMappedWithUser{
    mappedIdList:Array<string>=[]
    userIdList:Array<string>=[]
    issueTypeId:string=''
    createdBy:string=''
}

