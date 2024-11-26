import { Component, EventEmitter, Input, Output, output } from '@angular/core';
import { IAccountProfile } from '../../../interfaces/IAccountProfile';

@Component({
  selector: 'app-search-data',
  standalone: true,
  imports: [],
  templateUrl: './search-data.component.html',
  styleUrl: './search-data.component.css',
})
export class SearchDataComponent {
  @Input() count: number = 0;
  @Output() onPassModel = new EventEmitter<IAccountProfile>();
  submit = (
    name: string,
    family: string,
    email: string,
    password: string,
    event: Event
  ) => {
    event.preventDefault();
    let model: IAccountProfile = {
      id: 0,
      name: name,
      family: family,
      email: email,
      password: password,
    };
    this.onPassModel.emit(model);
  };
}
