import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

import { SalesPersonComponent } from './sales-person.component';
import { SalesPersonService } from '../services/sales-person.service';

describe('SalesPersonComponent', () => {
  let httpTestingController: HttpTestingController;
  let service: SalesPersonService;
  let component: SalesPersonComponent;
  let fixture: ComponentFixture<SalesPersonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule ],
      declarations: [ SalesPersonComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    httpTestingController = TestBed.inject(HttpTestingController);
    service = TestBed.inject(SalesPersonService);
    fixture = TestBed.createComponent(SalesPersonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should render title', () => {
    const compiled = fixture.nativeElement;
    expect(compiled.querySelector('h2').textContent).toContain('Sales People');
  });
});
