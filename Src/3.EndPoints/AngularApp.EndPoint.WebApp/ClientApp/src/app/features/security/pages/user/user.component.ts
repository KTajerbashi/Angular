import { Component } from '@angular/core';
import { DataTableComponent } from '../../../../shared/components/tables/data-table/data-table.component';
import {
  DataTableActionEvent,
  IDataTableConfig,
} from '../../../../shared/components/tables/data-table/IModel';

@Component({
  selector: 'component-user',
  imports: [DataTableComponent],
  templateUrl: './user.component.html',
  styleUrl: './user.component.scss',
})
export class UserComponent {
  tableConfig: IDataTableConfig = {
    columns: [
      { name: 'firstName', title: 'Name' },
      { name: 'lastName', title: 'Family' },
      { name: 'displayName', title: 'DisplayName' },
      { name: 'userName', title: 'UserName' },
      { name: 'phoneNumber', title: 'Phone' },
      { name: 'email', title: 'Email' },
      { name: 'isActive', title: 'Status' },
    ],
    events: [
      { name: 'edit', label: 'Edit', cssClass: 'app-btn app-btn-warning' },
      { name: 'delete', label: 'Delete', cssClass: 'app-btn app-btn-danger' },
    ],
  };
  handleAction(e: DataTableActionEvent) {
    if (e.event === 'edit') {
      console.log('Edit user', e.row);
    }

    if (e.event === 'delete') {
      console.log('Delete user', e.row);
    }

  }
}
