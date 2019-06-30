import { Component, OnInit } from '@angular/core';
import { Router, NavigationStart,Event, NavigationEnd, NavigationCancel, NavigationError } from '@angular/router';

@Component({
  selector: 'app-survey',
  templateUrl: './survey.component.html',
  styleUrls: ['./survey.component.scss']
})
export class SurveyComponent implements OnInit {
  ShowLoadingIndicator: boolean = true;

  constructor(
    private router: Router
  ) {
    this.router.events.subscribe((_event: Event) => {

      if (_event instanceof NavigationStart) {
        this.ShowLoadingIndicator = true;
      }
      else if (_event instanceof NavigationEnd) {
        this.ShowLoadingIndicator = false;
      }
      if (_event instanceof NavigationCancel) {
        this.ShowLoadingIndicator = false;

      }
      if (_event instanceof NavigationError) {
        this.ShowLoadingIndicator = false;
      }
    })
  }

  ngOnInit() {
  }

}
