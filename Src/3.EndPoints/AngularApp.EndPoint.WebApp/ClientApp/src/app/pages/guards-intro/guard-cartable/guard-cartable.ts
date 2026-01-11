import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-guard-cartable',
  imports: [],
  templateUrl: './guard-cartable.html',
  styleUrl: './guard-cartable.scss',
})
export class GuardCartable implements OnInit{
  submenu : string | null = null;
  key : string | null = null;
  constructor(private route:ActivatedRoute) {}
  ngOnInit(): void {
    this.route.paramMap.subscribe((param) => {
      this.submenu = param.get('submenu');
      this.key = param.get('key');
    });
  }

}