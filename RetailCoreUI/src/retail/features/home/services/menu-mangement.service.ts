import { Injectable, inject } from "@angular/core";
import { HttpService } from "../../../core/http/http.service";
import { LoggerService } from "../../../core/services/logger.service";
import { Observable, map } from "rxjs";
import { ApiResponse } from "../../../core/models/api-response.model";
import { ApiEndPoints } from "../../../config/api-end-points";
import { appMenus } from "../../../config/app-menus";
import { Utility } from "../../../core/utility/utility";
import { MenuItem } from "primeng/api";

@Injectable()
export class MenuManagementService {
  appMenuItems: Array<MenuItem> = appMenus;
  constructor(
    private http: HttpService,
    private loggerService: LoggerService
  ) { }

  getMenuItems(): Observable<Array<MenuItem>> {
    return this.http
      .get<ApiResponse<Array<MenuItem>>>(ApiEndPoints.leftSideMenu)
      .pipe(
        map((menus) => {
          return Utility.innerJoin(menus.result, this.appMenuItems, 'menu_Key', 'validationKey');
        })
      );
  }
}