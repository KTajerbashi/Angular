import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  imports: [],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss',
})
export class HeaderComponent {

  constructor(private router:Router){
    console.log("Header Initial")
  }

  onLogin(){
    this.router.navigateByUrl('auth/login')
  }
  onSingOut(){
    this.router.navigate(['auth','sign-up'])
  }
  onProfile(){
    this.router.navigateByUrl('auth/profile')
  }

}
