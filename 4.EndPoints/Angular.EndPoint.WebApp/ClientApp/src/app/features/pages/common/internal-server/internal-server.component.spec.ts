import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InternalServerComponent } from './internal-server.component';

describe('InternalServerComponent', () => {
  let component: InternalServerComponent;
  let fixture: ComponentFixture<InternalServerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InternalServerComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InternalServerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
