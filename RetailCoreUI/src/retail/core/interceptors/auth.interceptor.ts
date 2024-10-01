import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { DataPersistanceService } from '../services/data-persistance.service';
import { Router } from '@angular/router';
import { of } from 'rxjs';
import { SkipJWTTokenHeader } from '../../constant/app-constant';

export const authInterceptor: HttpInterceptorFn = (req, next) => {

  if (req.headers.has(SkipJWTTokenHeader)) {
    const headers = req.headers.delete(SkipJWTTokenHeader);
    return next(req.clone({ headers }));
  }

  if (req.url.toString().includes('assets')) {
    return next(req.clone());
  }

  const dataPersistenceService = inject(DataPersistanceService);

  let authToken = dataPersistenceService.access_token;

  if (authToken != null || authToken != '') {
    const clonedReq = req.clone({
      headers: req.headers.set('Authorization', `Bearer ${authToken}`)
    });
    return next(clonedReq);

  } else {
    const router = inject(Router);
    router.navigateByUrl('/');
    return of();
  }

};
