import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServiceExampleComponent } from './service-example.component';

describe('ServiceExampleComponent', () => {
  let component: ServiceExampleComponent;
  let fixture: ComponentFixture<ServiceExampleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ServiceExampleComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ServiceExampleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
