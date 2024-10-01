import { Injectable } from '@angular/core';
import { map, Observable, Subject, TimeoutError } from 'rxjs';
import { IUserType } from '../models/user-type.model';
import { ApiResponse } from '../models/api-response.model';
import { HttpService } from '../http/http.service';
import { ApiEndPoints } from '../../config/api-end-points';

@Injectable()
export class LayoutService {
  private toggleState : boolean = false;
  private toggleSubject: Subject<boolean> = new Subject<boolean>();
  public toggleObervable:Observable<boolean> = this.toggleSubject.asObservable();

  constructor() { }

  expandSidebar(){
    this.toggleSubject.next(true);
  }

  collapseSidebar(){
    this.toggleSubject.next(false);
  }

  toggleSidebar(){
    this.toggleState=!this.toggleState;
    this.toggleSubject.next(this.toggleState);
  }
  
}
