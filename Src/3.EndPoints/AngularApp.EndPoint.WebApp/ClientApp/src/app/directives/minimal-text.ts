import { Directive, ElementRef, Renderer2, Input, AfterViewInit, HostListener } from '@angular/core';

@Directive({
  selector: '[appMinimalText]'
})
export class MinimalTextDirective implements AfterViewInit {

  @Input() maxLength: number = 100; // Maximum characters to show before "Show more"
  private originalText: string = '';
  private isExpanded: boolean = false;
  private toggleBtn!: HTMLSpanElement;

  constructor(private el: ElementRef, private renderer: Renderer2) {}

  ngAfterViewInit(): void {
    // Store the original text
    this.originalText = this.el.nativeElement.innerText.trim();

    if (this.originalText.length > this.maxLength) {
      this.showTruncated();
    }
  }

  private showTruncated() {
    const truncatedText = this.originalText.slice(0, this.maxLength) + '... ';

    // Clear current content
    this.el.nativeElement.innerText = '';
    
    // Add truncated text
    const textNode = this.renderer.createText(truncatedText);
    this.renderer.appendChild(this.el.nativeElement, textNode);

    // Add "Show more" button
    this.toggleBtn = this.renderer.createElement('span');
    this.renderer.setStyle(this.toggleBtn, 'color', '#00000093');
    this.renderer.setStyle(this.toggleBtn, 'cursor', 'pointer');
    this.renderer.setStyle(this.toggleBtn, 'font-weight', 'bold');
    this.renderer.setStyle(this.toggleBtn, 'margin-left', '5px');
    this.renderer.setProperty(this.toggleBtn, 'innerText', 'Show more');
    this.renderer.appendChild(this.el.nativeElement, this.toggleBtn);

    // Listen for click
    this.renderer.listen(this.toggleBtn, 'click', () => this.toggleText());
  }

  private toggleText() {
    if (this.isExpanded) {
      // Collapse
      const truncatedText = this.originalText.slice(0, this.maxLength) + '... ';
      this.el.nativeElement.innerText = '';
      this.renderer.appendChild(this.el.nativeElement, this.renderer.createText(truncatedText));
      this.renderer.appendChild(this.el.nativeElement, this.toggleBtn);
      this.renderer.setProperty(this.toggleBtn, 'innerText', 'Show more');
    } else {
      // Expand
      this.el.nativeElement.innerText = this.originalText + ' ';
      this.renderer.appendChild(this.el.nativeElement, this.toggleBtn);
      this.renderer.setProperty(this.toggleBtn, 'innerText', 'Hide');
    }

    this.isExpanded = !this.isExpanded;
  }
}
