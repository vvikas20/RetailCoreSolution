import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ParentCompanyComponent } from './parent-company.component';

describe('ParentCompanyComponent', () => {
  let component: ParentCompanyComponent;
  let fixture: ComponentFixture<ParentCompanyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ParentCompanyComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ParentCompanyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
