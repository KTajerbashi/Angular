import { Component } from '@angular/core';
import { LoginService } from '../../service/login.service';

@Component({
  selector: 'app-header',
  imports: [],
  templateUrl: './header.html',
  styleUrl: './header.scss',
})
export class Header {
  /**
   *
   */
  constructor(private _loginService: LoginService) {}

  logout() {
    this._loginService.Singout();
  }
}
