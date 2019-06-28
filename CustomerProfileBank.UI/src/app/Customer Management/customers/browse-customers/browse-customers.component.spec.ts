import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BrowseCustomersComponent } from './browse-customers.component';

describe('BrowseCustomersComponent', () => {
  let component: BrowseCustomersComponent;
  let fixture: ComponentFixture<BrowseCustomersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BrowseCustomersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BrowseCustomersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
