import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-user-profile',
  imports: [],
  templateUrl: './user-profile.html',
  styleUrl: './user-profile.scss',
})
export class UserProfile {
data: string = '';
  constructor(private route: ActivatedRoute) {
    this.route.paramMap.subscribe((param) => {
      this.data = `${param.get('id')}`;
      console.log("Parameters : ",param);
    });
  }
}
