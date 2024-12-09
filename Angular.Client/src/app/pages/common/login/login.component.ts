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
  standalone: true, // Standalone component
  imports: [
    MatCardModule,
    MatFormFieldModule,
    FormsModule,
    MatButton,
    MatButtonModule,
    MatInputModule,
    MatIconModule,
    NgIf,
  ],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'], // Fixed `styleUrl` to `styleUrls`
})
export class LoginComponent {
  username: string = '';
  password: string = '';

  constructor(private authService: AuthService, private router: Router) {}

  login() {
    if (this.username && this.password) {
      this.authService.login(this.username, this.password).subscribe(
        (isLoggedIn) => {
          console.log('Login : ', isLoggedIn);
          if (isLoggedIn) {
            console.log('Login successful');
            this.router.navigate(['/dashboard']); // Navigate to dashboard on success
          } else {
            alert('Invalid credentials');
          }
        },
        (error) => {
          console.error('Error during login:', error);
          alert('An error occurred. Please try again later.');
        }
      );
    } else {
      alert('Please enter valid credentials');
    }
  }

  navigateToSignup() {
    this.router.navigate(['/signin']);
  }
}
