import { Component } from '@angular/core';
import { ChildToParent } from './children/child-to-parent/child-to-parent';
import { ParentToChild } from './children/parent-to-child/parent-to-child';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-input-output',
  imports: [ChildToParent, ParentToChild, CommonModule, FormsModule],
  templateUrl: './input-output.html',
  styleUrl: './input-output.scss',
})
export class InputOutput {
  /// Parent To Child
  valueForPassDataToChild: string = '';
  counter: number = 0;
  userInfo: {
    name: string;
    family: string;
  } = {
    name: '',
    family: '',
  };
  addCounter() {
    this.counter += 1;
  }
  removeCounter() {
    this.counter -= 1;
  }
  /// Child To Parent
  description: string = '';
  readDescription(event: any) {
    console.log('Event : ', event);
    alert('This Not Working !!!');
    this.description = `${event} : This Value is Readed but event not access ...`;
  }
  readDescription1(desc: string) {
    this.description = desc;
  }
}
