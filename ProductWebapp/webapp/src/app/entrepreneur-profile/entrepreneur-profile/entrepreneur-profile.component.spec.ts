import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EntrepreneurProfileComponent } from './entrepreneur-profile.component';

describe('EntrepreneurProfileComponent', () => {
  let component: EntrepreneurProfileComponent;
  let fixture: ComponentFixture<EntrepreneurProfileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EntrepreneurProfileComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EntrepreneurProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
