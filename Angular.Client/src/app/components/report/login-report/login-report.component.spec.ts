import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginReportComponent } from './login-report.component';

describe('LoginReportComponent', () => {
  let component: LoginReportComponent;
  let fixture: ComponentFixture<LoginReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LoginReportComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LoginReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
