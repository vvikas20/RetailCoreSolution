import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { IVerticalMarket } from '../../../../auth/models/registration/verticalMarket.model';
import { ApiResponse } from '../../../../../core/models/api-response.model';
import { ApiEndPoints } from '../../../../../config/api-end-points';
import { HttpService } from '../../../../../core/http/http.service';
import { LoggerService } from '../../../../../core/services/logger.service';
import { IProjectPhase } from '../../../../auth/models/project-info/projectphase';
import { User } from '../../../../auth/models/registration/user.model';
import { IProjectPermissionLevel } from '../../../../auth/models/project-info/permission-level';
import { ICustomerCompanyName } from '../models/customer-company-name.model';
import { createProject } from '../models/create-project.model';
import { HttpHeaders } from '@angular/common/http';
import { DeletedProjectDocument } from '../models/projectInfo.model';

@Injectable()
export class ProjectInfoService {
  constructor(
    private http: HttpService,
    private loggerService: LoggerService
  ) {}

  getVerticalMarket(): Observable<Array<IVerticalMarket>> {
    return this.http
      .get<ApiResponse<Array<IVerticalMarket>>>(ApiEndPoints.get_verticalMarket)
      .pipe(
        map((verticalMarket) => {
          return verticalMarket.result;
        })
      );
  }
  getProjectPhase(): Observable<Array<IProjectPhase>> {
    return this.http
      .get<ApiResponse<Array<IProjectPhase>>>(ApiEndPoints.get_projectphase)
      .pipe(
        map((projectPhase) => {
          return projectPhase.result;
        })
      );
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
  getProjectPermissionLevel(): Observable<Array<IProjectPermissionLevel>> {
    return this.http
      .get<ApiResponse<Array<IProjectPermissionLevel>>>(
        ApiEndPoints.get_projectpermissionlevel
      )
      .pipe(
        map((permissions) => {
          return permissions.result;
        })
      );
  }

  getAdministratorProjectPermissionLevel(): Observable<Array<IProjectPermissionLevel>> {
    return this.http
      .get<ApiResponse<Array<IProjectPermissionLevel>>>(
        ApiEndPoints.get_AdministratorPermissionLevel
      )
      .pipe(
        map((permissions) => {
          return permissions.result;
        })
      );
  }

  //get the customer company name list
  getCustomerCompanyNameList(
    nameStartsWith: string
  ): Observable<Array<ICustomerCompanyName>> {
    return this.http
      .get<ApiResponse<Array<ICustomerCompanyName>>>(
        `${ApiEndPoints.get_projectCustomerDetail}${nameStartsWith}`
      )
      .pipe(
        map((customercompanyNameList) => {
          return customercompanyNameList.result;
        })
      );
  }

  //create project
  createProject(createProject: any, projectCustomerParameter : any, projectUserParameterList : any, projectDocumentParameterList:any,files: File[]): Observable<any> {
    var formData = new FormData();
    
    for (let key in createProject) {
      if (createProject.hasOwnProperty(key)) {
        formData.append(key, createProject[key]);
      }
    }

    for (let key in projectCustomerParameter) {
      if (projectCustomerParameter.hasOwnProperty(key)) {
        formData.append(`ProjectCustomerParameterObj.${key}`, projectCustomerParameter[key]);
      }
    }
    for (let i = 0; i < projectUserParameterList.length; i++) {
      const user = projectUserParameterList[i];
      formData.append(`projectUserParameterList[${i}].UserId`, user.UserId);
      formData.append(`projectUserParameterList[${i}].PermissionLevelID`, user.permissionLevelID);
    }

    for (let i = 0; i < projectDocumentParameterList.length; i++) {
      const document = projectDocumentParameterList[i];
      formData.append(`projectDocumentParameterList[${i}].fileName`, document.fileName);
      formData.append(`projectDocumentParameterList[${i}].documentDescription`, document.documentDescription);
    }

    for (let file of files) {
      formData.append('files', file);
    }
    return this.http
      .post<ApiResponse<any>>(ApiEndPoints.create_project, formData)
      .pipe(
        map((result) => {
          return result;
        })
      );
  }

  updateProject(updatedProjectDetails : any,projectCustomerParameterDetails: any,projectUserParameterList : any): Observable<any> {
    var formData = new FormData();
    for (let key in updatedProjectDetails) {
      if (updatedProjectDetails.hasOwnProperty(key)) {
        formData.append(key, updatedProjectDetails[key]);
      }
    }

    for (let key in projectCustomerParameterDetails) {
      if (projectCustomerParameterDetails.hasOwnProperty(key)) {
        formData.append(`ProjectCustomerParameterObj.${key}`, projectCustomerParameterDetails[key]);
      }
    }

    for (let i = 0; i < projectUserParameterList.length; i++) {
      const user = projectUserParameterList[i];
      formData.append(`projectUserParameterList[${i}].id`, user.id);
      formData.append(`projectUserParameterList[${i}].UserId`, user.UserId);
      formData.append(`projectUserParameterList[${i}].PermissionLevelID`, user.permissionLevelID);
    }
    return this.http
      .post<ApiResponse<any>>(ApiEndPoints.update_project, formData)
      .pipe(
        map((result) => {
          return result;
        })
      );
  }

  getExistingProject(projectId : string,userGuidID : string) : Observable<any>{
    return this.http.get<ApiResponse<any>>(`${ApiEndPoints.get_singe_project}${projectId}&userGuidID=${userGuidID}`).pipe(map((projectDetail)=>{
      return projectDetail.result;
    }))
  }

  validateDuplicateProject(projectName : string) {
    return this.http
    .get<ApiResponse<boolean>>(`${ApiEndPoints.validateProjectName}${projectName}`)
    .pipe(
      map((validateProject) => {
        return validateProject.result;
      })
    );
  }

  deleteDocuments(deletedDocumentParameter: DeletedProjectDocument): Observable<any> {
    const reqfilter = {
      projectId: deletedDocumentParameter.projectId,
      documentListId: deletedDocumentParameter.documentListId,
      userId: deletedDocumentParameter.userId
    };

    return this.http
      .post<boolean>(ApiEndPoints.delete_documentslist, reqfilter)
      .pipe(map((data) => {
        return data;
      }))
  }

  downloadDocument(projectId : string,fileName : string) : Observable<any>{
    let url = ApiEndPoints.get_DownloadScheduleDocument + projectId + "&fileName=" + fileName;
    return this.http
    .get<ApiResponse<any>>(url)
    .pipe(map((data) => {
      return data.result;
    }))
  }

  checkUserEditPermission(projectId : string, userGuid: string) : Observable<boolean>{
    debugger;
  return this.http.get<ApiResponse<any>>(ApiEndPoints.checkUserEditPermission + projectId +`&userGuidID=` +userGuid).pipe(map((response)=>{
    if(response){
      return response.result
    }
  }))
  }
}
