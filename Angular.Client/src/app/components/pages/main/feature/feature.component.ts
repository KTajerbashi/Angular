import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-feature',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './feature.component.html',
  styleUrl: './feature.component.css',
})
export class FeatureComponent {
  username: string = '';
  password: string = '';
  confirmPass: string = '';
  age: number = 0;
  access: boolean = false;
  isAdmin: boolean = false;
  isLogin: boolean = false;
  isUser: boolean = false;

  onLogin = (): void => {
    this.isLogin = this.password === this.confirmPass;
  };
  onCheck = (): void => {
    this.access = this.password === this.confirmPass;
  };
  onIsAdmin = (): void => {
    this.isAdmin = this.password === this.confirmPass;
  };
  onIsUser = (): void => {
    this.isUser = this.password === this.confirmPass;
  };
  onClear = (): void => {
    this.username = '';
    this.password = '';
    this.confirmPass = '';
    this.age = 0;
  };
  onReadForm = (): void => {
    this.access = this.password === this.confirmPass;
  };
}
