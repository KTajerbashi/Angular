import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import ILoginDTO from '../../models/ILogin.dto';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-forms-intro',
  imports: [FormsModule, CommonModule],
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
    TemplateDriven: false,
    Reactive: false,
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
}
