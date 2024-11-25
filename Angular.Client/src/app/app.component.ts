import { Component } from '@angular/core';
import { RouterOutlet, Routes } from '@angular/router';
import { LoginComponent } from './layouts/auth-layout/login/login.component';
import { HeaderComponent } from './layouts/main-layout/header/header.component';
import { FooterComponent } from './layouts/main-layout/footer/footer.component';
import { NavbarComponent } from './layouts/main-layout/navbar/navbar.component';
import { MainLayoutComponent } from './layouts/main-layout/main/main.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    LoginComponent,
    HeaderComponent,
    NavbarComponent,
    MainLayoutComponent,
    FooterComponent,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'angular-Tajer';
}
