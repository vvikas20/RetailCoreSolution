import { Injectable, inject } from "@angular/core";
import { HttpService } from "../../../core/http/http.service";
import { LoggerService } from "../../../core/services/logger.service";
import { Observable, map } from "rxjs";
import { ApiResponse } from "../../../core/models/api-response.model";
import { ApiEndPoints } from "../../../config/api-end-points";
import { IMenu } from "../models/menu.models";
import { appMenus } from "../../../config/app-menus";
import { Utility } from "../../../core/utility/utility";

@Injectable()
export class MenuManagementService {
  lstAppMenu = appMenus;
  constructor(
    private http: HttpService,
    private loggerService: LoggerService
  ) { }

  getLeftSideMenus(): Observable<Array<IMenu>> {
    return this.http
      .get<ApiResponse<Array<IMenu>>>(ApiEndPoints.leftSideMenu)
      .pipe(
        map((menus) => {
          return Utility.innerJoin(menus.result, this.lstAppMenu, 'menu_Key', 'validationKey');
        })
      );
  }
}