import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-user-delete',
  imports: [],
  templateUrl: './user-delete.component.html',
  styleUrl: './user-delete.component.css',
})
export class UserDeleteComponent implements OnInit {
  idPrams!: any;
  constructor(private route: ActivatedRoute) {}
  ngOnInit(): void {
    this.idPrams = this.route.snapshot.paramMap.get('id');
    console.log(this.idPrams);
  }
}
