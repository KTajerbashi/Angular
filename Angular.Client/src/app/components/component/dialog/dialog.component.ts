import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-dialog',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './dialog.component.html',
  styleUrl: './dialog.component.css',
})
export class DialogComponent {
  showDialog: boolean = false; // This variable controls the visibility

  toggleDialog() {
    this.showDialog = !this.showDialog;
  }
}
