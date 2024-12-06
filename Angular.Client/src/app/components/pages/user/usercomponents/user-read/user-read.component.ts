import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-user-read',
  imports: [],
  templateUrl: './user-read.component.html',
  styleUrl: './user-read.component.css',
})
export class UserReadComponent {
  idPrams!: any;
  constructor(private route: ActivatedRoute) {}
  ngOnInit(): void {
    this.idPrams = this.route.snapshot.paramMap.get('id');
    console.log(this.idPrams);
  }
}
