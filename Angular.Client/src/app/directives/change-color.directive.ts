import { Directive, ElementRef, HostListener, Renderer2 } from '@angular/core';

@Directive({
  selector: '[appRandomColor]',
})
export class RandomColorDirective {
  constructor(private el: ElementRef, private renderer: Renderer2) {}

  // Listen for keydown events on the host element
  @HostListener('keydown') onKeydown() {
    const randomColor = this.generateRandomColor();
    this.renderer.setStyle(
      this.el.nativeElement,
      'background-color',
      randomColor
    );
  }

  // Generate a random RGB color
  private generateRandomColor(): string {
    const r = Math.floor(Math.random() * 256);
    const g = Math.floor(Math.random() * 256);
    const b = Math.floor(Math.random() * 256);
    return `rgb(${r}, ${g}, ${b})`;
  }
}
