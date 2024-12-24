import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserReadComponent } from './user-read.component';

describe('UserReadComponent', () => {
  let component: UserReadComponent;
  let fixture: ComponentFixture<UserReadComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UserReadComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UserReadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
