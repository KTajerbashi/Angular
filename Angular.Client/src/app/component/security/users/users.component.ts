import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-users',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './users.component.html',
  styleUrl: './users.component.css',
})
export class UsersComponent {
  firstName: string = 'Kamran';
  lastName: string = 'Tajerbashi';
  isActive: boolean = true;
  currentDate: Date = new Date();
  toggleActive(): void {
    this.isActive = !this.isActive;
  }
}
