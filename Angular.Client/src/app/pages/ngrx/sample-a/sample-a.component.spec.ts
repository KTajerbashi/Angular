import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SampleAComponent } from './sample-a.component';

describe('SampleAComponent', () => {
  let component: SampleAComponent;
  let fixture: ComponentFixture<SampleAComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SampleAComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SampleAComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
