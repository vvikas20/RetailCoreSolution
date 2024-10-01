import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FeatureoneComponent } from './featureone.component';

describe('FeatureoneComponent', () => {
  let component: FeatureoneComponent;
  let fixture: ComponentFixture<FeatureoneComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FeatureoneComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FeatureoneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
