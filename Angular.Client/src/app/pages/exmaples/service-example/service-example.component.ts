import { Component, OnInit, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgFor } from '@angular/common';
import { ApiService } from '../../../bases/services/api.service';
import { IRole, IUser } from '../../../interfaces/models/IUser';
import { MatButton } from '@angular/material/button';
import {
  MatCard,
  MatCardActions,
  MatCardContent,
} from '@angular/material/card';
import { MatFormField, MatInput, MatLabel } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { tap } from 'rxjs';
@Component({
  selector: 'app-service-example',
  imports: [
    MatCard,
    MatCardContent,
    MatButton,
    MatInput,
    MatLabel,
    MatFormField,
    FormsModule,
    MatCardActions,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    NgFor,
  ],
  templateUrl: './service-example.component.html',
  styleUrls: ['./service-example.component.css'],
})
export class ServiceExampleComponent implements OnInit {
  private apiService = inject(ApiService);

  users: IUser[] = [];
  roles: IRole[] = [
    { id: 1, name: 'Admin', title: 'Admin' },
    { id: 2, name: 'User', title: 'User' },
    { id: 3, name: 'VIP', title: 'VIP' },
  ];
  errorMessage = '';

  constructor() {}

  ngOnInit(): void {
    this.fetchUsers();
  }

  ////  Create User
  roleModel: IRole = {
    id: 0,
    name: '',
    title: '',
  };
  userModel: IUser = {
    id: 0,
    roleId: 0,
    name: '',
    family: '',
    email: '',
    phoneNumber: '',
    username: '',
    password: '',
    isActive: false,
  };

  onSubmite = () => {
    console.log('Data Model :', this.userModel);

    this.apiService
      .post('User', this.userModel)
      .pipe(tap(console.log))
      .subscribe((item) => {
        this.loadData();
        console.log(item);
      });
  };

  loadData = () => {
    this.fetchUsers();
  };

  /**
   * Fetches the user data from the API.
   */
  private fetchUsers(): void {
    this.apiService.get<IUser[]>('User').subscribe({
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
    console.log('Res : ', response);
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
