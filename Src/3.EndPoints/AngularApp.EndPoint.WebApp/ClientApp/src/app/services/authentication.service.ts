import { Injectable } from '@angular/core';
import { BaseApiService } from './base-api.service';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import ILoginDTO from '../models/ILogin.dto';
import ISignUpDTO from '../models/ISignUp.dto';
import IApiJson from '../models/IApiJson.dto';
import IProfileDTO from '../models/IUserProfile.dto';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService extends BaseApiService {
  protected override endpoint = 'Authentication';

  login(model: ILoginDTO): Observable<IProfileDTO> {
    return this.post<ILoginDTO, IApiJson<IProfileDTO>>('Login', model).pipe(
      map((response) => response.data)
    );
  }

  signUp(model: ISignUpDTO): Observable<ISignUpDTO> {
    return this.post<ISignUpDTO, IApiJson<ISignUpDTO>>('SignUp', model).pipe(
      map((response) => response.data)
    );
  }

  signOut(): Observable<IApiJson<boolean>> {
    return this.get<IApiJson<boolean>>('Signout').pipe(
      map((response) => {
        const { message } = response;
        alert(message); // optional
        return response;
      })
    );
  }

  loadProfile(): Observable<IProfileDTO> {
    return this.get<IApiJson<IProfileDTO>>('Profile').pipe(
      map((response) => response.data)
    );
  }
}
