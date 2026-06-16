import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DisplayInvestorDetailComponent } from './display-investor-detail.component';

describe('DisplayInvestorDetailComponent', () => {
  let component: DisplayInvestorDetailComponent;
  let fixture: ComponentFixture<DisplayInvestorDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DisplayInvestorDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DisplayInvestorDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
