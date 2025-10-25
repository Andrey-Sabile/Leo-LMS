import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SimpleCalendarMonthComponent } from './simple-calendar-month.component';

describe('SimpleCalendarMonthComponent', () => {
  let component: SimpleCalendarMonthComponent;
  let fixture: ComponentFixture<SimpleCalendarMonthComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SimpleCalendarMonthComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SimpleCalendarMonthComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
