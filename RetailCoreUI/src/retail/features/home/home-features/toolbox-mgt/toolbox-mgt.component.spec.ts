import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToolboxMgtComponent } from './toolbox-mgt.component';

describe('ToolboxMgtComponent', () => {
  let component: ToolboxMgtComponent;
  let fixture: ComponentFixture<ToolboxMgtComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ToolboxMgtComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ToolboxMgtComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
