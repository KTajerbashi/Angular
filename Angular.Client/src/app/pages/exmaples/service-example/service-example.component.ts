import { Component, OnInit, inject } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { NgFor } from '@angular/common';
import { ApiService } from '../../../bases/services/api.service';
import { IUser } from '../../../interfaces/models/IUser';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import {
  MatCard,
  MatCardActions,
  MatCardContent,
} from '@angular/material/card';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-service-example',
  imports: [
    MatCard,
    MatCardContent,
    MatButton,
    MatInput,
    MatLabel,
    NgFor,
    MatFormField,
    FormsModule,
    MatCardActions
  ],
  templateUrl: './service-example.component.html',
  styleUrls: ['./service-example.component.css'],
})
export class ServiceExampleComponent implements OnInit {
  private apiService = inject(ApiService);

  users: IUser[] = [];
  errorMessage = '';

  constructor() {}

  ngOnInit(): void {
    this.fetchUsers();
  }

  ////  Create User
  userModel: IUser = {
    id: 0,
    name: '',
    family: '',
    email: '',
    phone: '',
    username: '',
    password: '',
    isActive: false,
  };

  loadData = () => {
    this.fetchUsers();
  };

  /**
   * Fetches the user data from the API.
   */
  private fetchUsers(): void {
    this.apiService.get<IUser[]>('users').subscribe({
      next: (response: any) => this.handleSuccess(response),
      error: (error) => this.handleError(error),
    });
  }

  /**
   * Handles successful API responses.
   * @param response - The API response containing the users.
   */
  private handleSuccess(response: any): void {
    // Adjust logic based on actual API response structure
    this.users = response;
    if (response.success) {
      // If the data is directly in the response
      this.users = response.data;
    } else {
      this.errorMessage =
        response.message || 'An error occurred while fetching users.';
    }
  }

  /**
   * Handles errors from the API.
   * @param error - The error message.
   */
  private handleError(error: string): void {
    this.errorMessage = error;
  }
}
