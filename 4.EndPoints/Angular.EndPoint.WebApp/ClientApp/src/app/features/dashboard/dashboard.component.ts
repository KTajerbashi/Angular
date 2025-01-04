import { Component } from '@angular/core';
import { TkCardComponent } from '../../shared/components/tk-card/tk-card.component';
import { MatGridListModule } from '@angular/material/grid-list';
@Component({
  selector: 'app-dashboard',
  imports: [TkCardComponent, MatGridListModule],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css',
})
export class DashboardComponent {}
