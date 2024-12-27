import { NgIf } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatCheckboxModule } from '@angular/material/checkbox';
import {
  MAT_DIALOG_DATA,
  MatDialogModule,
  MatDialogRef,
} from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { ToastrService } from 'ngx-toastr';
import { Store } from '@ngrx/store';
import { IProductModel } from '../../../../_stores/product.model';

@Component({
  selector: 'app-new-product',
  imports: [
    MatButtonModule,
    MatCardModule,
    MatCheckboxModule,
    MatFormFieldModule,
    MatInputModule,
    MatDialogModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatIconModule,
    NgIf,
    ReactiveFormsModule,
  ],
  templateUrl: './new-product.component.html',
  styleUrl: './new-product.component.css',
})
export class NewProductComponent implements OnInit {
  productForm!: FormGroup;
  productList: IProductModel[] = [];
  isEditMode: boolean = false;
  _dialogdata: {
    id: number;
    title: string;
  } = {
    id: 0,
    title: '',
  };
  constructor(
    private formBuilder: FormBuilder,
    private dialogRef: MatDialogRef<NewProductComponent>,
    @Inject(MAT_DIALOG_DATA) public dialogData: { id: number },
    private toastr: ToastrService,
    private store: Store
  ) {}

  ngOnInit(): void {
    this.initializeForm();
    if (this.dialogData?.id) {
      this.isEditMode = true;
    }
  }

  private initializeForm(): void {
    this.productForm = this.formBuilder.group({
      id: [{ value: 0, disabled: true }],
      name: ['', Validators.required],
      description: ['', Validators.required],
      price: [1, [Validators.required, Validators.min(0)]],
      status: [true],
    });
  }
  saveProduct = () => {};

  closeDialog(): void {
    this.dialogRef.close();
  }
}
