import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../../services/security/auth.service';
import {
  MatCard,
  MatCardContent,
  MatCardHeader,
  MatCardTitle,
} from '@angular/material/card';
import { NgIf } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { MatButton } from '@angular/material/button';

@Component({
  selector: 'app-signin',
  imports: [
    MatCardContent,
    ReactiveFormsModule,
    MatCard,
    MatFormFieldModule,
    NgIf,
    MatInput,
    MatButton,
  ],
  templateUrl: './signin.component.html',
  styleUrl: './signin.component.css',
})
export class SigninComponent implements OnInit {
  signinForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {
    this.signinForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  ngOnInit(): void {}

  onSubmit(): void {
    if (this.signinForm.valid) {
      const { username, password } = this.signinForm.value;
      // Here we are calling the login method from the AuthService
      if (username === 'admin' && password === 'admin123') {
        this.authService.login(username, password);
        this.router.navigate(['/dashboard']);
      } else {
        alert('Invalid credentials');
      }
    }
  }
}
