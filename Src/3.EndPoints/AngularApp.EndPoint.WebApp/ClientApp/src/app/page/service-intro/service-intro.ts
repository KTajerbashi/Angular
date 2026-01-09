import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import ILoginDTO from '../../models/ILogin.dto';
import { LoginService } from '../../service/login.service';
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
  constructor(private _loginService:LoginService) {}
  _loginModel: ILoginDTO = {
    Username: 'admin123',
    Password: '@Admin',
    RememberMe: false,
  };

   _signModel: ISignUpDTO = {
     FirstName: '',
     LastName: '',
     Username: '',
     Email: '',
     Phone: '',
     Password: ''
   };


  handleLogin(container: any) {
    const { form } = container;
    const { value } = form;
    console.log('Form : ', form);
    console.log('Values : ', value);
    this._loginService.login(this._loginModel)
  }

  handleSignUp(container: any) {
    const { form } = container;
    const { value } = form;
    console.log('Form : ', form);
    console.log('Values : ', value);
    this._loginService.signUp(this._signModel)
  }
}
