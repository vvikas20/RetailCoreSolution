import { Injectable } from '@angular/core';
import { HttpService } from '../../../../../core/http/http.service';
import { LoggerService } from '../../../../../core/services/logger.service';
import { map, Observable } from 'rxjs';
import { AddProjectUserParameter, DeletedProjectParameter, ProjectListView, ProjectSearchParameter } from '../models/project-list.model';
import { HttpHeaders } from '@angular/common/http';
import { ApiEndPoints } from '../../../../../config/api-end-points';
import { ApiResponse } from '../../../../../core/models/api-response.model';
import { User } from '../../../../auth/models/registration/user.model';

@Injectable({
  providedIn: 'root'
})
export class ProjectListService {

  constructor(private http: HttpService,
    private loggerService: LoggerService) { }

  getProjectInfoList(searchParam: ProjectSearchParameter): Observable<Array<ProjectListView>> {
    const reqfilter = {
      projectStatus: searchParam.projectStatus,
      quickSearchValue: searchParam.quickSearchValue,
      basicSearchValue: searchParam.basicSearchValue,
      userGuidValue: searchParam.userGuidValue,
      isDeleted: searchParam.IsDeleted,
      IsOtherEmployeeProject: searchParam.IsOtherEmployeeProject
    };

    return this.http
      .post<any>(ApiEndPoints.get_projectlist, reqfilter)
      .pipe(
        map((data) => {
          if (data.result) {
            return data.result;
          }

        })
      );
  }

  addAdditionalUsers(addUserParam: AddProjectUserParameter): Observable<any> {
    debugger;
    const reqfilter = {
      projectId: addUserParam.projectId,
      userIdList: addUserParam.userIdList,
      createdUserId: addUserParam.createdUserId
    };
    this.loggerService.log('reqData', reqfilter);

    return this.http
      .post<boolean>(ApiEndPoints.adduser_project, reqfilter)
      .pipe(map((data) => {
        return data;
      }))
  }

  deleteProjects(deletedProjectParameter: DeletedProjectParameter): Observable<any> {
    // debugger;
    const reqfilter = {
      projectListId: deletedProjectParameter.projectListId,
      userId: deletedProjectParameter.userId
    };

    return this.http
      .post<boolean>(ApiEndPoints.delete_projectlist, reqfilter)
      .pipe(map((data) => {
        return data;
      }))
  }

  getSearchInformation(
    searchCondition: string,
    searchValue: string,
    userID: string
  ): Observable<Array<User>> {
    let url =
      ApiEndPoints.getSearchInformation +
      searchCondition +
      '&searchValue=' +
      searchValue +
      '&userID=' +
      userID;
    return this.http.get<ApiResponse<Array<User>>>(url).pipe(
      map((users) => {
        return users.result;
      })
    );
  }

  restoreProjects(deletedProjectParameter: DeletedProjectParameter): Observable<any> {
    const reqfilter = {
      projectListId: deletedProjectParameter.projectListId,
      userId: deletedProjectParameter.userId
    };

    return this.http
      .post<boolean>(ApiEndPoints.restore_projectlist, reqfilter)
      .pipe(map((data) => {
        return data;
      }))
  }
}
