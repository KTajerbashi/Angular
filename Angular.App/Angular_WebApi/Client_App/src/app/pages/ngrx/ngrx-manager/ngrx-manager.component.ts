import { CommonModule, NgFor, NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { MatButton } from '@angular/material/button';

@Component({
  selector: 'app-ngrx-manager',
  imports: [MatButton, NgIf, NgFor, CommonModule],
  templateUrl: './ngrx-manager.component.html',
  styleUrl: './ngrx-manager.component.css',
})
export class NgrxManagerComponent {
  config: IOption[] = [
    { visible: true, code: 1, title: 'State' },
    { visible: true, code: 2, title: 'Action' },
    { visible: true, code: 3, title: 'Effect' },
    { visible: true, code: 4, title: 'Reducer' },
    { visible: true, code: 5, title: 'Product' },
  ];

  toggle = (option: IOption) => {
    option.visible = !option.visible;
  };

  getOptionByCode = (code: number): boolean => {
    return this.config.find((item) => item.code === code)?.visible ?? false;
  };
}

interface IOption {
  visible: boolean;
  code: number;
  title: string;
}
