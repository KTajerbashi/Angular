import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserPrivilegeComponent } from './user-privilege.component';

describe('UserPrivilegeComponent', () => {
  let component: UserPrivilegeComponent;
  let fixture: ComponentFixture<UserPrivilegeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UserPrivilegeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UserPrivilegeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
