import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModifyUserPermissionMappingComponent } from './modify-user-permission-mapping.component';

describe('ModifyUserPermissionMappingComponent', () => {
  let component: ModifyUserPermissionMappingComponent;
  let fixture: ComponentFixture<ModifyUserPermissionMappingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ModifyUserPermissionMappingComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ModifyUserPermissionMappingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
