import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ResponsSurveyComponent } from './respons-survey.component';

describe('ResponsSurveyComponent', () => {
  let component: ResponsSurveyComponent;
  let fixture: ComponentFixture<ResponsSurveyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ResponsSurveyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ResponsSurveyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
