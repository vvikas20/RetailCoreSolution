import { TestBed } from '@angular/core/testing';

import { UserRoleMappingService } from './user-role-mapping.service';

describe('UserRoleMappingService', () => {
  let service: UserRoleMappingService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UserRoleMappingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
