import { Component } from '@angular/core';

@Component({
  selector: 'app-fruits',
  imports: [],
  templateUrl: './fruits.html',
  styleUrl: './fruits.scss',
})
export class Fruits {
  fruits: string[] = ['Apple', 'Orange'];
  updateFruits(data: string[]) {
    this.fruits = [...this.fruits, ...data];
  }
  add(fruit: string): string {
    this.fruits.push(fruit);
    return 'Data Added ...';
  }
  remove(fruit: string) {
    this.fruits = this.fruits.filter((i) => i != fruit);
  }
}
