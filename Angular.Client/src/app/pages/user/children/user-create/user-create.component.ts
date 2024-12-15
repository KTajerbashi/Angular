import { AfterViewInit, Component } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import {
  MatCardModule,
  MatCard,
  MatCardContent,
  MatCardActions,
} from '@angular/material/card';
import {
  MatFormFieldModule,
  MatFormField,
  MatLabel,
} from '@angular/material/form-field';
import { MatInputModule, MatInput } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatOptionModule } from '@angular/material/core';
import { CommonModule } from '@angular/common';
import { IRole, IUser } from '../../../../interfaces/models/IModels';
import { ApiService } from '../../../../bases/services/api.service';
import { tap } from 'rxjs';
@Component({
  selector: 'app-user-create',
  standalone: true, // Mark this as a standalone component
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule,
    MatOptionModule,
  ],
  templateUrl: './user-create.component.html',
  styleUrls: ['./user-create.component.css'], // Corrected `styleUrl` to `styleUrls`
})
export class UserCreateComponent implements AfterViewInit {
  userForm: FormGroup;
  roles: IRole[] = [];
  constructor(private builder: FormBuilder, private apiservice: ApiService) {
    // Initialize the form inside the constructor
    this.userForm = this.builder.group({
      id: this.builder.control('', { validators: [] }),
      username: this.builder.control('', {
        validators: [Validators.required, Validators.minLength(5)],
      }),
      name: this.builder.control('', {
        validators: [Validators.required, Validators.minLength(5)],
      }),
      family: this.builder.control('', {
        validators: [Validators.required, Validators.minLength(5)],
      }),
      email: this.builder.control('', {
        validators: [Validators.required, Validators.email],
      }),
      password: this.builder.control('', {
        validators: [Validators.required, Validators.minLength(5)],
      }),
      phoneNumber: this.builder.control('', {
        validators: [Validators.required, Validators.minLength(5)],
      }),
      roleId: this.builder.control('', {
        // validators: [Validators.required],
      }),
      isActive: this.builder.control('', {
        // validators: [Validators.required],
      }),
    });
  }
  ngAfterViewInit(): void {
    this.loadRoles();
  }

  loadRoles = () => {
    this.apiservice.get<IRole[]>('Role').subscribe({
      next: (response) => {
        this.roles = response.data;
      },
      complete: () => {},
      error: (err) => {
        console.error(err);
      },
    });
  };
  onSubmit = () => {
    if (this.userForm.valid) {
      let _data: IUser = {
        id: this.userForm.value.id as number,
        username: this.userForm.value.username as string,
        name: this.userForm.value.name as string,
        family: this.userForm.value.family as string,
        email: this.userForm.value.email as string,
        password: this.userForm.value.password as string,
        phoneNumber: this.userForm.value.phoneNumber as string,
        roleId: this.userForm.value.roleId as number,
        isActive: this.userForm.value.isActive as boolean,
      };
      console.log('OnSubmit : ', _data);
      this.apiservice.post('User', _data).subscribe({
        next: (value) => console.log('Value : ', value), // Handle emitted values
        error: (err) => console.error('Error : ', err), // Handle errors
        complete: () => console.log('Observable completed!'), // Handle completion
      });
    }
  };
}
