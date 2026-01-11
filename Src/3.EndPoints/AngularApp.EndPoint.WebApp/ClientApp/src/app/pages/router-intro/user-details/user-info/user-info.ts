import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-user-info',
  imports: [],
  templateUrl: './user-info.html',
  styleUrl: './user-info.scss',
})
export class UserInfo {
  data: string = '';
  routeValue: string | null = '';
  constructor(private route: ActivatedRoute) {
    this.route.paramMap.subscribe((param) => {
      this.data = `${param.get('key')}`;
    });

    this.routeValue = this.route.snapshot.paramMap.get('key');
  }
}
