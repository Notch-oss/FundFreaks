import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DisplayEntrepreneurDetailsComponent } from './display-entrepreneur-details.component';

describe('DisplayEntrepreneurDetailsComponent', () => {
  let component: DisplayEntrepreneurDetailsComponent;
  let fixture: ComponentFixture<DisplayEntrepreneurDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DisplayEntrepreneurDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DisplayEntrepreneurDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
