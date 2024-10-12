import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

import { IUserDTO } from '../../auth/login/login.component';

@Component({
  selector: 'app-user-modal',
  templateUrl: './user-modal.component.html',
  styleUrl: './user-modal.component.css',
})
export class UserModalComponent {
  constructor(
    public dialogRef: MatDialogRef<UserModalComponent>,
    @Inject(MAT_DIALOG_DATA) public user: IUserDTO
  ) {}
  // Optionally, you can create a method to open the modal programmatically
  onClose(): void {
    this.dialogRef.close();
  }
}
