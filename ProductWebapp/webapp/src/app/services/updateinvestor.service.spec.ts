import { TestBed } from '@angular/core/testing';
import { UpdateinvestorService } from './updateinvestor.service';

describe('UpdateinvestorService', () => {
  let service: UpdateinvestorService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UpdateinvestorService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

