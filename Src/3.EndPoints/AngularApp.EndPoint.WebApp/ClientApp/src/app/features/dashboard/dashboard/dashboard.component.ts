import { Component } from '@angular/core';
import { PersianDatepickerComponent } from '../../../shared/components/persian-datepicker/persian-datepicker.component';
export const JALALI_FORMATS = {
  parse: {
    dateInput: 'jYYYY/jMM/jDD',
  },
  display: {
    dateInput: 'jYYYY/jMM/jDD',
    monthYearLabel: 'jYYYY jMMMM',
    dateA11yLabel: 'jYYYY/jMM/jDD',
    monthYearA11yLabel: 'jYYYY jMMMM',
  },
};

@Component({
  selector: 'component-dashboard',
  standalone: true,
  imports: [PersianDatepickerComponent],
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent {
  // dateControl = new FormControl();
  startTime1: string = '';
  startTime2: string = '';
  startTime3: string = '';
  startTime4: string = '';

  getValue($event: string, field: 'startTime1' | 'startTime2' | 'startTime3' | 'startTime4') {
    this[field] = $event; // اینجا مقدار اصلی آپدیت می‌شود
  }
}
