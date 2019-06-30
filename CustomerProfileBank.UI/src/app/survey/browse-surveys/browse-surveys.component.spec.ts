import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BrowseSurveysComponent } from './browse-surveys.component';

describe('BrowseSurveysComponent', () => {
  let component: BrowseSurveysComponent;
  let fixture: ComponentFixture<BrowseSurveysComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BrowseSurveysComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BrowseSurveysComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
