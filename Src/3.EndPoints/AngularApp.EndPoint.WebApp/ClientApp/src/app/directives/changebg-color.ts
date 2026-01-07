import { Directive, ElementRef, HostListener, Renderer2 } from '@angular/core';

@Directive({
  selector: '[appChangebgColor]'
})
export class ChangebgColorDirective {

  constructor(private el: ElementRef, private renderer: Renderer2) {
    // Set initial background color
    this.setBackground('#ffffff');
  }

  // Change background on typing
  @HostListener('input')
  onInput() {
    const randomColor = this.getRandomRgb();
    this.setBackground(randomColor);
  }

  // Optional: restore default color on blur if empty
  @HostListener('blur')
  onBlur() {
    const value = (this.el.nativeElement as HTMLInputElement | HTMLTextAreaElement).value;
    if (!value) {
      this.setBackground('#ffffff');
    }
  }

  // Apply the background color
  private setBackground(color: string) {
    this.renderer.setStyle(this.el.nativeElement, 'background-color', color);
    this.renderer.setStyle(this.el.nativeElement, 'transition', 'background-color 0.3s ease');
  }

  // Generate random RGB color
  private getRandomRgb(): string {
    const r = Math.floor(Math.random() * 256); // 0-255
    const g = Math.floor(Math.random() * 256);
    const b = Math.floor(Math.random() * 256);
    return `rgb(${r}, ${g}, ${b})`;
  }
}
