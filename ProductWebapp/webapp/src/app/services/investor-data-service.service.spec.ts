import { TestBed } from '@angular/core/testing';

import { InvestorDataServiceService } from './investor-data-service.service';

describe('InvestorDataServiceService', () => {
  let service: InvestorDataServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(InvestorDataServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
