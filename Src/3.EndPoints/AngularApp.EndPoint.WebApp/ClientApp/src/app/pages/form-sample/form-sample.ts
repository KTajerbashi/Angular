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
  styleUrl: './form-sample.scss',
})
export class FormSample {
  // Form Modult With Template-Driven Approach
  submit_TD(form: any) {
    console.log('Form Values:', form.value);
  }

  //  Form Modult With Reactive Approach
  registerForm = new FormGroup({
    name: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required, Validators.minLength(6)]),
  });
  submit_RA() {
    {
      if (this.registerForm.valid) {
        console.log('Reactive Form Values:', this.registerForm.value);
      } else {
        console.log('Reactive Form is invalid');
      }
    }
  }
  //  Reactive Form Best Practices (Enterprise) Form Sample
  form!: FormGroup;
  constructor(private fb: FormBuilder) {
    this.form = this.fb.group({
      name: ['', [Validators.required, noSpaceValidator]],
      email: ['', [Validators.required, noSpaceValidator]],
      // username: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  submit() {
    console.log("Submit : ",this.form);
    if (this.form.invalid) return;
    alert('Form Submitted Successfully');
    // this.authService.login(this.form.value).subscribe({
    //   next: (res) => console.log('Success', res),
    //   error: (err) => console.log('Error', err)
    // });
  }
}

export function noSpaceValidator(control: FormControl) {
  return control.value?.includes(' ') ? { noSpace: true } : null;
}
