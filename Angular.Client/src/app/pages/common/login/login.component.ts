import { Component } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { AuthService } from '../../../services/security/auth.service';
import { Router } from '@angular/router';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatButton, MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { NgFor, NgIf } from '@angular/common';

@Component({
  selector: 'app-login',
  imports: [
    MatCardModule,
    MatFormFieldModule,
    FormsModule,
    MatButton,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatButtonModule,
    MatIconModule,
    NgIf,
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  username: string = '';
  password: string = '';

  constructor(private authService: AuthService, private router: Router) {}

  login() {
    if (this.username && this.password) {
      // Perform authentication logic (mocked for now)
      this.authService.login(this.username);
      this.router.navigate(['/dashboard']);
    } else {
      alert('Please enter valid credentials');
    }
  }
  navigateToSignup() {
    this.router.navigate(['/signin']);
  }
}
