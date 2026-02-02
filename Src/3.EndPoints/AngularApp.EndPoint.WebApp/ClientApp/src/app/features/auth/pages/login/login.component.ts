import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'component-login',
  imports: [CommonModule, FormsModule, RouterLink],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent {
  model = {
    username: '',
    password: '',
    rememberMe: false,
  };

  login() {
    console.log('Login model:', this.model);
    // TODO: call AuthService.login()
  }

  loginWithGoogle() {
    console.log('Login with Google');
    // TODO: redirect to Google OAuth
  }

  loginWithGitHub() {
    console.log('Login with GitHub');
    // TODO: redirect to GitHub OAuth
  }

  loginWithSSO() {
    console.log('Login with SSO');
    // TODO: redirect to SSO endpoint
  }
}
