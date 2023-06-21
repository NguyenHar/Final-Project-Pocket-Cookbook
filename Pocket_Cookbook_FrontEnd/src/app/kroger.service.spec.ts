import { TestBed } from '@angular/core/testing';

import { KrogerService } from './kroger.service';

describe('KrogerService', () => {
  let service: KrogerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(KrogerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
