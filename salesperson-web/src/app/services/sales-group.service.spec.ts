import { TestBed } from '@angular/core/testing';

import { SalesGroupService } from './sales-group.service';

describe('SalesGroupService', () => {
  let service: SalesGroupService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SalesGroupService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
