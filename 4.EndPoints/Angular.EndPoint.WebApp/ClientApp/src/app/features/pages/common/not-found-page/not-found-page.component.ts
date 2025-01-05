import { Component } from '@angular/core';
import { TkCardComponent } from '../../../../shared/components/tk-card/tk-card.component';
import { TkCardContentComponent } from '../../../../shared/components/tk-card-content/tk-card-content.component';
import { MatButton } from '@angular/material/button';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-not-found-page',
  imports: [TkCardComponent, TkCardContentComponent, MatButton, RouterLink],
  templateUrl: './not-found-page.component.html',
  styleUrl: './not-found-page.component.css',
})
export class NotFoundPageComponent {}
