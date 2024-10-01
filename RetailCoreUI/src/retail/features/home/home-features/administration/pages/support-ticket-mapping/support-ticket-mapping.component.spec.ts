import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SupportTicketMappingComponent } from './support-ticket-mapping.component';

describe('SupportTicketMappingComponent', () => {
  let component: SupportTicketMappingComponent;
  let fixture: ComponentFixture<SupportTicketMappingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SupportTicketMappingComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SupportTicketMappingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
