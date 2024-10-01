import { Injectable } from '@angular/core';
import { IAnnouncement, IAnnouncementHome } from '../models/announcements-view.models';
import { ApiEndPoints } from '../../../../../config/api-end-points';
import { HttpService } from '../../../../../core/http/http.service';
import { LoggerService } from '../../../../../core/services/logger.service';
import { ApiResponse } from '../../../../../core/models/api-response.model';
import { map, Observable } from 'rxjs';
import { IBrand } from '../../../../auth/models/registration/brand.model';
import { IUserType } from '../../../../../core/models/user-type.model';
import { IMainHeder } from '../models/main-headers.models';
import { User } from '../../../../auth/models/registration/user.model';
import { HttpHeaders } from '@angular/common/http';

@Injectable()
export class AnnouncementService {

  constructor(private http: HttpService,
    private loggerService: LoggerService) { }

  getAnnouncementList(userid: string, seachText:string): Observable<Array<IAnnouncement>> {
    const reqBody = {
      userId: userid,
searchText:seachText
    };

    return this.http
      .post<ApiResponse<Array<IAnnouncement>>>(ApiEndPoints.get_AnnouncementList, reqBody)
      .pipe(
        map((announcements) => {
          return announcements.result;
        })
      );
  }
  getBrands(): Observable<Array<IBrand>> {
    return this.http
      .get<ApiResponse<Array<IBrand>>>(ApiEndPoints.get_brand)
      .pipe(
        map((brands) => {
          return brands.result;
        })
      );
  }
  getSubProductTypes(): Observable<Array<IBrand>> {
    return this.http
      .get<ApiResponse<Array<IBrand>>>(ApiEndPoints.get_brand)
      .pipe(
        map((brands) => {
          return brands.result;
        })
      );
  }
  getUsertype(): Observable<Array<IUserType>> {
    return this.http
      .get<ApiResponse<Array<IUserType>>>(ApiEndPoints.get_usertype)
      .pipe(
        map((units) => {
          return units.result;
        })
      );
  }
  getMainHeaders(): Observable<Array<IMainHeder>> {
    return this.http
      .get<ApiResponse<Array<IMainHeder>>>(ApiEndPoints.get_MainHeaders)
      .pipe(
        map((units) => {
          return units.result;
        })
      );
  }
  createAnnouncement(announcementInfo: any, ownersTo: any, assignToIds: any, files: File[]): Observable<any> {
    var formData = new FormData();

    for (let key in announcementInfo) {
      if (announcementInfo.hasOwnProperty(key)) {
        formData.append(key, announcementInfo[key]);
      }
    }

    for (let i = 0; i < ownersTo.length; i++) {
      const user = ownersTo[i];
      formData.append(`ownersIds[${i}].UserId`, user);
    }

    for (let i = 0; i < assignToIds.length; i++) {
      const user = assignToIds[i];
      formData.append(`assignTo[${i}].UserId`, user);
    }

    for (let file of files) {
      formData.append('files', file);
    }

    console.log("formData", formData);

    return this.http
      .post<ApiResponse<any>>(ApiEndPoints.post_CreateAnnouncement, formData)
      .pipe(
        map((result) => {
          return result;
        })
      );
  }
  getAnnouncementDashBoard(userId: string): Observable<Array<IAnnouncementHome>> {
    let reqBody = {
      userId: userId,
      searchText:''
    }
    return this.http
      .post<ApiResponse<Array<IAnnouncementHome>>>(ApiEndPoints.get_AnnouncementDashboard, reqBody)
      .pipe(
        map((ans) => {
          return ans.result;
        })
      );
  }
  deleteAnnouncement(id: string): Observable<any> {
    let url = ApiEndPoints.post_DeleteAnnouncement + id;
    const reqHeader = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http
      .post<any>(url, "", { headers: reqHeader })
      .pipe(
        map((result) => {
          return result;
        })
      );
  }
  editAnnouncement(announcementInfo: any, ownersTo:any,assignToIds:any): Observable<any> {
    var formData = new FormData();

    for (let key in announcementInfo) {
      if (announcementInfo.hasOwnProperty(key)) {
        formData.append(key, announcementInfo[key]);
      }
    }
    for (let i = 0; i < ownersTo.length; i++) {
      const user = ownersTo[i];
      formData.append(`ownersIds[${i}].UserId`, user);
    }

    for (let i = 0; i < assignToIds.length; i++) {
      const user = assignToIds[i];
      formData.append(`assignTo[${i}].UserId`, user);
    }
    return this.http
      .post<ApiResponse<any>>(ApiEndPoints.post_EditAnnouncement, formData)
      .pipe(
        map((result) => {
          return result;
        })
      );
  }
  deleteAnnouncememtDocs(documentIds: any): Observable<Array<IAnnouncementHome>> {
    let reqBody = {
      documentIds: documentIds
    }
    return this.http
      .post<ApiResponse<Array<IAnnouncementHome>>>(ApiEndPoints.post_DeleteAnnouncementDocs, reqBody)
      .pipe(
        map((ans) => {
          return ans.result;
        })
      );
  }
  getAnnouncementDocuments(id:string): Observable<Array<any>> {
    return this.http
      .get<ApiResponse<Array<any>>>(ApiEndPoints.get_AnnouncementDocuments+id)
      .pipe(
        map((brands) => {
          return brands.result;
        })
      );
  }
  uploadAnnouncememtDocs(id: string, description: string, userId: string, files: File[]): Observable<Array<any>> {
    const formData: FormData = new FormData();

    // Append data object to FormData
    formData.append('id', id);
    formData.append('description', description);
    formData.append('userId', userId);

    // Append files to FormData
    files.forEach((file, index) => {
      formData.append('files', file, file.name);
    });
    return this.http
      .post<ApiResponse<Array<any>>>(ApiEndPoints.post_UploadAnnouncementDocs, formData)
      .pipe(
        map((ans) => {
          return ans.result;
        })
      );
  }
  downloadDocuments(id: string, fileName:string): Observable<any> {
    let url = ApiEndPoints.get_DownloadAnnouncementDocument + id + "&fileName=" + fileName;
    return this.http
      .get<any>(url)
      .pipe(
        map((result) => {
          return result;
        })
      );
  }
}
