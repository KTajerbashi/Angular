import { Component, OnInit } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { IUser } from '../../../interfaces/models/IUser';
import { NgFor, NgIf } from '@angular/common';
import { MatButton } from '@angular/material/button';

@Component({
  selector: 'app-user',
  imports: [RouterOutlet, NgFor, NgIf, RouterLink, MatButton],
  templateUrl: './user.component.html',
  styleUrl: './user.component.css',
})
export class UserComponent implements OnInit {
  dataList: IUser[] = [];

  constructor() {}
  ngOnInit(): void {
    this.getData();
  }
  getData = () => {
    this.dataList = [
      {
        id: 1,
        name: 'Name 1',
        family: 'Family 1',
        email: 'name1@mail.com',
        phone: '+1 1111',
        isActive: true,
        isDeleted: false,
      },
      {
        id: 2,
        name: 'Name 2',
        family: 'Family 2',
        email: 'name2@mail.com',
        phone: '+1 1221',
        isActive: true,
        isDeleted: false,
      },
      {
        id: 3,
        name: 'Name 3',
        family: 'Family 3',
        email: 'name3@mail.com',
        phone: '+1 1331',
        isActive: true,
        isDeleted: false,
      },
      {
        id: 4,
        name: 'Name 4',
        family: 'Family 4',
        email: 'name4@mail.com',
        phone: '+1 1441',
        isActive: true,
        isDeleted: false,
      },
      {
        id: 5,
        name: 'Name 5',
        family: 'Family 5',
        email: 'name5@mail.com',
        phone: '+1 1551',
        isActive: true,
        isDeleted: false,
      },
      {
        id: 6,
        name: 'Name 6',
        family: 'Family 6',
        email: 'name6@mail.com',
        phone: '+1 1661',
        isActive: true,
        isDeleted: false,
      },
      {
        id: 7,
        name: 'Name 7',
        family: 'Family 7',
        email: 'name7@mail.com',
        phone: '+1 1771',
        isActive: true,
        isDeleted: false,
      },
      {
        id: 8,
        name: 'Name 8',
        family: 'Family 8',
        email: 'name8@mail.com',
        phone: '+1 1881',
        isActive: true,
        isDeleted: false,
      },
      {
        id: 9,
        name: 'Name 9',
        family: 'Family 9',
        email: 'name9@mail.com',
        phone: '+1 1991',
        isActive: true,
        isDeleted: false,
      },
    ];
  };

  onUpdate = (model: IUser) => {
    console.log('onUpdate : ', model);
  };
  onDelete = (model: IUser) => {
    console.log('onDelete : ', model);
  };
  onRead = (model: IUser) => {
    console.log('onRead : ', model);
  };

  onSetAdminAccess = () => {
    localStorage.setItem('access', 'true');
  };
  onRemoveAdminAccess = () => {
    localStorage.setItem('access', 'false');
  };
}
