import { Component, OnInit } from '@angular/core';
import { RouterOutlet, RouterLinkWithHref, ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-router-intro',
  imports: [RouterOutlet, RouterLinkWithHref],
  templateUrl: './router-intro.html',
  styleUrl: './router-intro.scss',
})
export class RouterIntro implements OnInit {
  data: string = '';
  constructor(private route: ActivatedRoute, private router: Router) {}
  ngOnInit(): void {
    this.route.paramMap.subscribe((param) => {
      this.data = `${param.get('id')}`;
    });
  }

  redirect() {
    this.router.navigate([
      'users',
      {
        queryParams: {
          page: 1,
          size: 10,
        },
      },
    ]);
  }
}
