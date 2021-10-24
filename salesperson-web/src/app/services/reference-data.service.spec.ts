import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

import { ReferenceData } from '../interfaces/reference-data';
import { ReferenceDataService } from './reference-data.service';

describe('ReferenceDataService', () => {
  let httpTestingController: HttpTestingController;
  let service: ReferenceDataService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule ]
    });

    // Inject the http service and test controller for each test
    service = TestBed.inject(ReferenceDataService);
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should return expected reference data (HttpClient called once)', (done: DoneFn) => {
    const expected: ReferenceData = {
      carTypes : {0:"first", 1:"second"},
      languageOptions : {2:"third", 3:"fourth"}
    };

    service.getReferenceData().subscribe(
      data => {
        expect(data).toEqual(expected, 'expected reference data');
        done();
      },
      done.fail
    );

    const req = httpTestingController.expectOne('https://localhost:44341/ReferenceData');

    expect(req.request.method).toEqual('GET');

    req.flush(expected);

    httpTestingController.verify();
  });
});


