import { Component } from '@angular/core';
import { HeaderComponent } from './layouts/header/header.component';
import { FooterComponent } from './layouts/footer/footer.component';
import { NavbarComponent } from './layouts/navbar/navbar.component';
import { MainLayoutComponent } from './layouts/main/main.component';
import { SharedModule } from './modules/sharedModule';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    SharedModule,
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
