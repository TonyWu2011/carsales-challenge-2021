import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

import { StorageService } from './storage.service';

describe('StorageService', () => {
  let httpTestingController: HttpTestingController;
  let service: StorageService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule ]
    });

    service = TestBed.inject(StorageService);
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should run reset successfully (HttpClient called once)', (done: DoneFn) => {
    const expected = {};

    service.resetStorage().subscribe(
      () => {
        done();
      },
      done.fail
    );
    const req = httpTestingController.expectOne('https://localhost:44341/Storage');

    expect(req.request.method).toEqual('POST');

    req.flush(expected);

    httpTestingController.verify();
  });
});
