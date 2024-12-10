import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { FooterComponent } from '../../components/common/footer/footer.component';
import { NavbarComponent } from '../../components/common/navbar/navbar.component';

@Component({
  selector: 'app-dashboard-layout',
  imports: [
    RouterOutlet,
    FooterComponent,
    NavbarComponent,
  ],
  templateUrl: './dashboard-layout.component.html',
  styleUrl: './dashboard-layout.component.css',
})
export class DashboardLayoutComponent implements OnInit {
  ngOnInit(): void {
  }
}
