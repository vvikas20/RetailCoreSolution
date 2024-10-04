import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageRoleLevelsComponent } from './manage-role-levels.component';

describe('ManageRoleLevelsComponent', () => {
  let component: ManageRoleLevelsComponent;
  let fixture: ComponentFixture<ManageRoleLevelsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ManageRoleLevelsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ManageRoleLevelsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
