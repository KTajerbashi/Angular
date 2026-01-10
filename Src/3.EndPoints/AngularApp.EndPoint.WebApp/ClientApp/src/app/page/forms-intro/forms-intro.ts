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
import IRoleDTO from '../../models/IRole.dto';

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
  roles: IRoleDTO[] = [
    { Key: 'Admin', Name: 'Admin' },
    { Key: 'User', Name: 'User' },
    { Key: 'Customer', Name: 'Customer' },
    { Key: 'Client', Name: 'Client' },
  ];
  registerForm = new FormGroup({
    // firstName: new FormControl({ value: '', disabled: true }, Validators.required),
    firstName: new FormControl({ value: 'Kaihan', disabled: false }, Validators.required),
    lastName: new FormControl('', Validators.required),
    gender: new FormControl('female', Validators.required),
    username: new FormControl('', Validators.required),
    email: new FormControl('', [Validators.required,Validators.email]),
    phone: new FormControl('', [Validators.required,Validators.minLength(10)]),
    roleKey: new FormControl('User', Validators.required),
    isRoleDefault: new FormControl(true, [Validators.required]),
  });
  loginHandler() {
    console.log('Form : ', this.registerForm);
    if (this.registerForm.valid) {
      alert('Form Is Valid !!!');
    } else {
      console.log('Errors : ', this.registerForm.value);
    }
  }

  // Reactive Form Finishid


  // FormBuilder Form
  // FormBuilder Form Finishid
}
