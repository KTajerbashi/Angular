import { Component } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import {
  MatCard,
  MatCardActions,
  MatCardContent,
} from '@angular/material/card';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-user-create',
  standalone: true, // Mark this as a standalone component
  imports: [
    MatCard,
    MatCardContent,
    MatCardActions,
    MatButtonModule,
    ReactiveFormsModule, // Import ReactiveFormsModule for FormBuilder
  ],
  templateUrl: './user-create.component.html',
  styleUrls: ['./user-create.component.css'], // Corrected `styleUrl` to `styleUrls`
})
export class UserCreateComponent {
  userForm: FormGroup;

  constructor(private builder: FormBuilder) {
    // Initialize the form inside the constructor
    this.userForm = this.builder.group({
      username: this.builder.control('', {
        validators: [Validators.required, Validators.minLength(3)],
      }),
    });
  }
}
