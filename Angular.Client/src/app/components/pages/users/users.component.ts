import { Component, Output } from '@angular/core';
import { UserFormComponent } from '../user-form/user-form.component';
import { UserGridComponent } from '../user-grid/user-grid.component';
import { IAccountProfile } from '../../../interfaces/IAccountProfile';

@Component({
  selector: 'app-users',
  standalone: true,
  imports: [UserFormComponent, UserGridComponent],
  templateUrl: './users.component.html',
  styleUrl: './users.component.css',
})
export class UsersComponent {
  dataSource: IAccountProfile[] = [];
  @Output() id: number = 0;
  getFormData = (model: IAccountProfile[]) => {
    console.log('User Component : ', model);
    this.dataSource = model;
  };

  removeItem = (id: number) => {
    console.log('User Component removeItem: ', id);
    this.id = id;
  };
  editItem = (id: number) => {
    console.log('User Component editItem: ', id);
    this.id = id;
  };
}
