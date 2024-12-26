import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReadProductComponent } from './read-product.component';

describe('ReadProductComponent', () => {
  let component: ReadProductComponent;
  let fixture: ComponentFixture<ReadProductComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ReadProductComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReadProductComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
