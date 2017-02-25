import { TestBed, inject } from '@angular/core/testing';
import { SecurityservicenewService } from './securityservicenew.service';

describe('SecurityservicenewService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SecurityservicenewService]
    });
  });

  it('should ...', inject([SecurityservicenewService], (service: SecurityservicenewService) => {
    expect(service).toBeTruthy();
  }));
});
