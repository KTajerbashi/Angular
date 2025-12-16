import { Component } from '@angular/core';

@Component({
  selector: 'app-template-ref-users',
  imports: [],
  templateUrl: './template-ref-users.html',
  styleUrl: './template-ref-users.scss',
})
export class TemplateRefUsers {
  showName(name: string) {
    alert(`Hello, ${name}!`);
  }
  submit(form: any) {
    console.log(form.value);
  }
  showDate(date: string) {
    console.log('Selected Date:', date);
  }
  convertDate(dateValue: string) {
    const date = new Date(dateValue);
    console.log('JS Date Object:', date);
  }
  checkDates(start: string, end: string) {
    if (!start || !end) {
      alert('Both dates are required');
      return;
    }

    if (new Date(start) > new Date(end)) {
      alert('Start date must be before end date');
    } else {
      alert('Valid date range');
    }
  }
  minDate: string = '2024-01-01';
  maxDate: string = '2025-12-31';

}
