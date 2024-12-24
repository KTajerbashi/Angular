import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ParentDialogComponent } from './parent-dialog.component';

describe('ParentDialogComponent', () => {
  let component: ParentDialogComponent;
  let fixture: ComponentFixture<ParentDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ParentDialogComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ParentDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
