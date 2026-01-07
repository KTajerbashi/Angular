import {
  Directive,
  ElementRef,
  HostListener,
  Input,
  Renderer2
} from '@angular/core';

@Directive({
  selector: 'app-copy-text'
})
export class CopyTextDirective {

  @Input() copyText: string | null = null;

  private originalContent: string | null = null;

  constructor(private el: ElementRef, private renderer: Renderer2) {
    // Add base styles
    this.renderer.setStyle(this.el.nativeElement, 'cursor', 'pointer');
    this.renderer.setStyle(this.el.nativeElement, 'position', 'relative');
    this.renderer.setStyle(this.el.nativeElement, 'transition', 'background 0.2s ease');
  }

  @HostListener('mouseenter')
  onMouseEnter() {
    this.renderer.setStyle(this.el.nativeElement, 'background', '#f5f5f5');
  }

  @HostListener('mouseleave')
  onMouseLeave() {
    this.renderer.setStyle(this.el.nativeElement, 'background', 'transparent');
  }

  @HostListener('click')
  onClick() {
    const element = this.el.nativeElement;
    const textToCopy = this.copyText || element.innerText.trim();

    navigator.clipboard.writeText(textToCopy)
      .then(() => {
        this.showCopiedFeedback();
      })
      .catch(err => console.error('Copy failed:', err));
  }

  private showCopiedFeedback() {
    const element = this.el.nativeElement;

    // Store original HTML
    if (!this.originalContent) {
      this.originalContent = element.innerHTML;
    }

    // Replace content with “Copied!”
    this.renderer.setProperty(element, 'innerHTML', '<span style="color: rgba(17, 105, 238, 1); font-weight: bold;">Copied!</span>');

    // Add green glow
    this.renderer.setStyle(element, 'background', '#d4f8d4');
    this.renderer.setStyle(element, 'border-radius', '4px');

    // Revert back after 1 second
    setTimeout(() => {
      this.renderer.setProperty(element, 'innerHTML', this.originalContent);
      this.renderer.setStyle(element, 'background', 'transparent');
    }, 1000);
  }
}
