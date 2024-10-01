import { TestBed } from '@angular/core/testing';

import { HttpRequestCounterService } from './http-request-counter.service';

describe('HttpRequestCounterService', () => {
  let service: HttpRequestCounterService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HttpRequestCounterService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
