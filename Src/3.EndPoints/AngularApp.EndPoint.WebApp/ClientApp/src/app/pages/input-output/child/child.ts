import { JsonPipe } from '@angular/common';
import { Component, Input, SimpleChanges } from '@angular/core';
interface User {
  id: number;
  name: string;
  email: string;
}
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

  private _user!: User;

  loadAvatar(id: number) {
    console.log('Id : ', id);
  }

  @Input()
  set user(value: User) {
    this._user = value;
    this.loadAvatar(value.id);
  }

  get user() {
    return this._user;
  }

  @Input() __user!: User;
  @Input() isAdmin = false;

  ngOnChanges(changes: SimpleChanges) {
    if (changes['user']) {
      console.log('User changed');
    }
  }
}
