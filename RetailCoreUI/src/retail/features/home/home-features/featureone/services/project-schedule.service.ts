import { Injectable } from '@angular/core';
import { HttpService } from '../../../../../core/http/http.service';
import { LoggerService } from '../../../../../core/services/logger.service';
import { Observable, ObservableLike, map } from 'rxjs';
import { IProductFamily } from '../models/productFamily.models';
import { ApiResponse } from '../../../../../core/models/api-response.model';
import { ApiEndPoints, CPQ_Configs } from '../../../../../config/api-end-points';
import { IProjectInfo } from '../models/projectInfo.model';
import { IProjectSchedule, IProjectScheduleListView, ProjectSchedule } from '../models/project-Schedule.model';
import { DataPersistanceService } from '../../../../../core/services/data-persistance.service';
import { IKCCModel } from '../models/kccModel.models';
import { HttpHeaders } from '@angular/common/http';
import { ProjectScheduleLineitem } from '../models/project-schedule-lineitem';
import { DeletLineItemDoc, ILineitemDocuments, IProjectAction, ScheduleAction } from '../models/project-Action.models';
import { IQuoteType } from '../models/quoteType-models';
import { cpqProduct } from '../models/cpqProduct.models';

@Injectable()
export class ProjectScheduleService {

  constructor(
    private http: HttpService,
    private loggerService: LoggerService,
    private dataPersistance: DataPersistanceService
  ) { }

  

  getAllCPQProducts(): Observable<Array<cpqProduct>> {
    return this.http
      .get<ApiResponse<Array<cpqProduct>>>(ApiEndPoints.getSchedule_AllCpqProducts)
      .pipe(
        map((units) => {
          return units.result;
        })
      );
  }

