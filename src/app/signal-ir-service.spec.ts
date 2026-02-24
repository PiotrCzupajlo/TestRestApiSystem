import { TestBed } from '@angular/core/testing';

import { SignalIrService } from './signal-ir-service';

describe('SignalIrService', () => {
  let service: SignalIrService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SignalIrService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
