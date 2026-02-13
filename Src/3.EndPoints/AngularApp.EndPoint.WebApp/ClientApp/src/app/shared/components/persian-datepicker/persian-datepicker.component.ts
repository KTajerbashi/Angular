import { MatDatepickerInputEvent, MatDatepickerModule } from '@angular/material/datepicker';
import { Component, Input, input, Output, EventEmitter } from '@angular/core';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';

import { DateAdapter, MAT_DATE_FORMATS, MatNativeDateModule } from '@angular/material/core';
import { JalaliDateAdapter } from '../../../shared/components/persian-datepicker/jalali-date.adapter';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { Moment } from 'jalali-moment';
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
  selector: 'app-persian-datepicker',
  imports: [
    FormsModule,
    CommonModule,
    ReactiveFormsModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatInputModule,
    MatNativeDateModule,
  ],
  templateUrl: './persian-datepicker.component.html',
  styleUrl: './persian-datepicker.component.scss',
  providers: [
    { provide: DateAdapter, useClass: JalaliDateAdapter },
    { provide: MAT_DATE_FORMATS, useValue: JALALI_FORMATS },
  ],
})
export class PersianDatepickerComponent {
  @Input('lable') _label = 'تاریخ';
  // @Input('Model') _model: string = '';
  @Output('getValue') modelEvent = new EventEmitter<string>();
  selectedDate: string | null = null;
  dateControl = new FormControl();
  onDateChange(event: MatDatepickerInputEvent<Moment>) {
    if (event.value) {
      this.selectedDate = event.value.format('jYYYY/jMM/jDD');

      this.getValue(event.value.format('jYYYY/jMM/jDD'));
    }
  }

  getValue(value: string) {
    this.modelEvent.emit(value);
  }
}
