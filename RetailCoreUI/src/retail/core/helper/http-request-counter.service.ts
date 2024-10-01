import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable()
export class HttpRequestCounterService {

  private activeRequests = 0;
  private activeRequestsSubject = new BehaviorSubject<number>(this.activeRequests);

  increment() {
    this.activeRequests++;
    this.activeRequestsSubject.next(this.activeRequests);
  }

  decrement() {
    if (this.activeRequests > 0) {
      this.activeRequests--;
      this.activeRequestsSubject.next(this.activeRequests);
    }
  }

  getActiveRequests() {
    return this.activeRequestsSubject.asObservable();
  }
}
