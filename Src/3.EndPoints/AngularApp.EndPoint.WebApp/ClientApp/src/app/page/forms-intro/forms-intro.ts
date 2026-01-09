import { Component } from '@angular/core';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import ILoginDTO from '../../models/ILogin.dto';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-forms-intro',
  imports: [ReactiveFormsModule, FormsModule, CommonModule],
  templateUrl: './forms-intro.html',
  styleUrl: './forms-intro.scss',
})
export class FormsIntro {
  // Template Driven Form
  formsValue: {
    TemplateDriven: boolean;
    Reactive: boolean;
    Validation: boolean;
    Custom: boolean;
    Dynamic: boolean;
    Complete: boolean;
  } = {
    TemplateDriven: false,
    Reactive: true,
    Validation: false,
    Custom: false,
    Dynamic: false,
    Complete: false,
  };

  _loginModel: ILoginDTO = {
    Username: 'admin123',
    Password: '@Admin',
    RememberMe: false,
  };

  loginSubmit(form: any) {
    if (form.valid) {
      console.log('Login Form : ', form);
      console.log('Model : ', this._loginModel);
    } else {
      alert('Form Not Valid !!!');
    }
  }
  // Template Driven Form Finishid

  // Reactive Form
  registerForm = new FormGroup({
    firstName: new FormControl('', Validators.required),
    lastName: new FormControl('', Validators.required),
    username: new FormControl('', Validators.required),
    email: new FormControl('', Validators.email),
    phone: new FormControl('', [Validators.minLength(10), Validators.maxLength(10)]),
  });
  loginHandler() {
    console.log('Form : ', this.registerForm);
  }

  // Reactive Form Finishid
}
