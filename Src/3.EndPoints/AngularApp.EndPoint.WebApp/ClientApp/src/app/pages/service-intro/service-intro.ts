import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import ILoginDTO from '../../models/ILogin.dto';
import { AccountService } from '../../services/account.service';
import ISignUpDTO from '../../models/ISignUp.dto';

@Component({
  selector: 'app-service-intro',
  imports: [FormsModule, CommonModule],
  templateUrl: './service-intro.html',
  styleUrl: './service-intro.scss',
})
export class ServiceIntro {
  /**
   *
   */
  constructor(private _accountService:AccountService) {}
  _loginModel: ILoginDTO = {
    Username: 'admin123',
    Password: '@Admin',
    RememberMe: false,
  };

   _signModel: ISignUpDTO = {
     firstName: '',
     lastName: '',
     username: '',
     email: '',
     phone: '',
     password: ''
   };


  handleLogin(container: any) {
    const { form } = container;
    const { value } = form;
    console.log('Form : ', form);
    console.log('Values : ', value);
    this._accountService.login(this._loginModel)
  }

  handleSignUp(container: any) {
    const { form } = container;
    const { value } = form;
    console.log('Form : ', form);
    console.log('Values : ', value);
    this._accountService.signUp(this._signModel)
  }
}
