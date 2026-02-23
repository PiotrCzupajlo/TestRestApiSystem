import { TestBed } from '@angular/core/testing';

import { Namefromid } from './namefromid';

describe('Namefromid', () => {
  let service: Namefromid;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Namefromid);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
