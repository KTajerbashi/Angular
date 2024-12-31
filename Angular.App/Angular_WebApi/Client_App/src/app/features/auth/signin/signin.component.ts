import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.scss'],
  imports: [CommonModule],
  standalone: true,
})
export class SigninComponent {
  signinForm: FormGroup;
  successMessage: string = '';
  errorMessage: string = '';

  constructor(private fb: FormBuilder, private router: Router) {
    this.signinForm = this.fb.group(
      {
        name: ['', [Validators.required, Validators.minLength(3)]],
        email: ['', [Validators.required, Validators.email]],
        password: ['', [Validators.required, Validators.minLength(6)]],
        confirmPassword: ['', [Validators.required]],
      },
      { validator: this.passwordsMatch }
    );
  }

  // Custom validator to check if password and confirm password match
  passwordsMatch(group: FormGroup): { [key: string]: boolean } | null {
    const password = group.get('password')?.value;
    const confirmPassword = group.get('confirmPassword')?.value;
    return password === confirmPassword ? null : { mismatch: true };
  }

  onSubmit(): void {
    if (this.signinForm.valid) {
      const formData = this.signinForm.value;
      // Simulating a successful registration
      console.log('User Data:', formData);

      // Show success message and redirect
      this.successMessage = 'Registration successful!';
      setTimeout(() => this.router.navigate(['/auth/login']), 3000);
    } else {
      this.errorMessage = 'Please correct the errors in the form.';
    }
  }

  // Convenience getter for easy access to form controls
  get f() {
    return this.signinForm.controls;
  }
}
