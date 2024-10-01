import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { DataPersistanceService } from '../services/data-persistance.service';
import { LayoutService } from '../services/layout.service';
import { IUserType } from '../models/user-type.model';

export const authGuard: CanActivateFn = (route, state) => {
  let dataPersistanceService = inject(DataPersistanceService);
  let router = inject(Router);
  let layout = inject(LayoutService);

  let authenticated = dataPersistanceService.access_token != '';
  // let lstUsertypes = layout.getUserTypes();

  if (!authenticated) {
    router.navigateByUrl('/');
  }
  // console.log('lstUsertypes',lstUsertypes);
  return authenticated;
};
