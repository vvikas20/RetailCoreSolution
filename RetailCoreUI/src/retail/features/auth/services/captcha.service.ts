import { Injectable } from '@angular/core';
import { ApiEndPoints } from '../../../config/api-end-points';
import { Observable, map } from 'rxjs';
import { HttpService } from '../../../core/http/http.service';
import { ICaptchaResponse } from '../models/registration/captcha.model';
import { ApiResponse } from '../../../core/models/api-response.model';

@Injectable()
export class CaptchaService {
  constructor(private http: HttpService) {}
  generateCaptcha(): Observable<ICaptchaResponse> {
    return this.http
      .get<ApiResponse<ICaptchaResponse>>(ApiEndPoints.generateCaptcha)
      .pipe(
        map((data) => {
          return data.result;
        })
      );
  }

  verifyCaptcha(captchavalue: string) {
    return this.http.post<any>(
      `${ApiEndPoints.verifyCaptcha}${captchavalue}`,
      '`'
    );
  }

  regenerateCaptcha(): Observable<ICaptchaResponse> {
    return this.http
      .get<ApiResponse<ICaptchaResponse>>(ApiEndPoints.regenerateCaptcha)
      .pipe(
        map((data) => {
          return data.result;
        })
      );
  }
}
