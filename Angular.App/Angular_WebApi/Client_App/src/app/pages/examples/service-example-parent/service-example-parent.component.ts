import {
  ChangeDetectionStrategy,
  Component,
  inject,
  OnInit,
  Output,
} from '@angular/core';
import { ServiceExampleChildComponent } from '../service-example-child/service-example-child.component';
import { MatButton, MatButtonModule } from '@angular/material/button';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatMenuModule } from '@angular/material/menu';
import { ParentDialogComponent } from '../dialogs/parent-dialog/parent-dialog.component';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInput, MatInputModule } from '@angular/material/input';
import { SnakbarComponent } from '../dialogs/snakbar/snakbar.component';
import { MatSnackBar } from '@angular/material/snack-bar';
import { NgIf } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SignalComponent } from '../signals/signal/signal.component';
import { DeferComponent } from '../defer/defer.component';
import { ContorlListComponent } from '../contorl-list/contorl-list.component';
import { ObservableComponent } from '../observable/observable.component';
import { SubjectTypesComponent } from "../subject-types/subject-types.component";

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
    NgIf,
    ReactiveFormsModule,
    ObservableComponent,
    SignalComponent,
    DeferComponent,
    ContorlListComponent,
    SubjectTypesComponent
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
    observable: false,
    signal: false,
    defer: false,
    radio: false,
    subject: true,
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
  observableToggle = () => {
    this.config.observable = !this.config.observable;
  };
  signalToggle = () => {
    this.config.signal = !this.config.signal;
  };
  radioToggle = () => {
    this.config.radio = !this.config.radio;
  };
  subjectsToggle = () => {
    this.config.subject = !this.config.subject;
  };
}
