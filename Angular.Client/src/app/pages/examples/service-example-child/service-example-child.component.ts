import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButton } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import { MatIcon } from '@angular/material/icon';
import { MatFormField, MatInput, MatLabel } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
@Component({
  selector: 'app-service-example-child',
  imports: [
    MatListModule,
    MatDividerModule,
    MatButton,
    FormsModule,
    MatInput,
    MatFormField,
    MatLabel,
  ],
  templateUrl: './service-example-child.component.html',
  styleUrl: './service-example-child.component.css',
})
export class ServiceExampleChildComponent {
  @Input() parentPassValueForMe: string = 'Default Value';
  @Output() passDate = new EventEmitter<string>();

  passValueToParent: string = '';
  clickToPassOutput = () => {
    this.passDate.emit(this.passValueToParent);
  };
}
