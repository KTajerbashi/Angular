import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-template-intro',
  imports: [CommonModule],
  templateUrl: './template-intro.html',
  styleUrl: './template-intro.scss',
})
export class TemplateIntro {
  visiblity: {
    if: boolean;
    else: boolean;
    for: boolean;
    switch: boolean;
    deferable: boolean;
  } = {
    if: false,
    else: false,
    for: false,
    switch: false,
    deferable: true,
  };
  dateTimeNow: Date = new Date();
  isLoading: boolean = false;
  getValue(value: boolean) {
    return value ? 'Active' : 'Disactive';
  }
  players: string[] = ['Ronaldo', 'Messi', 'Benzema', 'Reza'];
  counter: number = 0;
  generateRandom() {
    this.counter = Math.round(Math.random() * 5);
  }
  AddUser() {
    this.players.push(`User : ${Math.round(Math.random() * 100)}`);
  }
  RemoveUser() {
    this.players.pop();
  }

  toggle() {
    this.counter = this.counter + 1;
    this.isLoading = !this.isLoading;
  }
}
