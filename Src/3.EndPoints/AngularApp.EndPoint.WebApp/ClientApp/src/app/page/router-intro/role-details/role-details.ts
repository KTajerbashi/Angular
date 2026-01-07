import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-role-details',
  imports: [],
  templateUrl: './role-details.html',
  styleUrl: './role-details.scss',
})
export class RoleDetails implements OnInit {
  routeValue: string | null = '';
  submenu: string | null = '';
  constructor(private route: ActivatedRoute) {}
  ngOnInit(): void {
    this.routeValue = this.route.snapshot.paramMap.get('id');
    this.submenu = this.route.snapshot.paramMap.get('submenu');
  }
}
