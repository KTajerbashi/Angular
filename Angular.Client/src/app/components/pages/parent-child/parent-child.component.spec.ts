import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ParentChildComponent } from './parent-child.component';

describe('ParentChildComponent', () => {
  let component: ParentChildComponent;
  let fixture: ComponentFixture<ParentChildComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ParentChildComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ParentChildComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
