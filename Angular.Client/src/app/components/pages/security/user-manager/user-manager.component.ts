import { Component } from '@angular/core';
import { IUserModel } from '../../../../Models/generalModels';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-user-manager',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './user-manager.component.html',
  styleUrl: './user-manager.component.css',
})
export class UserManagerComponent {
  dataList: IUserModel[] = [];

  ngOnInit() {
    this.loadData();
  }

  loadData(): void {
    this.dataList = [
      {
        id: 1,
        name: 'Alex',
        family: 'Mahoon',
        email: 'User1@mail.com',
        nationalCode: '1231231231',
        phone: '09011001000',
      },
      {
        id: 2,
        name: 'Narvey',
        family: 'Xaan',
        email: 'User1@mail.com',
        nationalCode: '1231231231',
        phone: '09011001000',
      },
      {
        id: 3,
        name: 'Toshio',
        family: 'Ito',
        email: 'User1@mail.com',
        nationalCode: '1231231231',
        phone: '09011001000',
      },
      {
        id: 4,
        name: 'Alexander',
        family: 'Maches',
        email: 'User1@mail.com',
        nationalCode: '1231231231',
        phone: '09011001000',
      },
      {
        id: 5,
        name: 'Obama',
        family: 'jkdnvksndv',
        email: 'User1@mail.com',
        nationalCode: '1231231231',
        phone: '09011001000',
      },
      {
        id: 6,
        name: 'Trump',
        family: 'ldvlsdv',
        email: 'User1@mail.com',
        nationalCode: '1231231231',
        phone: '09011001000',
      },
      {
        id: 7,
        name: 'Donald',
        family: 'dknvslkdv',
        email: 'User1@mail.com',
        nationalCode: '1231231231',
        phone: '09011001000',
      },
      {
        id: 8,
        name: 'Maxi',
        family: 'dvskdvn',
        email: 'User1@mail.com',
        nationalCode: '1231231231',
        phone: '09011001000',
      },
    ];
  }

  showEditDialog = (model: IUserModel) => {
    console.log(model);
  };
  showDeleteDialog = (model: IUserModel) => {
    console.log(model);
  };
  showReadDialog = (model: IUserModel) => {
    console.log(model);
  };
}
