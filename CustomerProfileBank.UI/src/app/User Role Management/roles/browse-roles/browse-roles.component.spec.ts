import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BrowseRolesComponent } from './browse-roles.component';

describe('BrowseRolesComponent', () => {
  let component: BrowseRolesComponent;
  let fixture: ComponentFixture<BrowseRolesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BrowseRolesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BrowseRolesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
