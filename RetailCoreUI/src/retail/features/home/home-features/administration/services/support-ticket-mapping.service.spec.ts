import { TestBed } from '@angular/core/testing';

import { SupportTicketMappingService } from './support-ticket-mapping.service';

describe('SupportTicketMappingService', () => {
  let service: SupportTicketMappingService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SupportTicketMappingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
