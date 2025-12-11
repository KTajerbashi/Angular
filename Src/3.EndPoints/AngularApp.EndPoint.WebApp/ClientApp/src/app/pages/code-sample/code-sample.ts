import { CommonModule } from '@angular/common';
import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-code-sample',
  imports: [FormsModule, CommonModule],
  templateUrl: './code-sample.html',
  styleUrl: './code-sample.scss',
})
export class CodeSample {
  itemlist: string[] = [];
  message: string = 'Hello, Enterprise Angular!';
  protected readonly title = signal('ClientApp');
  show = () => {
    this.message = 'Message Changed!';
  };

  add = () => {
    //  Check not Duplicate
    if (this.itemlist.includes(this.message)){
      alert('Duplicate Item!');
      return;
    }
    this.itemlist = [...this.itemlist, this.message];
  };

  remove = (item: string) => {
    this.itemlist = this.itemlist.filter((i) => i !== item);
  };
}
