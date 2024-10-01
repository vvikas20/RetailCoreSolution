import { TestBed } from '@angular/core/testing';
import { RetailComponent } from './retail.component';

describe('AppComponent', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RetailComponent],
    }).compileComponents();
  });

  it('should create the app', () => {
    const fixture = TestBed.createComponent(RetailComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });

  it(`should have the 'retail-core-ui' title`, () => {
    const fixture = TestBed.createComponent(RetailComponent);
    const app = fixture.componentInstance;
    expect(app.title).toEqual('retail-core-ui');
  });

  it('should render title', () => {
    const fixture = TestBed.createComponent(RetailComponent);
    fixture.detectChanges();
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('h1')?.textContent).toContain('Hello, retail-core-ui');
  });
});
