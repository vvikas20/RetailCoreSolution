import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve } from '@angular/router';
import { Observable } from 'rxjs';
import { AutherizationService } from '../../../core/auth/autherization.service';
import { IPermission } from '../../../core/models/app-permission';

@Injectable({
  providedIn: 'root'
})
export class HomeResolverService implements Resolve<any> {

  constructor(private autherization: AutherizationService) { }

  resolve(route: ActivatedRouteSnapshot): Observable<IPermission> {
    return this.autherization.getPermission();
  }
}
