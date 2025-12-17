import { Component } from '@angular/core';
import { Child } from "./child/child";

@Component({
  selector: 'app-input-output',
  imports: [Child],
  templateUrl: './input-output.html',
  styleUrl: './input-output.scss',
})
export class InputOutput {
  childSource : string[] = ['Item 1', 'Item 2', 'Item 3'];
  addItem(){
    this.childSource.push('Item ' + (this.childSource.length + 1));
  }
}
