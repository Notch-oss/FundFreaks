import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InvestorNavbarComponent } from './investor-navbar.component';

describe('InvestorNavbarComponent', () => {
  let component: InvestorNavbarComponent;
  let fixture: ComponentFixture<InvestorNavbarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InvestorNavbarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InvestorNavbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
