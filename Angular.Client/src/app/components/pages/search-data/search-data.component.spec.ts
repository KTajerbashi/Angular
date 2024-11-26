import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchDataComponent } from './search-data.component';

describe('SearchDataComponent', () => {
  let component: SearchDataComponent;
  let fixture: ComponentFixture<SearchDataComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SearchDataComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SearchDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
