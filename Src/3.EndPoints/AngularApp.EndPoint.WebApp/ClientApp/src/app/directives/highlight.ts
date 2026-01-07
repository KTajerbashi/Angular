import { Directive, effect, ElementRef, HostListener, Input, signal } from '@angular/core';

@Directive({
  selector: '[appHighlight]',
  standalone: true,
})
export class HighlightDirective {
  //// 1 ) One Time on Init Time Set Value Color
  // @Input() appHighlight = 'yellow';

  // constructor(private el: ElementRef) {}

  // ngOnInit() {
  //   this.el.nativeElement.style.backgroundColor = this.appHighlight;
  // }

  //// 2 ) Set Value Color On Each Change
  constructor(private el: ElementRef) {
    this.isHover.update((value) => {
      console.log('HighlightDirective isHover changed:', value);
      return value;
    });
    effect(() => {
      // this.el.nativeElement.style.backgroundColor = this.isHover() ? this.color() : '';
      this.el.nativeElement.style.backgroundColor = this.color();
    });
  }
  color = signal('');

  @Input()
  set appHighlight(color: string) {
    this.color.set(color);
    this.el.nativeElement.style.backgroundColor = color;
  }

  ////
  isHover = signal(false);
  @HostListener('mouseenter')
  onMouseEnter() {
    this.color.set('lightgray');
    this.isHover.set(true);
  }

  @HostListener('mouseleave')
  onMouseLeave() {
    this.color.set('skyblue');
    this.isHover.set(false);
  }

  private highlight(color: string) {
    this.el.nativeElement.style.backgroundColor = color;
  }
}
