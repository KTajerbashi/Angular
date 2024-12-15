import { NgFor } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { IUser } from '../../../../interfaces/models/IModels';

@Component({
  selector: 'app-user-data-grid',
  imports: [RouterLink, NgFor],
  templateUrl: './user-data-grid.component.html',
  styleUrl: './user-data-grid.component.css',
})
export class UserDataGridComponent implements OnInit {
  dataList: IUser[] = [];
  ngOnInit(): void {
    this.loadData();
  }

  loadData = () => {
    this.dataList = [
      {
        id: 1,
        name: 'User 1',
        family: 'Family 1',
        email: 'user1@mail.com',
        phoneNumber: '+1 5165 123 894',
        isActive: true,
      },
      {
        id: 2,
        name: 'User 2',
        family: 'Family 2',
        email: 'user2@mail.com',
        phoneNumber: '+1 5165 123 894',
        isActive: true,
      },
      {
        id: 3,
        name: 'User 3',
        family: 'Family 3',
        email: 'user3@mail.com',
        phoneNumber: '+1 5165 123 894',
        isActive: true,
      },
      {
        id: 4,
        name: 'User 4',
        family: 'Family 4',
        email: 'user4@mail.com',
        phoneNumber: '+1 5165 123 894',
        isActive: true,
      },
      {
        id: 5,
        name: 'User 5',
        family: 'Family 5',
        email: 'user5@mail.com',
        phoneNumber: '+1 5165 123 894',
        isActive: true,
      },
      {
        id: 6,
        name: 'User 6',
        family: 'Family 6',
        email: 'user6@mail.com',
        phoneNumber: '+1 5165 123 894',
        isActive: true,
      },
      {
        id: 7,
        name: 'User 7',
        family: 'Family 7',
        email: 'user7@mail.com',
        phoneNumber: '+1 5165 123 894',
        isActive: true,
      },
      {
        id: 8,
        name: 'User 8',
        family: 'Family 8',
        email: 'user8@mail.com',
        phoneNumber: '+1 5165 123 894',
        isActive: true,
      },
      {
        id: 9,
        name: 'User 9',
        family: 'Family 9',
        email: 'user9@mail.com',
        phoneNumber: '+1 5165 123 894',
        isActive: true,
      },
    ];
  };
}
