import { Component } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-panel',
  imports: [RouterOutlet, RouterLink, MatButton],
  templateUrl: './panel.component.html',
  styleUrl: './panel.component.css',
})
export class PanelComponent {}
