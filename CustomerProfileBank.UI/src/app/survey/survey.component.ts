import { Component, OnInit } from '@angular/core';
import { Router, NavigationStart,Event, NavigationEnd, NavigationCancel, NavigationError } from '@angular/router';

@Component({
  selector: 'app-survey',
  templateUrl: './survey.component.html',
  styleUrls: ['./survey.component.scss']
})
export class SurveyComponent implements OnInit {
  
  constructor(
    private router: Router
  ) {}

  ngOnInit() {
  }

}
