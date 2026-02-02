import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'component-sign-up',
  imports: [CommonModule, FormsModule, RouterLink],
  templateUrl: './sign-up.component.html',
  styleUrl: './sign-up.component.scss',
})
export class SignUpComponent {
  model = {
    firstName: '',
    lastName: '',
    displayName: '',
    userName: '',
    email: '',
    phoneNumber: '',
    password: '',
    confirmPassword: '',
  };

  signup() {
    if (this.model.password !== this.model.confirmPassword) {
      alert('Passwords do not match');
      return;
    }

    const payload = {
      firstName: this.model.firstName,
      lastName: this.model.lastName,
      displayName: this.model.displayName,
      userName: this.model.userName,
      email: this.model.email,
      phoneNumber: this.model.phoneNumber,
      password: this.model.password,
    };

    console.log('Signup payload:', payload);

    // TODO: AuthService.register(payload)
  }
}
