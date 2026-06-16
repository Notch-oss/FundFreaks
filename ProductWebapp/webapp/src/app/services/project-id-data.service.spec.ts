import { TestBed } from '@angular/core/testing';

import { ProjectIdDataService } from './project-id-data.service';

describe('ProjectIdDataService', () => {
  let service: ProjectIdDataService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProjectIdDataService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
