import { Component } from '@angular/core';
import { RouterOutlet, RouterLinkWithHref, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-router-intro',
  imports: [RouterOutlet, RouterLinkWithHref],
  templateUrl: './router-intro.html',
  styleUrl: './router-intro.scss',
})
export class RouterIntro {
  data: string = '';
  constructor(private route: ActivatedRoute) {
    this.route.paramMap.subscribe((param) => {
      this.data = `${param.get('id')}`;
    });
  }
}
