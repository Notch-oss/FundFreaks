import { TestBed } from '@angular/core/testing';

import { EntDataService } from './ent-data.service';

describe('EntDataService', () => {
  let service: EntDataService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EntDataService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
