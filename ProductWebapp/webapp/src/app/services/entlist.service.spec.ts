import { TestBed } from '@angular/core/testing';

import { EntlistService } from './entlist.service';

describe('EntlistService', () => {
  let service: EntlistService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EntlistService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
