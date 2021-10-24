import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

import { SalesGroupComponent } from './sales-group.component';
import { SalesGroupService } from '../services/sales-group.service';

describe('SalesGroupComponent', () => {
  let httpTestingController: HttpTestingController;
  let service: SalesGroupService;
  let component: SalesGroupComponent;
  let fixture: ComponentFixture<SalesGroupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule ],
      declarations: [ SalesGroupComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    httpTestingController = TestBed.inject(HttpTestingController);
    service = TestBed.inject(SalesGroupService);
    fixture = TestBed.createComponent(SalesGroupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should render title', () => {
    const compiled = fixture.nativeElement;
    expect(compiled.querySelector('h2').textContent).toContain('Sales Groups');
  });
});
