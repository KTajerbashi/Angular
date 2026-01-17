import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-parent-to-child',
  imports: [CommonModule],
  templateUrl: './parent-to-child.html',
  styleUrl: './parent-to-child.scss',
})
export class ParentToChild {
  @Input('UserState') _userState: string = 'This is My Value';
  @Input('Counter') _counter: number = 0;
  @Input('UserInfo') _userInfo: {} = 0;
}
