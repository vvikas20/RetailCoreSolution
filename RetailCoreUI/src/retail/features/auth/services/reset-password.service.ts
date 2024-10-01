import { Injectable } from '@angular/core';
import { HttpService } from '../../../core/http/http.service';
import { Observable, map } from 'rxjs';
import { ApiEndPoints } from '../../../config/api-end-points';
import { ApiResponse } from '../../../core/models/api-response.model';
import { __param } from 'tslib';

@Injectable()
export class ResetPasswordService {
  constructor(private http: HttpService) {}

  resetPassword(uid: string, userpassword: string): Observable<boolean> {
    var newPassword = {UserId : uid, Password : userpassword}
    return this.http
      .put<ApiResponse<boolean>>(
        ApiEndPoints.reset_password,newPassword).pipe(map((isPasswordUpdated) => {
          return isPasswordUpdated.result;
        })
      );
  }
}
