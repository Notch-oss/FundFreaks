import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EntrepreneurNavbarComponent } from './entrepreneur-navbar.component';

describe('EntrepreneurNavbarComponent', () => {
  let component: EntrepreneurNavbarComponent;
  let fixture: ComponentFixture<EntrepreneurNavbarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EntrepreneurNavbarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EntrepreneurNavbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
