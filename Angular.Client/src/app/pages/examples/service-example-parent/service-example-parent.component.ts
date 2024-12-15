import {
  ChangeDetectionStrategy,
  Component,
  inject,
  Output,
} from '@angular/core';
import { ServiceExampleChildComponent } from '../service-example-child/service-example-child.component';
import { MatButton, MatButtonModule } from '@angular/material/button';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatMenuModule } from '@angular/material/menu';
import { ParentDialogComponent } from '../dialogs/parent-dialog/parent-dialog.component';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatInput, MatInputModule } from '@angular/material/input';
import { SnakbarComponent } from '../dialogs/snakbar/snakbar.component';
import {
  MatSnackBar,
  MatSnackBarAction,
  MatSnackBarActions,
  MatSnackBarLabel,
  MatSnackBarRef,
} from '@angular/material/snack-bar';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-service-example-parent',
  imports: [
    ServiceExampleChildComponent,
    MatMenuModule,
    MatButton,
    MatDialogModule,
    MatGridListModule,
    MatFormFieldModule,
    FormsModule,
    MatInputModule,
    MatButtonModule,
    MatSnackBarAction,
    MatSnackBarActions,
    MatSnackBarLabel,
    NgIf,
  ],
  templateUrl: './service-example-parent.component.html',
  styleUrl: './service-example-parent.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ServiceExampleParentComponent {
  readonly dialog = inject(MatDialog);
  private _snackBar = inject(MatSnackBar);
  config = {
    child: false,
    dialog: false,
    snack: false,
    grid: false,
  };
  @Output() passToChild: string = '';

  openDialog() {
    const dialogRef = this.dialog.open(ParentDialogComponent);

    dialogRef.afterClosed().subscribe((result) => {
      console.log(`Dialog result: ${result}`);
    });
  }

  durationInSeconds = 5;

  openSnackBar() {
    this._snackBar.openFromComponent(SnakbarComponent, {
      duration: this.durationInSeconds * 1000,
    });
  }

  getEventDataFromChild = (value: string) => {
    this.passToChild = value;
    console.log('getEventDataFromChild : ', value);
  };

  childToggle = () => {
    this.config.child = !this.config.child;
  };
  dialogToggle = () => {
    this.config.dialog = !this.config.dialog;
  };
  snackToggle = () => {
    this.config.snack = !this.config.snack;
  };
  gridToggle = () => {
    this.config.grid = !this.config.grid;
  };
}
