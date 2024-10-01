import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserAccountApprovalComponent } from './user-account-approval.component';

describe('UserAccountApprovalComponent', () => {
  let component: UserAccountApprovalComponent;
  let fixture: ComponentFixture<UserAccountApprovalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UserAccountApprovalComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UserAccountApprovalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
