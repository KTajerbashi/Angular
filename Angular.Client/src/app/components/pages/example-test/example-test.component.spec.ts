import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExampleTestComponent } from './example-test.component';

describe('ExampleTestComponent', () => {
  let component: ExampleTestComponent;
  let fixture: ComponentFixture<ExampleTestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ExampleTestComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ExampleTestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