  getProductFamily(): Observable<Array<IProductFamily>> {
    return this.http
      .get<ApiResponse<Array<IProductFamily>>>(ApiEndPoints.getSchedule_kccunit)
      .pipe(
        map((units) => {
          return units.result;
        })
      );
  }
  getProjectScheduleActionList(): Observable<Array<IProjectAction>> {
    return this.http
      .get<ApiResponse<Array<IProjectAction>>>(ApiEndPoints.get_ProjectScheduleActionList)
      .pipe(
        map((models) => {
          return models.result;
        })
      );
  }
  getKCCModel(): Observable<Array<IKCCModel>> {
    return this.http
      .get<ApiResponse<Array<IKCCModel>>>(ApiEndPoints.getSchedule_kccmodel)
      .pipe(
        map((models) => {
          return models.result;
        })
      );
  }
  getQuoteTypes(): Observable<Array<IQuoteType>> {
    return this.http
      .get<ApiResponse<Array<IQuoteType>>>(ApiEndPoints.get_ProjectScheduleQuoteTypes)
      .pipe(
        map((models) => {
          return models.result;
        })
      );
  }
  getProjectInfo(): Observable<Array<IProjectInfo>> {
    let param = {
      "projectStatus": 2,
      "quickSearchValue": 0,
      "basicSearchValue": "",
      "advanceSearchField": "",
      "advanceSearchCondition": 0,
      "advanceSearchText": "",
      "userGuidValue": this.dataPersistance.userGuid
    }

    return this.http
      .post<ApiResponse<Array<IProjectInfo>>>(ApiEndPoints.getProjectInfoList, param)
      .pipe(
        map((projects) => {
          return projects.result;
        })
      );
  }
  getProjectSchedule(): Observable<Array<IProjectSchedule>> {
    return this.http
      .get<ApiResponse<Array<IProjectSchedule>>>(ApiEndPoints.getProjectScheduleList)
      .pipe(
        map((schedule) => {
          return schedule.result;
        })
      );
  }
  createShedule(schedule: ProjectSchedule): Observable<ProjectSchedule> {
    this.loggerService.log('schedule object', schedule);
    const reqBody = {
      scheduleName: schedule.scheduleName,
      description: schedule.description,
      notes: schedule.notes,
      projectId: schedule.projectId,
      createdBy: schedule.createdBy,
    };
    const reqHeader = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http
      .post<any>(ApiEndPoints.post_CreateSchedule, reqBody, { headers: reqHeader })
      .pipe(
        map((data) => {
          if (data.result) {
            return data;
          }
        })
      );
  }
  updateSheduleStatus(id: string, status: boolean): Observable<ProjectSchedule> {
    this.loggerService.log('schedule id', id);
    let url = ApiEndPoints.post_UpdateScheduleStatus + id + "&status=" + status;
    const reqHeader = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http
      .post<any>(url, "", { headers: reqHeader })
      .pipe(
        map((data) => {
          if (data.result) {
            return data;
          }
        })
      );
  }
  updateScheduleInfo(id: string, scheduleName: string, notes: string): Observable<ProjectSchedule> {
    this.loggerService.log('schedule id', id);
    let url = ApiEndPoints.post_UpdateScheduleInfo + id + "&scheduleName=" + scheduleName + "&notes=" + notes;
    const reqHeader = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http
      .post<any>(url, "", { headers: reqHeader })
      .pipe(
        map((data) => {
          if (data.result) {
            return data;
          }
        })
      );
  }
  createSheduleLineItem(schedule: ProjectScheduleLineitem): Observable<ProjectScheduleLineitem> {
    const reqBody = {
      projectId: schedule.projectId,
      scheduleId: schedule.scheduleId,
      productFamilyID: schedule.productFamilyID,
      newUnitID: schedule.newUnitID,
      existingUnitID: schedule.existingUnitID,
      modelID: schedule.modelID,
      tag: schedule.tag,
      quantity: schedule.quantity,
      perfVerified: schedule.perfVerified,
      priceVerified: schedule.priceVerified,
      submittalReq: schedule.submittalReq,
      quotationID: schedule.quotationID,
      orderID: schedule.orderID,
      createdBy: schedule.createdBy,
    };
    const reqHeader = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http
      .post<any>(ApiEndPoints.post_CreateScheduleLineItem, reqBody, { headers: reqHeader })
      .pipe(
        map((data) => {
          if (data.result) {
            return data;
          }
        })
      );
  }
  getProjectScheduleListView(projectId: string, schedules: Array<string>): Observable<Array<IProjectScheduleListView>> {
    const reqBody = {
      projectId: projectId,
      scheduleId: schedules,
    };

    return this.http
      .post<ApiResponse<Array<IProjectScheduleListView>>>(ApiEndPoints.get_cheduleLineItemView, reqBody)
      .pipe(
        map((schedule) => {
          return schedule.result;
        })
      );
  }
  sheduleActionLineItem(schedule: ScheduleAction): Observable<ScheduleAction> {
    const reqBody = {
      action: schedule.action,
      fromProjectId: schedule.fromProjectId,
      projectId: schedule.projectId,
      toScheduleId: schedule.toScheduleId,
      lineItemIds: schedule.lineItemIds,
      quotationIds: schedule.quotationIds,
      userId: schedule.userId
    };
    const reqHeader = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http
      .post<any>(ApiEndPoints.post_ScheduleAction, reqBody, { headers: reqHeader })
      .pipe(
        map((data) => {
          if (data.result) {
            return data;
          }
        })
      );
  }
  updateSubmittalStatus(id: string, status: boolean): Observable<any> {
    this.loggerService.log('schedule id', id);
    let url = ApiEndPoints.post_UpdateSubmittalStatus + id + "&status=" + status;
    const reqHeader = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http
      .post<any>(url, "", { headers: reqHeader })
      .pipe(
        map((data) => {
          if (data.result) {
            return data;
          }
        })
      );
  }
  uploadDocuments(id: string, description: string, userId: string, files: File[]): Observable<any> {
    const formData: FormData = new FormData();

    // Append data object to FormData
    formData.append('id', id);
    formData.append('description', description);
    formData.append('userId', userId);

    // Append files to FormData
    files.forEach((file, index) => {
      formData.append('files', file, file.name);
    });

    return this.http.post<any>(ApiEndPoints.post_ScheduleUploadFiles, formData).pipe(
      map((data) => {
        if (data.result) {
          return data;
        }
      })
    );
  }
  getLineitemDocuments(id: string): Observable<Array<ILineitemDocuments>> {
    let url = ApiEndPoints.get_LineitemDocuments + id;
    const reqHeader = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http
      .post<any>(url, "", { headers: reqHeader })
      .pipe(
        map((data) => {
          if (data.result) {
            return data.result;
          }
        })
      );
  }
  deletLineItemDoc(schedule: DeletLineItemDoc): Observable<DeletLineItemDoc> {
    const reqBody = {
      action: schedule.action,
      fromProjectId: schedule.fromProjectId,
      lineItemIds: schedule.lineItemIds,
      userId: schedule.userId
    };
    const reqHeader = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http
      .post<any>(ApiEndPoints.post_DeleteLineitemDocuments, reqBody, { headers: reqHeader })
      .pipe(
        map((data) => {
          if (data.result) {
            return data;
          }
        })
      );
  }
  downloadDocuments(id: string, fileName:string): Observable<any> {
    let url = ApiEndPoints.get_DownloadScheduleDocument + id + "&fileName=" + fileName;
    return this.http
      .get<any>(url)
      .pipe(
        map((result) => {
          return result;
        })
      );
  }

}
