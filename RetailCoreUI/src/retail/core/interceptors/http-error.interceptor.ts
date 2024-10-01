import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { Inject, inject } from '@angular/core';
import { catchError, of, throwError } from 'rxjs';
import { AlertService } from '../ui-services/alert.service';
import { ApiResponse } from '../models/api-response.model';
import { LoggerService } from '../services/logger.service';
import { isApiResponse } from '../guards/type.guard';
import { SkipAlertHeader } from '../../constant/app-constant';


export const httpErrorInterceptor: HttpInterceptorFn = (req, next) => {

  const alertService = inject(AlertService);
  const logger = inject(LoggerService);

  return next(req).pipe(
    catchError((error: HttpErrorResponse) => {

      let errorMessage = 'An unknown error occurred!';

      if (error.error instanceof ErrorEvent) {
        // Client-side or network error
        errorMessage = `Error: ${error.error.message}`;
      }
      else if (error.error && isApiResponse(error.error)) {
        // Server-side error
        let apiResponseError: ApiResponse<any> = error.error;
        logger.error(`Timestamp: ${new Date().toLocaleString()} 
        \n Endpoint: ${error.url} 
        \n Error Code: ${error.status || 500} Error Message: ${apiResponseError.responseException?.exceptionMessage || apiResponseError.message || "An unknown error occurred"}`);

        return throwError(() => { throw apiResponseError; })
      }
      else {
        errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
      }

      if (!req.headers.has(SkipAlertHeader)) {
        alertService.error('API Call Error', errorMessage);
      }
      return throwError(() => new Error(errorMessage));
    })
  );
};
