import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EntrepreneurProjectsComponent } from './entrepreneur-projects.component';

describe('EntrepreneurProjectsComponent', () => {
  let component: EntrepreneurProjectsComponent;
  let fixture: ComponentFixture<EntrepreneurProjectsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EntrepreneurProjectsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EntrepreneurProjectsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
