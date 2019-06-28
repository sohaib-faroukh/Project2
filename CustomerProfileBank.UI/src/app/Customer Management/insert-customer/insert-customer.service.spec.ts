import { TestBed } from '@angular/core/testing';

import { InsertCustomerService } from './insert-customer.service';

describe('InsertCustomerService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: InsertCustomerService = TestBed.get(InsertCustomerService);
    expect(service).toBeTruthy();
  });
});
