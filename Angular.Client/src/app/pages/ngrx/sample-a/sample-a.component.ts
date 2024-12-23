import {
  Component,
  inject,
  OnInit,
  ChangeDetectionStrategy,
} from '@angular/core';
import { IProductModel } from '../../../interfaces/store/IProductStateModel';
import { NgFor } from '@angular/common';
import { MatButton } from '@angular/material/button';
import { MatButtonModule } from '@angular/material/button';
import {
  MatDialog,
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogRef,
  MatDialogTitle,
} from '@angular/material/dialog';
import { CreateProductComponent } from './children/create-product/create-product.component';
@Component({
  selector: 'app-sample-a',
  imports: [NgFor, MatButton],
  templateUrl: './sample-a.component.html',
  styleUrl: './sample-a.component.css',
})
export class SampleAComponent implements OnInit {
  dataList: IProductModel[] = [
    {
      id: 1,
      title: 'Product Title',
      access: true,
      link: 'Product Link',
      order: 1,
    },
  ];
  readonly dialog = inject(MatDialog);

  ngOnInit(): void {
    console.log('SampleAComponent');
  }
  openDialog(
    enterAnimationDuration: string,
    exitAnimationDuration: string
  ): void {
    this.dialog.open(CreateProductComponent, {
      width: '1000px',
      enterAnimationDuration,
      exitAnimationDuration,
    });
  }
  onEdit = (item: IProductModel) => {
    console.log('onEdit : ', item);
  };
  onDelete = (item: IProductModel) => {
    console.log('onDelete : ', item);
  };
  onRead = (item: IProductModel) => {
    console.log('onRead : ', item);
  };
}
