import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { IUser } from '../../../../auth/models/registration/user.model';
import { HttpService } from '../../../../../core/http/http.service';
import { LoggerService } from '../../../../../core/services/logger.service';
import { DataPersistanceService } from '../../../../../core/services/data-persistance.service';
import { ApiResponse } from '../../../../../core/models/api-response.model';
import { ApiEndPoints } from '../../../../../config/api-end-points';
import { SendEmailUserApproval } from '../models/send-email-user.modes';
import { IParentCompanyUserAccess } from '../models/parentcompany-useraccess.models';

@Injectable()
export class UserAccountApprovalService {

  constructor(
    private http: HttpService,
    private loggerService: LoggerService,
    private dataPersistanceService: DataPersistanceService
  ) { }

  getUsers(searchText: string): Observable<Array<IUser>> {
    let reqBody = {
      userId: this.dataPersistanceService.userGuid,
      searchText: searchText
    }
    return this.http
      .post<ApiResponse<Array<IUser>>>(ApiEndPoints.get_UsersView, reqBody)
      .pipe(
        map((users) => {
          return users.result;
        })
      );
  }
  updateApproveUser(userId: string): Observable<Array<IUser>> {
    let url = ApiEndPoints.post_UpdateApproveUser + userId + '&modifiedBy=' + this.dataPersistanceService.userGuid;
    return this.http
      .post<ApiResponse<Array<IUser>>>(url, '')
      .pipe(
        map((users) => {
          return users.result;
        })
      );
  }
  updateDeclineUser(userId: string, reason: string): Observable<Array<IUser>> {
    let reqBody = {
      userId: userId,
      modifiedBy: this.dataPersistanceService.userGuid,
      reason: reason
    }

    return this.http
      .post<ApiResponse<Array<IUser>>>(ApiEndPoints.post_UpdateDeclineUser, reqBody)
      .pipe(
        map((users) => {
          return users.result;
        })
      );
  }
  userEmailAccountApproval(emailObj: SendEmailUserApproval): Observable<Array<any>> {
    let reqBody = {
      userId: emailObj.userId,
      userName: emailObj.userName,
      emailId: emailObj.emailId,
      subject: emailObj.subject,
      body: emailObj.body,
      senderId: this.dataPersistanceService.userGuid
    }
    return this.http
      .post<ApiResponse<Array<IUser>>>(ApiEndPoints.post_UserEmailAccountApproval, reqBody)
      .pipe(
        map((users) => {
          return users.result;
        })
      );
  }
  assignProductPermissionStatus(productTypes: any, userId: string, selectedUserType: string, selectedStatus: boolean): Observable<Array<any>> {
    let reqBody = {
      products: productTypes,
      userId: userId,
      role: selectedUserType,
      status: selectedStatus,
      createdBy: this.dataPersistanceService.userGuid
    }
    return this.http
      .post<ApiResponse<Array<any>>>(ApiEndPoints.post_AssignProductPermissionStatus, reqBody)
      .pipe(
        map((users) => {
          return users.result;
        })
      );
  }
  editParentCompany(productTypes: any, _companyId: string, _domains: any, _brandId: string
    , _isAutoApprove: boolean): Observable<Array<any>> {
    let reqBody = {
      companyId: _companyId,
      products: productTypes,
      domains: _domains,
      brandId: _brandId,
      isAutoApprove: _isAutoApprove,
      updatedBy: this.dataPersistanceService.userGuid
    }
    return this.http
      .put<ApiResponse<Array<any>>>(ApiEndPoints.put_EditCustomerCompany, reqBody)
      .pipe(
        map((users) => {
          return users.result;
        })
      );
  }
  getParentCompanyUserAccess(companyId: string): Observable<Array<IParentCompanyUserAccess>> {
    let url = ApiEndPoints.get_ParentCompanyUserAccess+companyId;
    return this.http
      .get<ApiResponse<Array<IParentCompanyUserAccess>>>(url)
      .pipe(
        map((users) => {
          return users.result;
        })
      );
  }
}
