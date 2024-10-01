import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectScheduleComponent } from './project-schedule.component';

describe('ProjectScheduleComponent', () => {
  let component: ProjectScheduleComponent;
  let fixture: ComponentFixture<ProjectScheduleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProjectScheduleComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProjectScheduleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
