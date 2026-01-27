import { Injectable } from '@angular/core';
import { BaseApiService } from './base-api.service';
import { HttpClient } from '@angular/common/http';
import ILoginDTO from '../models/ILogin.dto';
import ISignUpDTO from '../models/ISignUp.dto';
import IApiJson from '../models/IApiJson.dto';

@Injectable({
  providedIn: 'root',
})
export class LoginService extends BaseApiService {
  protected override endpoint = 'Account';

  login(model: ILoginDTO): Object {
    return this.post<ILoginDTO, IApiJson<ILoginDTO>>('Login', model).subscribe((response) => {
      console.log('Response : ', response);
      return response;
    });
  }
  signUp(model: ISignUpDTO): Object {
    return this.post<ISignUpDTO,IApiJson<ISignUpDTO>>('SignUp', model).subscribe((response) => {
      console.log('Response : ', response);
      return response;
    });
  }
  Singout() {
    this.get('Signout').subscribe((response) => {
      const { message } = response as IApiJson<boolean>;
      console.log('Response : ', response);

      alert(message);
      return response;
    });
  }
}
