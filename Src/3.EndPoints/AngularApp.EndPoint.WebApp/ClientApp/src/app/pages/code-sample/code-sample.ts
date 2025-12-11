import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-code-sample',
  imports: [FormsModule],
  templateUrl: './code-sample.html',
  styleUrl: './code-sample.scss',
})
export class CodeSample {
  message: string = 'Hello, Enterprise Angular!';
  protected readonly title = signal('ClientApp');
  show = () => {
    this.message = 'Message Changed!';
  };
}
