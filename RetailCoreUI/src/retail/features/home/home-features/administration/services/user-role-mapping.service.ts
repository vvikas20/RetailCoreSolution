import { Injectable } from '@angular/core';
import { HttpService } from '../../../../../core/http/http.service';
import { LoggerService } from '../../../../../core/services/logger.service';
import { map, Observable } from 'rxjs';
import { User } from '../../../../auth/models/registration/user.model';
import { ApiResponse } from '../../../../../core/models/api-response.model';
import { ApiEndPoints } from '../../../../../config/api-end-points';
import { IPermission } from '../../../../../core/models/app-permission';
import { HttpHeaders } from '@angular/common/http';
import { DataPersistanceService } from '../../../../../core/services/data-persistance.service';
import { IUserMenuPermissions } from '../../../models/user-menu-list-models';

@Injectable()
export class UserRoleMappingService {

  constructor(
    private http: HttpService,
    private loggerService: LoggerService,
    private dataPersistanceService: DataPersistanceService
  ) { }

getUserMenuPermissionList(searchText:string): Observable<Array<IUserMenuPermissions>> {
let reqBody = {
  userId:this.dataPersistanceService.userGuid,
  searchText:searchText
};
    return this.http
      .post<ApiResponse<Array<IUserMenuPermissions>>>(ApiEndPoints.get_UserMenuPermissionList,reqBody)
      .pipe(
        map((users) => {
          return users.result;
        })
      );
  }
  getPermission(): Observable<Array<IPermission>> {
    return this.http
      .get<ApiResponse<Array<IPermission>>>(ApiEndPoints.get_permissiontypes)
      .pipe(
        map((permission) => {
          return permission.result;
        })
      );
  }
  createUserPermissionMapping(_mappingRequest: any): Observable<any> {
    let _mappings:Array<any> = [];
    _mappings = _mappingRequest

    const reqBody = {
      mappings: _mappings,
      createdBy:this.dataPersistanceService.userGuid
    };
    const reqHeader = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http
      .post<any>(ApiEndPoints.post_UserPermissionMapping, reqBody, { headers: reqHeader })
      .pipe(
        map((data) => {
          if (data.result) {
            return data;
          }
        })
      );
  }
  revokeUserPermissionMapping(_mappingRequest: any): Observable<any> {
    let _mappings:Array<any> = [];
    _mappings = _mappingRequest

    const reqBody = {
      mappings: _mappings,
      createdBy:this.dataPersistanceService.userGuid
    };
    const reqHeader = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http
      .post<any>(ApiEndPoints.post_RevokeUserPermissionMapping, reqBody, { headers: reqHeader })
      .pipe(
        map((data) => {
          if (data.result) {
            return data;
          }
        })
      );
  }
}
