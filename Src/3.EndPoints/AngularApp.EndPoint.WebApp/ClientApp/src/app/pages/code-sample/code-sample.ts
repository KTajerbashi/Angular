import { CommonModule } from '@angular/common';
import {
  Component,
  computed,
  effect,
  OnChanges,
  OnDestroy,
  OnInit,
  signal,
  SimpleChanges,
} from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MessageService } from '../../services/message.service';
import { DataService } from '../../services/data.service';
@Component({
  selector: 'app-code-sample',
  imports: [FormsModule, CommonModule],
  templateUrl: './code-sample.html',
  styleUrl: './code-sample.scss',
})
export class CodeSample {
  count = signal(0);

  double = computed(() => this.count() * 2);

  constructor() {
    effect(() => {
      console.log('Count changed:', this.count());
    });
  }

  inc() {
    this.count.update((c) => c + 1);
  }
}
