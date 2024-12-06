import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { HomeComponent } from '../home/home.component';
import { AboutComponent } from '../about/about.component';
import { CommonModule } from '@angular/common';
import { ReversPipe } from '../../../pipes/revers.pipe';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-example-test',
  imports: [
    MatCardModule,
    MatButtonModule,
    HomeComponent,
    AboutComponent,
    CommonModule,
    ReversPipe,
    FormsModule,
  ],
  templateUrl: './example-test.component.html',
  styleUrl: './example-test.component.css',
})
export class ExampleTestComponent {
  /// Pipes
  title: string = 'Angular Full Course';
  info: string = 'Angular Version 19';
  dateTime: Date = new Date();
  testWords: string[] = [
    'Kaihan',
    'Kairun',
    'sharif',
    'Javad',
    'mohammad',
    'Tajer',
  ];

  /// Property Binding
  isDisable = false;

  //  Event Binding
  eventBindingInput: string = '';
  changeKeyDown = (e: any) => {
    this.eventBindingInput = e.target.value;
  };

  //  Two Way Binding
  printValue: string = '';
}
