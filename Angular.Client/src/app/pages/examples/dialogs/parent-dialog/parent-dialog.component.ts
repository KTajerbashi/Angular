import { ChangeDetectionStrategy, Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';

@Component({
  selector: 'app-parent-dialog',
  imports: [MatDialogModule, MatButtonModule],
  templateUrl: './parent-dialog.component.html',
  styleUrl: './parent-dialog.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ParentDialogComponent {}
