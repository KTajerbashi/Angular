import { Component, signal } from '@angular/core';
import { Store } from '@ngrx/store';
import { loadProducts } from '../../store/product/product.action.store';
import { getProductList } from '../../store/product/product.selector.store';
import IProduct from '../../models/IProduct.dto';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-ngrx-intro',
  imports: [CommonModule],
  templateUrl: './ngrx-intro.html',
  styleUrl: './ngrx-intro.scss',
})
export class NgrxIntro {

  dataList = signal<IProduct[]>([]);

  constructor(private store: Store) {}

  productStore = {
    dispatch: () => {
      this.store.dispatch(loadProducts());
      this.store.select(getProductList).subscribe((item) => {
        this.dataList.update(x => item);
        console.log('Item : ', this.dataList());
      });
    },
  };
}
