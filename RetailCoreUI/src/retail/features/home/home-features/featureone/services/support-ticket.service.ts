import { Injectable } from '@angular/core';
import { HttpService } from '../../../../../core/http/http.service';
import { LoggerService } from '../../../../../core/services/logger.service';
import { Observable, map } from 'rxjs';
import { ApiResponse } from '../../../../../core/models/api-response.model';
import { ApiEndPoints} from '../../../../../config/api-end-points';
import { DataPersistanceService } from '../../../../../core/services/data-persistance.service';
import { IssueType } from '../models/issue-type.models';
import { IssueArea } from '../models/issue-area.models';
import { TicketPriority } from '../models/ticket-priority.models';
import { ISupportTicket } from '../models/support-ticket.models';

@Injectable()
export class SupportTicketService {

  constructor(
    private http: HttpService,
    private loggerService: LoggerService,
    private dataPersistance: DataPersistanceService
  ) { }

  getIssueTypes(): Observable<Array<IssueType>> {
    return this.http
      .get<ApiResponse<Array<IssueType>>>(ApiEndPoints.get_IssueTypes)
      .pipe(
        map((models) => {
          return models.result;
        })
      );
  }
  getIssueAreas(): Observable<Array<IssueArea>> {
    return this.http
      .get<ApiResponse<Array<IssueArea>>>(ApiEndPoints.get_IssueAreas)
      .pipe(
        map((models) => {
          return models.result;
        })
      );
  }
  getTicketPriorities(): Observable<Array<TicketPriority>> {
    return this.http
      .get<ApiResponse<Array<TicketPriority>>>(ApiEndPoints.get_TicketPriorities)
      .pipe(
        map((models) => {
          return models.result;
        })
      );
  }
  createSupportTicket(supportTicketInfo: any): Observable<any> {
    var formData = new FormData();

    for (let key in supportTicketInfo) {
      if (supportTicketInfo.hasOwnProperty(key)) {
        formData.append(key, supportTicketInfo[key]);
      }
    }
    return this.http
      .post<ApiResponse<any>>(ApiEndPoints.post_CreateSupportTicket, formData)
      .pipe(
        map((result) => {
          return result;
        })
      );
  }
  getSupportTicketList(userid: string, seachText:string, filterType:string): Observable<Array<ISupportTicket>> {
    const reqBody = {
      userId: userid,
      searchText: seachText,
      filterType: filterType
    };

    return this.http
      .post<ApiResponse<Array<ISupportTicket>>>(ApiEndPoints.post_getSupportTickets, reqBody)
      .pipe(
        map((supporttickets) => {
          return supporttickets.result;
        })
      );
  }
}
