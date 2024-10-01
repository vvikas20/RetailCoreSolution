import { TestBed } from '@angular/core/testing';

import { ProjectScheduleService } from './project-schedule.service';

describe('ProjectScheduleService', () => {
  let service: ProjectScheduleService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProjectScheduleService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
