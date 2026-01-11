import {
  AfterContentChecked,
  AfterContentInit,
  AfterViewChecked,
  AfterViewInit,
  Component,
  DoCheck,
  OnChanges,
  OnDestroy,
  OnInit,
  SimpleChanges,
} from '@angular/core';

@Component({
  selector: 'app-hooks-intro',
  imports: [],
  templateUrl: './hooks-intro.html',
  styleUrl: './hooks-intro.scss',
})
export class HooksIntro
  implements
    OnChanges,
    OnInit,
    DoCheck,
    AfterContentInit,
    AfterContentChecked,
    AfterViewInit,
    AfterViewChecked,
    OnDestroy
{
  value: number = 0;
  handler() {
    this.value++;
  }
  ngOnChanges(changes: SimpleChanges): void {
    console.log(`1 : ngOnChanges :  ${this.value}`);
  }
  ngOnInit(): void {
    console.log(`2 : ngOnInit :  ${this.value}`);
  }
  ngDoCheck(): void {
    console.log(`3 : ngDoCheck :  ${this.value}`);
  }
  ngAfterContentInit(): void {
    console.log(`4 : ngAfterContentInit :  ${this.value}`);
  }
  ngAfterContentChecked(): void {
    console.log(`5 : ngAfterContentChecked :  ${this.value}`);
  }
  ngAfterViewInit(): void {
    console.log(`6 : ngAfterViewInit :  ${this.value}`);
  }
  ngAfterViewChecked(): void {
    console.log(`7 : ngAfterViewChecked :  ${this.value}`);
  }
  ngOnDestroy(): void {
    console.log(`8 : ngOnDestroy :  ${this.value}`);
  }
}
