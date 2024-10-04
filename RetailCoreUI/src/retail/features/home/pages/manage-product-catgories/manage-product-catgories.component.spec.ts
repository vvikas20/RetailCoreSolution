import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageProductCatgoriesComponent } from './manage-product-catgories.component';

describe('ManageProductCatgoriesComponent', () => {
  let component: ManageProductCatgoriesComponent;
  let fixture: ComponentFixture<ManageProductCatgoriesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ManageProductCatgoriesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ManageProductCatgoriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
