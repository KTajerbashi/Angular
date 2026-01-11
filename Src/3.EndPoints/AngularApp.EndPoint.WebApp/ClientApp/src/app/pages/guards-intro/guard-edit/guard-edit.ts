import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-guard-edit',
  imports: [],
  templateUrl: './guard-edit.html',
  styleUrl: './guard-edit.scss',
})
export class GuardEdit implements OnInit{
  editId : string | null = null;
  constructor(private route:ActivatedRoute) {}
  ngOnInit(): void {
    this.route.paramMap.subscribe((param) => {
      console.log('Guard Edit ID:', param.get('id'));
      this.editId = param.get('id');
    });
  }

}
