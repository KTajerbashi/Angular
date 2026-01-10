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
  formsValue: {
    TemplateDriven: boolean;
    Reactive: boolean;
    Validation: boolean;
    Custom: boolean;
    Dynamic: boolean;
    Complete: boolean;
  } = {
    TemplateDriven: true,
    Reactive: false,
    Validation: false,
    Custom: false,
    Dynamic: false,
    Complete: false,
  };

  // Template Driven Form
  templateModel: {
    name: string;
    family: string;
    phone: string;
    email: string;
    address: string;
    age: number;
    type: boolean;
  } = {
    name: '',
    family: '',
    phone: '',
    email: '',
    address: '',
    age: 0,
    type: false,
  };
  templateDrivenMessage: string = '';
  templateDrivenProcess(form: any) {
    console.log('Form : ', form);
    if (form.valid) {
      this.templateDrivenMessage = 'اطلاعات فرم تکمیل استو برای سرویس مورد نظر ارسال شده است ...';
    } else {
      this.templateDrivenMessage =
        'اطلاعات فرم تکمیل نیست و یا اشتباه است لطفا اطلاعات را مجدد بررسی کنید ...';
    }
    setTimeout(() => {
      this.templateDrivenMessage = '';
    }, 5000);
  }
  // Template Driven Form Finishid

  // #1 Template Driven Form Comment

  // _loginModel: ILoginDTO = {
  //   Username: 'admin123',
  //   Password: '@Admin',
  //   RememberMe: false,
  // };

  // loginSubmit(form: any) {
  //   if (form.valid) {
  //     console.log('Login Form : ', form);
  //     console.log('Model : ', this._loginModel);
  //   } else {
  //     alert('Form Not Valid !!!');
  //   }
  // }
  // #1 Finished

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
    email: new FormControl('', [Validators.required, Validators.email]),
    phone: new FormControl('', [Validators.required, Validators.minLength(10)]),
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
