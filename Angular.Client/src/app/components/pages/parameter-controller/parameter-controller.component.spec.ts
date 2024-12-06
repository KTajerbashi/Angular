import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ParameterControllerComponent } from './parameter-controller.component';

describe('ParameterControllerComponent', () => {
  let component: ParameterControllerComponent;
  let fixture: ComponentFixture<ParameterControllerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ParameterControllerComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ParameterControllerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
