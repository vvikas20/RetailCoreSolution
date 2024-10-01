import { Injectable } from '@angular/core';
import { map, Observable, of } from 'rxjs';
import { IPermission } from '../models/app-permission';
import { ApiEndPoints } from '../../config/api-end-points';
import { ApiResponse } from '../models/api-response.model';
import { HttpService } from '../http/http.service';

@Injectable()
export class AutherizationService {

  constructor(private http: HttpService,) { }

  // getPermission(): Observable<Array<IPermission>> {
  //   return this.http
  //     .get<ApiResponse<Array<IPermission>>>(ApiEndPoints.get_permissiontypes)
  //     .pipe(
  //       map((permission) => {
  //         console.log('permission.result',permission.result);
  //         return permission.result;
  //       })
  //     );
  // }
  getPermission(): Observable<IPermission> {
    let permission: IPermission = {
      id : "6B5CA65B-8DC3-4BFA-9B8B-35E31FF69F84",
      name : "WRITE",
      description:"WRITE",
      isactive:true
    } ;
   return of(permission);
  }
}
