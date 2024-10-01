import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DefaultUserPermissionComponent } from './default-user-permission.component';

describe('DefaultUserPermissionComponent', () => {
  let component: DefaultUserPermissionComponent;
  let fixture: ComponentFixture<DefaultUserPermissionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DefaultUserPermissionComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DefaultUserPermissionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
