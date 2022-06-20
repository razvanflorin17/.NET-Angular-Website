import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
  selector: '[appHover]'
})
export class HoverDirective {

  constructor(
    public el : ElementRef,
  ) { }

  @HostListener('mouseenter') onMouseEnter()
  {
    this.enlarge(1.05);
  }

  @HostListener('mouseleave') onMouseLeave()
  {
    this.enlarge(1);
  }

  private enlarge(size: number) {
    this.el.nativeElement.style.transform = `scale(${size})`;
  }
}
