import { Component, ElementRef, inject, Input, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatDialog } from '@angular/material/dialog';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { ApiService } from '../../../services/api.service';
import bootstrap from 'bootstrap';
import { Renderer2 } from '@angular/core';
import { UserModalComponent } from '../../security/user-modal/user-modal.component';
import { DialogComponent } from '../../component/dialog/dialog.component';

export interface IUserDTO {
  id: number;
  name: string;
  family: string;
  phone: string;
  email: string;
}

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule, DialogComponent],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  constructor(private httpClient: HttpClient, private dialog: MatDialog) {}
  userForm: FormGroup = new FormGroup({});
  http = inject(HttpClient);
  baseService = inject(ApiService);
  render = inject(Renderer2);
  dataList: IUserDTO[] = [];
  newUser: boolean = false;

  ngOnInit(): void {
    console.log('Run ...');
    this.loadAllUser();
    // Define the form structure using FormGroup and FormControl
    this.userForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.minLength(2)]),
      family: new FormControl('', [Validators.required]),
      phone: new FormControl('', [
        Validators.required,
        Validators.pattern(/^\d{10}$/),
      ]), // Example pattern for 10-digit phone
      email: new FormControl('', [Validators.required, Validators.email]),
    });
  }

  openUserDialog(user: IUserDTO): void {
    const dialogRef = this.dialog.open(UserModalComponent, {
      data: user,
    });

    dialogRef.afterClosed().subscribe((result) => {
      console.log('Dialog closed');
    });
  }

  // Action Methods
  remove(model: IUserDTO): void {
    console.log('Remove => Model :', model);
    console.log('Edit => Model :', model);
    this.baseService.delete<Boolean>('User', model.id).subscribe({
      next: (response) => {
        this.loadAllUser();
      },
      error: (error) => {
        console.error(error);
      },
    });
  }
  //
  edit(model: IUserDTO): void {
    console.log('Edit => Model :', model);
    this.baseService.put<IUserDTO>('User', model).subscribe({
      next: (response) => {
        this.loadAllUser();
      },
      error: (error) => {
        console.error(error);
      },
    });
  }
  //
  read(model: IUserDTO): void {
    console.log('Read => Model :', model);
    this.baseService.get<IUserDTO>(`User/${model.id}`).subscribe({
      next: (response) => {
        this.loadAllUser();
      },
      error: (error) => {
        console.error(error);
      },
    });
  }
  // Fetch Users from API
  loadAllUser(): void {
    this.baseService.get<IUserDTO[]>('User/Read').subscribe({
      next: (response) => {
        if (response.success) {
          console.log('Data successfully fetched:', response.data);
          this.dataList = response.data; // Extract the `data` array from the response
        } else {
          console.error('Error: ', response.message);
        }
      },
      error: (error) => {
        console.error('Error fetching users:', error);
      },
    });
  }
  onSubmit(): void {
    if (this.userForm.valid) {
      const userDTO: IUserDTO = this.userForm.value;
      this.baseService.post<IUserDTO>('User', userDTO).subscribe({
        next: (response) => {
          if (response.success) {
            console.log('User created successfully:', response.data);
            this.loadAllUser();
          } else {
            console.error('User creation failed:', response.message);
          }
        },
        error: (error) => {
          console.error('Error:', error);
        },
      });
    } else {
      console.error('Form is invalid');
    }
  }
}
