import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StartupRecommendationComponent } from './startup-recommendation.component';

describe('StartupRecommendationComponent', () => {
  let component: StartupRecommendationComponent;
  let fixture: ComponentFixture<StartupRecommendationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StartupRecommendationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StartupRecommendationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
