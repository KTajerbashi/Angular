import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerToggle } from '@angular/material/datepicker';
import {
  MomentDateAdapter,
  MAT_MOMENT_DATE_ADAPTER_OPTIONS,
} from '@angular/material-moment-adapter';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import moment from 'moment-jalaali';

// فرمت تاریخ شمسی
export const PERSIAN_DATETIME_FORMATS = {
  parse: { dateInput: 'jYYYY/jMM/jDD HH:mm' },
  display: {
    dateInput: 'jYYYY/jMM/jDD HH:mm',
    monthYearLabel: 'jMMMM jYYYY',
    dateA11yLabel: 'jYYYY/jMM/jDD HH:mm',
    monthYearA11yLabel: 'jMMMM jYYYY',
  },
};

@Component({
  selector: 'app-persian-datepicker',
  standalone: true,
  imports: [CommonModule, FormsModule, MatDatepickerModule, MatFormFieldModule, MatInputModule],
  templateUrl: './persian-datepicker.component.html',
  styleUrls: ['./persian-datepicker.component.scss'],
  providers: [
    { provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE, MAT_MOMENT_DATE_ADAPTER_OPTIONS] },
    { provide: MAT_DATE_FORMATS, useValue: PERSIAN_DATETIME_FORMATS },
    { provide: MAT_DATE_LOCALE, useValue: 'fa-IR' },
  ],
})
export class PersianDatepickerComponent {
  private _selectedDate: Date | null = null;

  // خروجی شمسی
  get selectedDate(): string {
    return this._selectedDate ? moment(this._selectedDate).format('jYYYY/jMM/jDD HH:mm') : '';
  }

  // ورودی شمسی یا Date
  set selectedDate(value: string | Date | null) {
    if (!value) {
      this._selectedDate = null;
    } else if (typeof value === 'string') {
      // تبدیل رشته شمسی به Date
      const m = moment(value, 'jYYYY/jMM/jDD HH:mm');
      this._selectedDate = m.isValid() ? m.toDate() : null;
    } else {
      this._selectedDate = value;
    }
  }

  // ساعت و دقیقه به صورت جداگانه
  hour = 0;
  minute = 0;

  updateTime() {
    if (this._selectedDate) {
      this._selectedDate.setHours(this.hour);
      this._selectedDate.setMinutes(this.minute);
    }
  }
}
