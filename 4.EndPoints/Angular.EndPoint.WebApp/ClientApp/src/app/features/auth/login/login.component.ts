import { Component } from '@angular/core';
import { TkCardComponent } from '../../../shared/components/tk-card/tk-card.component';
import { TkCardContentComponent } from '../../../shared/components/tk-card-content/tk-card-content.component';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButton, MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { Router } from '@angular/router';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MatIcon } from '@angular/material/icon';
import { NgIf } from '@angular/common';
import { AuthService } from '../../../core/services/auth.service';

@Component({
  selector: 'app-login',
  imports: [
    TkCardComponent,
    TkCardContentComponent,
    MatButton,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    ReactiveFormsModule,
    MatIcon,
    NgIf,
    MatCheckboxModule,
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  loginForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private authService: AuthService
  ) {
    this.loginForm = this.fb.group({
      username: ['admin', Validators.required],
      password: ['password', Validators.required],
      rememberMe: ['true'],
    });
  }

  onSubmit() {
    if (this.loginForm.valid) {
      console.log('Login successful!', this.loginForm.value);
      let username = this.loginForm.value['username'];
      let password = this.loginForm.value['password'];
      let rememberMe = this.loginForm.value['rememberMe'];
      // Add your login logic here
      if (this.authService.login(username, password)) {
        this.router.navigate(['/']);
      } else {
        alert('Login Faild Creaditional Not Correct !!!');
      }
    }
  }
}
