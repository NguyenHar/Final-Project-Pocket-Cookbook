import { TestBed } from '@angular/core/testing';

import { UserFavoritesService } from './user-favorites.service';

describe('UserFavoritesService', () => {
  let service: UserFavoritesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UserFavoritesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
