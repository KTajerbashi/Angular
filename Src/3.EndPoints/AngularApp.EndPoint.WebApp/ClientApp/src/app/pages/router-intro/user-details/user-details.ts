import { Component } from '@angular/core';
import { ActivatedRoute, RouterOutlet, RouterLinkWithHref } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-user-details',
  imports: [RouterOutlet, RouterLinkWithHref, FormsModule],
  templateUrl: './user-details.html',
  styleUrl: './user-details.scss',
})
export class UserDetails {
  userKey: string = '';
 
}
