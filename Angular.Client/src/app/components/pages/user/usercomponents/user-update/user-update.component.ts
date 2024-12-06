import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-user-update',
  imports: [],
  templateUrl: './user-update.component.html',
  styleUrl: './user-update.component.css',
})
export class UserUpdateComponent {
  idPrams!: any;
  constructor(private route: ActivatedRoute) {}
  ngOnInit(): void {
    this.idPrams = this.route.snapshot.paramMap.get('id');
    console.log(this.idPrams);
  }
}
