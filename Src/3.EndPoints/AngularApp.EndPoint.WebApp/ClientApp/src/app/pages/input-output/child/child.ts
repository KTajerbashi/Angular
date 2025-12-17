import { JsonPipe } from '@angular/common';
import { Component, EventEmitter, Input, Output, SimpleChanges } from '@angular/core';
import IUser from '../../../interfaces/IUser.dto';

@Component({
  selector: 'app-child',
  imports: [JsonPipe],
  templateUrl: './child.html',
  styleUrl: './child.scss',
})
export class Child {
  @Input('parameter') childInputProperty: string = '';
  @Input('datasource') childDataSource: string[] = [];
  @Input({ required: true }) childName: string = '';

  users : IUser[] = [
    { id: 1, name: 'John Doe', email: 'John@mail.com' },
    { id: 2, name: 'Jane Smith', email: 'Jane@mail.com' },
    { id: 3, name: 'Alice Johnson', email: 'Alice@mail.com' },
  ]

  private _user!: IUser;

  loadAvatar(id: number) {
    console.log('Id : ', id);
  }

  @Input()
  set user(value: IUser) {
    this._user = value;
    this.loadAvatar(value.id);
  }

  get user() {
    return this._user;
  }

  @Input() __user!: IUser;
  @Input() isAdmin = false;

  ngOnChanges(changes: SimpleChanges) {
    if (changes['user']) {
      console.log('User changed');
    }
  }

  /// Output EventEmitter example (not used in this snippet)
  @Output() saveClicked = new EventEmitter<void>();

  onSaveClick() {
    this.saveClicked.emit();
  }

  @Output() userSelected = new EventEmitter<IUser>();

  select(user: IUser) {
    console.log('Selected User : ', user);
    this.userSelected.emit(user);
  }
}
