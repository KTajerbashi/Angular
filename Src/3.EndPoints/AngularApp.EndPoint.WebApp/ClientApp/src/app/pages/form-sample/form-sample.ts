import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';

@Component({
  selector: 'app-form-sample',
  imports: [FormsModule, ReactiveFormsModule, CommonModule],
  templateUrl: './form-sample.html',
  styleUrls: ['./form-sample.scss'],
})
export class FormSample {
  // ================================
  // 1️⃣ Template-Driven Form
  // ================================
  submit_TD(form: any) {
    console.log('Template-Driven Form Values:', form.value);
  }

  // ================================
  // 2️⃣ Reactive Form (Basic)
  // ================================
  registerForm = new FormGroup({
    name: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required, Validators.minLength(6)]),
  });

  submit_RA() {
    if (this.registerForm.valid) {
      console.log('Reactive Form Values:', this.registerForm.value);
    } else {
      console.log('Reactive Form is invalid');
    }
  }

  // ================================
  // 3️⃣ Enterprise-Style Reactive Form (Best Practices)
  // ================================
  form!: FormGroup;

  constructor(private fb: FormBuilder) {
    this.form = this.fb.group({
      name: ['', [Validators.required, noSpaceValidator]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
    });
  }

  submit() {
    console.log('Enterprise Form Values:', this.form.value);
    if (this.form.invalid) return;
    alert('Form Submitted Successfully');
    // Example: Call your authentication or API service
    // this.authService.login(this.form.value).subscribe(...)
  }
}

// ================================
// Custom Validator Function
// ================================
export function noSpaceValidator(control: FormControl) {
  return control.value?.includes(' ') ? { noSpace: true } : null;
}
