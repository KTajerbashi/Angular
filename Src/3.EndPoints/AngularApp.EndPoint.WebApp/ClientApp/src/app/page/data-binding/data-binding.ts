import { CommonModule } from '@angular/common';
import { Component, signal, WritableSignal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatRadioModule } from '@angular/material/radio';

@Component({
  selector: 'app-data-binding',
  imports: [
    CommonModule,
    FormsModule,
    MatCardModule,
    MatCheckboxModule,
    FormsModule,
    MatRadioModule,
  ],
  templateUrl: './data-binding.html',
  styleUrl: './data-binding.scss',
})
export class DataBinding {
  disableCheckbox = true;
  pB = signal(false);
  tB = signal(true);
  toggle(sig: WritableSignal<boolean>) {
    sig.update((v) => !v);
  }
  btn_name: string = 'Click Me';
  changeTitle() {
    this.btn_name = `Click Here : ${Math.random()}`;
  }
  updateTitle(event: any) {
    this.btn_name = `Click Here : ${event.target.value}`;
  }

  username: string = '';
  bio: string = '';
  age: number = 0;
  isActive: boolean = false;
}
