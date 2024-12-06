import { Component, OnInit } from '@angular/core';
import { IUser } from '../../interfaces/models/IUser';
import { NgFor } from '@angular/common';
import { MatButton } from '@angular/material/button';
import { RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-user',
  imports: [NgFor, MatButton, RouterLink, RouterOutlet],
  templateUrl: './user.component.html',
  styleUrl: './user.component.css',
})
export class UserComponent implements OnInit {
  ngOnInit(): void {
    this.loadData();
  }
  dataList: IUser[] = [];

  loadData = () => {
    this.dataList = [
      {
        id: 1,
        name: 'User 1',
        family: 'Family 1',
        email: 'user1@mail.com',
        phone: '+1 5165 123 894',
        isActive: true,
      },
      {
        id: 2,
        name: 'User 2',
        family: 'Family 2',
        email: 'user2@mail.com',
        phone: '+1 5165 123 894',
        isActive: true,
      },
      {
        id: 3,
        name: 'User 3',
        family: 'Family 3',
        email: 'user3@mail.com',
        phone: '+1 5165 123 894',
        isActive: true,
      },
      {
        id: 4,
        name: 'User 4',
        family: 'Family 4',
        email: 'user4@mail.com',
        phone: '+1 5165 123 894',
        isActive: true,
      },
      {
        id: 5,
        name: 'User 5',
        family: 'Family 5',
        email: 'user5@mail.com',
        phone: '+1 5165 123 894',
        isActive: true,
      },
      {
        id: 6,
        name: 'User 6',
        family: 'Family 6',
        email: 'user6@mail.com',
        phone: '+1 5165 123 894',
        isActive: true,
      },
      {
        id: 7,
        name: 'User 7',
        family: 'Family 7',
        email: 'user7@mail.com',
        phone: '+1 5165 123 894',
        isActive: true,
      },
      {
        id: 8,
        name: 'User 8',
        family: 'Family 8',
        email: 'user8@mail.com',
        phone: '+1 5165 123 894',
        isActive: true,
      },
      {
        id: 9,
        name: 'User 9',
        family: 'Family 9',
        email: 'user9@mail.com',
        phone: '+1 5165 123 894',
        isActive: true,
      },
    ];
  };
}
