import { Component } from '@angular/core';
import { TkCardComponent } from '../../shared/components/tk-card/tk-card.component';
import { TkCardContentComponent } from '../../shared/components/tk-card-content/tk-card-content.component';
import { RouterOutlet } from '@angular/router';
import { MatGridListModule } from '@angular/material/grid-list';

@Component({
  selector: 'app-admin-layout',
  imports: [TkCardComponent, TkCardContentComponent, RouterOutlet,MatGridListModule],
  templateUrl: './admin-layout.component.html',
  styleUrl: './admin-layout.component.css',
})
export class AdminLayoutComponent {}
