import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EntrepreneurListComponent } from './entrepreneur-list.component';

describe('EntrepreneurListComponent', () => {
  let component: EntrepreneurListComponent;
  let fixture: ComponentFixture<EntrepreneurListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EntrepreneurListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EntrepreneurListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
