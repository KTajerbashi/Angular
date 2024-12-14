import { Component, OnInit } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { AuthService } from '../../../services/security/auth.service';
import { Router } from '@angular/router';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatButton, MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { NgFor, NgIf } from '@angular/common';
import { ToastrService } from 'ngx-toastr';

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
export class LoginComponent implements OnInit {
  username: string = '';
  password: string = '';

  constructor(
    private authService: AuthService,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    localStorage.clear();
  }

  login() {
    if (this.username && this.password) {
      this.authService.login(this.username, this.password).subscribe({
        next: (res) => {
          const { data } = res;
          localStorage.setItem('token', JSON.stringify(data));
          this.router.navigate(['/dashboard']);
        },
        error: (err) => {
          console.log('login Error : ', err);
          this.toastr.error(err, 'Login Faild');
        },
      });
    } else {
      this.toastr.error('Please enter valid credentials', 'Faild');
    }
  }

  loginAs = () => {
    this.authService.login('Tajerbashi', '@Kaihan123').subscribe({
      next: (res) => {
        const { data } = res;
        localStorage.setItem('token', JSON.stringify(data));
        this.router.navigate(['/dashboard']);
      },
      error: (err) => {
        console.log('login Error : ', err);
        this.toastr.error(err, 'Login Faild');
      },
    });
  };

  navigateToSignup() {
    this.router.navigate(['/signin']);
  }
}
