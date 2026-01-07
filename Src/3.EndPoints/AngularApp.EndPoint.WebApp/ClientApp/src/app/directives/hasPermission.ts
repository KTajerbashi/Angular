import { Directive, Input, TemplateRef, ViewContainerRef } from "@angular/core";

@Directive({
  selector: '[appHasPermission]',
  standalone: true
})
export class HasPermissionDirective {
  constructor(
    private tpl: TemplateRef<any>,
    private vcr: ViewContainerRef
  ) {}

  @Input() set appHasPermission(value: boolean) {
    this.vcr.clear();
    console.log('HasPermissionDirective value:', value);
    if (value) {
      this.vcr.createEmbeddedView(this.tpl);
    }
  }
}
