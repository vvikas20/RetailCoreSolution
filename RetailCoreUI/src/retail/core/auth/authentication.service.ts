import { Injectable } from '@angular/core';
import { HttpService } from '../http/http.service';
import { DataPersistanceService } from '../services/data-persistance.service';
import { Observable, map } from 'rxjs';
import { HttpHeaders } from '@angular/common/http';
import { ApiEndPoints } from '../../config/api-end-points';
import { ApiResponse } from '../models/api-response.model';
import { AuthenticationResponse } from '../models/authentication-response.model';
import { LoggerService } from '../services/logger.service';
import {
  SkipJWTTokenHeader,
  SkipAlertHeader,
} from '../../constant/app-constant';
import { SendotpResponse } from '../models/sendotp-response.model';
import { VerifyotpResponse } from '../models/verifyotp-response.model';

@Injectable()
export class AuthenticationService {
  constructor(
    private http: HttpService,
    private dataPersistenceService: DataPersistanceService,
    private logger: LoggerService
  ) {}

  validate(
    username: string,
    password: string,
    captchaKey: string,
    captchaValue: string,
    IsRememberMe: boolean
  ): Observable<AuthenticationResponse> {
    var credentials =
      'username=' +
      username +
      '&password=' +
      btoa(password) +
      '&captchaKey=' +
      captchaKey +
      '&captchaValue=' +
      captchaValue +
      '&IsRememberMe=' +
      IsRememberMe;

    const reqHeader = new HttpHeaders({
      'Content-Type': 'application/x-www-form-urlencoded',
    })
      .append(SkipJWTTokenHeader, '')
      .append(SkipAlertHeader, '');

    return this.http
      .post<ApiResponse<AuthenticationResponse>>(
        ApiEndPoints.authentication,
        credentials,
        { headers: reqHeader }
      )
      .pipe(
        map((data) => {
          //login successful if there's a jwt token in the response
          if (data.result && data.result.access_token) {
            // store user details and jwt token in local storage to keep user logged in between page refreshes
            this.dataPersistenceService.access_token = data.result.access_token;
            this.dataPersistenceService.userGuid = data.result.userGuid;
            this.dataPersistenceService.userId = username;
            this.dataPersistenceService.userName = data.result.username;
          }
          return data.result;
        })
      );
  }

  verifyExistingToken(): Observable<boolean> {
    const reqHeader = new HttpHeaders({
      'Content-Type': 'application/x-www-form-urlencoded',
    }).append(SkipAlertHeader, '');

    return this.http
      .get<ApiResponse<boolean>>(ApiEndPoints.verifytoken, {
        headers: reqHeader,
      })
      .pipe(
        map((data) => {
          return data.result;
        })
      );
  }

  generateMfaOTP(
    userId: string,
    mfaProviderId: string
  ): Observable<SendotpResponse> {
    var mfaData = 'UserId=' + userId + '&MfaProviderId=' + mfaProviderId;

    const reqHeader = new HttpHeaders({
      'Content-Type': 'application/x-www-form-urlencoded',
    }).append(SkipAlertHeader, '');

    return this.http
      .post<ApiResponse<SendotpResponse>>(
        ApiEndPoints.generateMfaOTP,
        mfaData,
        { headers: reqHeader }
      )
      .pipe(
        map((data) => {
          return data.result;
        })
      );
  }

  validateMfaOTP(
    userId: string,
    otpValue: string
  ): Observable<VerifyotpResponse> {
    var mfaData = 'UserId=' + userId + '&OTPValue=' + otpValue;

    const reqHeader = new HttpHeaders({
      'Content-Type': 'application/x-www-form-urlencoded',
    }).append(SkipAlertHeader, '');

    return this.http
      .post<ApiResponse<VerifyotpResponse>>(
        ApiEndPoints.validateMfaOTP,
        mfaData,
        { headers: reqHeader }
      )
      .pipe(
        map((data) => {
          if (data.result && data.result.access_token) {
            // store user details and jwt token in local storage to keep user logged in between page refreshes
            this.dataPersistenceService.access_token = data.result.access_token;
            this.dataPersistenceService.userGuid = data.result.userGuid;
            this.dataPersistenceService.userId = userId;
          }
          return data.result;
        })
      );
  }
  removeToken() {
    localStorage.removeItem('access_token');
    localStorage.clear();
    // localStorage.clear();
  }
}
