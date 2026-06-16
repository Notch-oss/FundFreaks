import { TestBed } from '@angular/core/testing';

import { InvestorlistService } from './investorlist.service';

describe('InvestorlistService', () => {
  let service: InvestorlistService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(InvestorlistService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
