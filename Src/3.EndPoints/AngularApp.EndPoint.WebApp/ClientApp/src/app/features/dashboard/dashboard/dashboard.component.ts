import { Component } from '@angular/core';
import { PersianDatepickerComponent } from "../../../shared/components/persian-datepicker/persian-datepicker.component";

@Component({
  selector: 'component-dashboard',
  imports: [PersianDatepickerComponent],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss',
})
export class DashboardComponent {

}
