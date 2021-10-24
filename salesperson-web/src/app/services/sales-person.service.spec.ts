import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

import { SalesPerson } from '../interfaces/sales-person';
import { SalesPersonService } from './sales-person.service';
import { SalesPersonResponse } from '../interfaces/sales-person-response';

describe('SalesPersonService', () => {
  let httpTestingController: HttpTestingController;
  let service: SalesPersonService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule ]
    });

    // Inject the http service and test controller for each test
    service = TestBed.inject(SalesPersonService);
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should return expected sales people (HttpClient called once)', (done: DoneFn) => {
    const expected: SalesPerson[] = [
      {name: "1", isBusy: false, groups: ["A"]},
      {name: "2", isBusy: true, groups: ["A"]},
      {name: "3", isBusy: false, groups: ["B"]}
    ];

    service.getSalesPeople().subscribe(
      salesPeople => {
        expect(salesPeople).toEqual(expected, 'expected sales people');
        done();
      },
      done.fail
    );

    const req = httpTestingController.expectOne('https://localhost:44341/SalesPerson');

    expect(req.request.method).toEqual('GET');

    req.flush(expected);

    httpTestingController.verify();
  });

  it('should return expected sales person (HttpClient called once)', (done: DoneFn) => {
    const expected: SalesPersonResponse = {
      salesPersonFound: true,
      salesPerson: {name: "1", isBusy: true, groups: ["A"]}
    };

    service.assignSalesPerson(0, 0).subscribe(
      salesPerson => {
        expect(salesPerson).toEqual(expected, 'expected sales person');
        done();
      },
      done.fail
    );

    const req = httpTestingController.expectOne('https://localhost:44341/SalesPerson/AssignFree');

    expect(req.request.method).toEqual('POST');

    req.flush(expected);

    httpTestingController.verify();
  });
});
