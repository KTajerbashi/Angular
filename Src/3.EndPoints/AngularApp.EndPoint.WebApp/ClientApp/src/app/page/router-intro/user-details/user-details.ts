import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-user-details',
  imports: [],
  templateUrl: './user-details.html',
  styleUrl: './user-details.scss',
})
export class UserDetails {
  data: string = '';
  constructor(private route: ActivatedRoute) {
    this.route.paramMap.subscribe(param =>{
      console.log("Pa",param.get('id'));
    })
  }
}
