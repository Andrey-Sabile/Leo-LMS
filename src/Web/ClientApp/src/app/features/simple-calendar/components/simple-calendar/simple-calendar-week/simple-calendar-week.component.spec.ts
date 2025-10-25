import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SimpleCalendarWeekComponent } from './simple-calendar-week.component';

describe('SimpleCalendarWeekComponent', () => {
  let component: SimpleCalendarWeekComponent;
  let fixture: ComponentFixture<SimpleCalendarWeekComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SimpleCalendarWeekComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SimpleCalendarWeekComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
