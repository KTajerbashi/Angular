import { Component } from '@angular/core';
import { RouterLinkWithHref, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-guards-intro',
  imports: [RouterOutlet,RouterLinkWithHref],
  templateUrl: './guards-intro.html',
  styleUrl: './guards-intro.scss',
})
export class GuardsIntro {

}
