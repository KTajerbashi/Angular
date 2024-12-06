import { TestBed } from '@angular/core/testing';
import { CanActivateChildFn } from '@angular/router';

import { childAuthGuard } from './child-auth.guard';

describe('childAuthGuard', () => {
  const executeGuard: CanActivateChildFn = (...guardParameters) => 
      TestBed.runInInjectionContext(() => childAuthGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
