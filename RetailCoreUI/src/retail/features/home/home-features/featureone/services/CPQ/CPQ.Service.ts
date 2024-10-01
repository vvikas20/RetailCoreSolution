import { Injectable } from '@angular/core';
import { HttpService } from '../../../../../../core/http/http.service';
import { LoggerService } from '../../../../../../core/services/logger.service';
import { DataPersistanceService } from '../../../../../../core/services/data-persistance.service';
import { ApiEndPoints, CPQ_Configs } from '../../../../../../config/api-end-points';
import { HttpHeaders } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { ApiResponse } from '../../../../../../core/models/api-response.model';

@Injectable()
export class CPQ_service
{
    cpqEmbedconfig: any;
    selectedProduct: any;
    selectedAddedProduct: any;

    constructor(
        private http: HttpService,
        private loggerService: LoggerService,
        private dataPersistance: DataPersistanceService
      ) { }

      getCPQKBMaxURL() {
        return CPQ_Configs.KBMaxURL;
      }
    
    GetConfiguredProductFromCPQ(quoteProductID : any) : Observable<any>
    {
      const reqBody = {
        quoteProductId: quoteProductID
      };
      return this.http
        .post<any>(ApiEndPoints.cpq_getQuoteProductFromCPQ, quoteProductID).pipe(map((schedule) => {
          //alert(schedule.result);
            return schedule.result;
          }));
    }
      
  SaveConfiguredProduct(configuredProduct: any, projectid: any, scheduleId: any, loggedInUserId: any): Observable<any> {
    const reqBody = {
      configuredProductJson: JSON.stringify(configuredProduct),
      projectId: projectid,
      scheduleId: scheduleId,
      loggedInUserId: loggedInUserId
    };
    reqBody.scheduleId = 'F7493551-9562-4B61-A1CE-188F00567345';
    const reqHeader = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http
      .post<any>(ApiEndPoints.cpq_SaveConfiguredProduct, reqBody, { headers: reqHeader })
      .pipe(
        map((data) => {
          return data;
        })
      );
  }

    SaveAndSubmitConfiguredProduct(configuredProduct:any , projectid: any, scheduleId : any, loggedInUserId : any)
    {

    }
}