import { Component,HostListener  } from '@angular/core';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { TkCardComponent } from '../../../shared/components/tk-card/tk-card.component';
import { TkCardContentComponent } from '../../../shared/components/tk-card-content/tk-card-content.component';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import { Router, RouterLink } from '@angular/router';
import { MatMenuModule } from '@angular/material/menu';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-navbar',
  imports: [
    MatSlideToggleModule,
    TkCardComponent,
    TkCardContentComponent,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    RouterLink,
    MatMenuModule,
    NgIf
  ],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css',
})
export class NavbarComponent {
  constructor(private router: Router) {}

  logout(): void {
    localStorage.removeItem('authToken');
    this.router.navigate(['/login']);
  }
  isSmallScreen = false;

  @HostListener('window:resize', ['$event'])
  onResize() {
    this.isSmallScreen = window.innerWidth <= 768;
  }

  ngOnInit() {
    this.isSmallScreen = window.innerWidth <= 768;
  }

  toggleMenu() {
    // Logic to toggle the menu visibility
  }
}
