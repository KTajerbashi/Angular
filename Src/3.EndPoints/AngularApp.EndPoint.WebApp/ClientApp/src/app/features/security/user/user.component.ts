import { Component } from '@angular/core';
import { DataTableComponent } from "../../../shared/components/tables/data-table/data-table.component";

@Component({
  selector: 'component-user',
  imports: [DataTableComponent],
  templateUrl: './user.component.html',
  styleUrl: './user.component.scss',
})
export class UserComponent {
  tableConfig = {
    columns: [
      { name: 'userName', title: 'Username' },
      { name: 'email', title: 'Email' },
      { name: 'isActive', title: 'Active' },
    ],
    events: [
      { name: 'edit', label: 'Edit' },
      { name: 'delete', label: 'Delete' },
    ],
  };
}
