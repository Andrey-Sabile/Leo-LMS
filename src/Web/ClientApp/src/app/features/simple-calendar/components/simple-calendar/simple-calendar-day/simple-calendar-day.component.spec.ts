import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SimpleCalendarDayComponent } from './simple-calendar-day.component';

describe('SimpleCalendarDayComponent', () => {
  let component: SimpleCalendarDayComponent;
  let fixture: ComponentFixture<SimpleCalendarDayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SimpleCalendarDayComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SimpleCalendarDayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
