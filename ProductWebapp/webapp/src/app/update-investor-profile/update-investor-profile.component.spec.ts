import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateInvestorProfileComponent } from './update-investor-profile.component';

describe('UpdateInvestorProfileComponent', () => {
  let component: UpdateInvestorProfileComponent;
  let fixture: ComponentFixture<UpdateInvestorProfileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateInvestorProfileComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateInvestorProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
