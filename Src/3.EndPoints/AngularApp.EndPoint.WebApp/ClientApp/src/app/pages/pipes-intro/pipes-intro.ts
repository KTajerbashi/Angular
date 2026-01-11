import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { ReversePipe } from "../../pipes/reverse-pipe";
@Component({
  selector: 'app-pipes-intro',
  imports: [MatCardModule, MatButtonModule, CommonModule, ReversePipe],
  templateUrl: './pipes-intro.html',
  styleUrl: './pipes-intro.scss',
})
export class PipesIntro {
  title: string = 'Welcome to Pipes Introduction Page';
  subTitle: string =
    'Learn about Angular Pipes and how to use them effectively in your applications.';
  price: number = 1234.56;
  rating: number = 4.56789;
  salary: number = 450000;
  today: Date = new Date();
  _obj = {
    name: 'John Doe',
    age: 30,
    address: {
      street: '123 Main St',
      city: 'Anytown',
      country: 'USA',
    },
  };
}
