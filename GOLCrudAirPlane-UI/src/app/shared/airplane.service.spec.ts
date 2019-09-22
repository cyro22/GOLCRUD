import { TestBed } from '@angular/core/testing';

import { AirplaneService } from './Airplane.service';

describe('AirplaneService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AirplaneService = TestBed.get(AirplaneService);
    expect(service).toBeTruthy();
  });
});
