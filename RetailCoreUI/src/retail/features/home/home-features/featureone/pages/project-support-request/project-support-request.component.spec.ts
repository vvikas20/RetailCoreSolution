import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectSupportRequestComponent } from './project-support-request.component';

describe('ProjectSupportRequestComponent', () => {
  let component: ProjectSupportRequestComponent;
  let fixture: ComponentFixture<ProjectSupportRequestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProjectSupportRequestComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProjectSupportRequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
