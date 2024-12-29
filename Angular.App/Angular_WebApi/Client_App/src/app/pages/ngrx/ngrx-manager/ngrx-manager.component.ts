import { CommonModule, NgFor, NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { ProductsComponent } from '../products/products.component';
import { CardComponent } from '../../../components/card/card.component';
import { CardContentComponent } from '../../../components/card-content/card-content.component';

@Component({
  selector: 'app-ngrx-manager',
  imports: [
    MatButton,
    NgIf,
    NgFor,
    CommonModule,
    ProductsComponent,
    CardComponent,
    CardContentComponent,
  ],
  templateUrl: './ngrx-manager.component.html',
  styleUrl: './ngrx-manager.component.css',
})
export class NgrxManagerComponent {
  config: IOption[] = [
    { visible: true, code: 1, title: 'NgContent' },
    { visible: false, code: 2, title: 'Action' },
    { visible: false, code: 3, title: 'Effect' },
    { visible: false, code: 4, title: 'Reducer' },
    { visible: false, code: 5, title: 'Product' },
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
