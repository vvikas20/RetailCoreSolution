import { Injectable } from '@angular/core';
import { HttpService } from '../../../../../core/http/http.service';
import { ApiResponse } from '../../../../../core/models/api-response.model';
import { IIssueType, IIssueTypeUser, issueMappedWithUser } from '../../../models/IssueType.model';
import { map,Observable } from 'rxjs';
import { ApiEndPoints } from '../../../../../config/api-end-points';
import { DataPersistanceService } from '../../../../../core/services/data-persistance.service';

@Injectable()
export class SupportTicketMappingService {

  constructor(
    private http:HttpService,
    private dataPersistanceService: DataPersistanceService
  ) { }

  GetAllIssueType():Observable<Array<any>>{
    return this.http.get<ApiResponse<Array<IIssueType>>>(ApiEndPoints.get_IssueTypes).pipe(map((issueType)=>{
      return issueType.result;
    }))
  }
    GetIssueTypeUser(issueTypeId: string): Observable<Array<any>> {
    return this.http
      .get<ApiResponse<Array<IIssueTypeUser>>>(ApiEndPoints.get_UserByIssueType+issueTypeId +'&userId='+this.dataPersistanceService.userGuid)
      .pipe(map((issuTypeUser) => {
        return issuTypeUser.result;
      }))
  }
  GetUserType(issueTypeId:string,Id:number):Observable<Array<any>>{
    return this.http.get<ApiResponse<Array<IIssueTypeUser>>>(ApiEndPoints.get_IssueByMappedType+issueTypeId +'&userId='+this.dataPersistanceService.userGuid + '&mappingType=' + Id)
    .pipe(map((UserType)=>{
      return UserType.result;
    }))
  }

  saveIssueUserMapping(userTypeMapping: issueMappedWithUser)
  {
    debugger;
    const reqfilter = {
      userIdList :userTypeMapping.userIdList,
      issueTypeId : userTypeMapping.issueTypeId,
      mappedIdList: userTypeMapping.mappedIdList,
      createdBy:userTypeMapping.createdBy
    };

    return this.http
      .post<boolean>(ApiEndPoints.post_SaveIssueUserMapping, reqfilter)
      .pipe(map((data) => {
        return data;
      }))
  }
}
