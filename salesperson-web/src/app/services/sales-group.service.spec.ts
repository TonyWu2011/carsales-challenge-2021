import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

import { SalesGroup } from '../interfaces/sales-group';
import { SalesGroupService } from './sales-group.service';

describe('SalesGroupService', () => {
  let httpTestingController: HttpTestingController;
  let service: SalesGroupService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule ]
    });

    // Inject the http service and test controller for each test
    service = TestBed.inject(SalesGroupService);
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should return expected sales groups (HttpClient called once)', (done: DoneFn) => {
    const expected: SalesGroup[] = [
      {name: "1"}, {name: "2"}, {name: "3"}
    ];

    service.getSalesGroups().subscribe(
      salesGroups => {
        expect(salesGroups).toEqual(expected, 'expected sales groups');
        done();
      },
      done.fail
    );

    const req = httpTestingController.expectOne('https://localhost:44341/SalesGroup');

    expect(req.request.method).toEqual('GET');

    req.flush(expected);

    httpTestingController.verify();
  });
});
