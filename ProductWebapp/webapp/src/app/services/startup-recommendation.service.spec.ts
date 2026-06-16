import { TestBed } from '@angular/core/testing';

import { StartupRecommendationService } from './startup-recommendation.service';

describe('StartupRecommendationService', () => {
  let service: StartupRecommendationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StartupRecommendationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
