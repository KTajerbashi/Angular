import { Component, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { Shoes } from '../../../interfaces/models/IModels';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
} from '@angular/forms';
import { MatListModule, MatListOption } from '@angular/material/list';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-contorl-list',
  imports: [MatListModule, FormsModule, ReactiveFormsModule],
  templateUrl: './contorl-list.component.html',
  styleUrl: './contorl-list.component.css',
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class ContorlListComponent {
  form: FormGroup;
  shoes: Shoes[] = [
    { value: 'boots', name: 'Boots' },
    { value: 'clogs', name: 'Clogs' },
    { value: 'loafers', name: 'Loafers' },
    { value: 'moccasins', name: 'Moccasins' },
    { value: 'sneakers', name: 'Sneakers' },
  ];
  shoesControl = new FormControl();

  constructor() {
    this.form = new FormGroup({
      clothes: this.shoesControl,
    });
  }
}
