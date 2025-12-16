import { NgClass } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-template-syntax',
  imports: [NgClass],
  templateUrl: './template-syntax.html',
  styleUrl: './template-syntax.scss',
})
export class TemplateSyntax {
  isLoggedIn: boolean = false;
  role: string = 'guest';
  roles: string[] = ['guest', 'user', 'admin'];
  status: string = 'active';
  firstName: string = 'John';
  lastName: string = 'Doe';
  generateRandomNames(){
    const firstNames = ['John', 'Jane', 'Alice', 'Bob', 'Charlie', 'Diana'];
    const lastNames = ['Doe', 'Smith', 'Johnson', 'Brown', 'Davis', 'Miller'];
    const randomFirstName = firstNames[Math.floor(Math.random() * firstNames.length)];
    const randomLastName = lastNames[Math.floor(Math.random() * lastNames.length)];
    this.firstName = randomFirstName;
    this.lastName = randomLastName;
  }
  changeStatus() {
    // Toggle status between 'active' and 'inactive'
    this.status = this.status === 'active' ? 'inactive' : 'active';
  }
  users = [
    { id: 1, name: 'Ali' },
    { id: 2, name: 'Sara' },
  ];

  change(value: boolean) {
    this.isLoggedIn = !value;
    //  Random set role for demonstration
    const randomIndex = Math.floor(Math.random() * this.roles.length);
    this.role = this.roles[randomIndex];
  }
}
