import { Injectable } from '@angular/core';
import { HttpService } from '../../../core/http/http.service';
import { Observable, map } from 'rxjs';
import { ApiEndPoints } from '../../../config/api-end-points';
import { ApiResponse } from '../../../core/models/api-response.model';
import { LoggerService } from '../../../core/services/logger.service';
import { IforgotPassword } from '../models/forgot-password/forgotPassword.model';

@Injectable({
  providedIn: 'root',
})
export class ForgetPasswordService {
  constructor(private http: HttpService, private logger : LoggerService) {}

  forgotPassword(email: string): Observable<IforgotPassword> {
    const url = `${ApiEndPoints.forgot_password}${email}`
    return this.http
      .get<ApiResponse<IforgotPassword>>(`${ApiEndPoints.forgot_password}${email}`)
      .pipe(
        map((response) => {
          return response.result;
        })
      );
  }
}
