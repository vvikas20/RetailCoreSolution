import { TestBed } from '@angular/core/testing';

import { UserAccountApprovalService } from './user-account-approval.service';

describe('UserAccountApprovalService', () => {
  let service: UserAccountApprovalService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UserAccountApprovalService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
