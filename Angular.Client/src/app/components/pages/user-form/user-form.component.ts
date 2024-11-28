import { Component, EventEmitter, Input, Output } from '@angular/core';
import { IAccountProfile } from '../../../interfaces/IAccountProfile';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'; // Import FormsModule

@Component({
  selector: 'app-user-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './user-form.component.html',
  styleUrl: './user-form.component.css',
})
export class UserFormComponent {
  datasource: IAccountProfile[] = [];
  userModel: IAccountProfile = {
    id: 0,
    name: '',
    family: '',
    email: '',
    password: '',
  };

  @Output() onPassModelEvent = new EventEmitter<IAccountProfile[]>();
  @Input() onRemoveEvent = new EventEmitter<number>();
  @Input() onEditEvent = new EventEmitter<number>();

  onSubmitForm = (e: Event) => {
    e.preventDefault();
    this.datasource.push(this.getModel());
    this.onPassModelEvent.emit(this.datasource);
  };
  onRemoveItem = (id: number) => {
    console.log('Form Remove : ', id);
    this.datasource = this.datasource.filter((item) => item.id != id);
    // this.onPassModelEvent.emit(this.datasource);
  };
  onEditItem = (id: number) => {
    console.log('Form Edit : ', id);
    let record = this.datasource.find((item) => item.id == id);
    if (record) {
      this.userModel = record;
    } else {
      alert('یافت نشده است');
    }
  };

  getModel = (): IAccountProfile => {
    let model: IAccountProfile = {
      id: this.newId(),
      name: this.userModel.name,
      family: this.userModel.family,
      email: this.userModel.email,
      password: this.userModel.password,
    };
    this.userModel = this.getEmptyModel();
    return model;
  };
  getEmptyModel = (): IAccountProfile => {
    return {
      id: 0,
      name: '',
      family: '',
      email: '',
      password: '',
    };
  };

  newId = (): number => {
    return Math.floor(Math.random() * 1000);
  };
}
