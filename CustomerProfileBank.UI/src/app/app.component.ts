import { Component } from '@angular/core';
import { ConfigService } from './config/config.service';
import { STRING_TYPE } from '@angular/compiler/src/output/output_ast';
import { catchConnectionError } from './additional/functions';
import { UsersService } from './User Role Management/users/users.service';
import { Router, NavigationStart, NavigationEnd, Event, NavigationCancel, NavigationError } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Customer Profiel Bank';
  ShowLoadingIndicator: boolean = true;

  constructor(
    private router: Router
  ) {
    this.router.events.subscribe((_event: Event) => {

      if (_event instanceof NavigationStart) {
        this.showLoading(true);
      }
      else if (_event instanceof NavigationEnd) {
        this.showLoading(false);
      }
      if (_event instanceof NavigationCancel) {
        this.showLoading(false);

      }
      if (_event instanceof NavigationError) {
        this.showLoading(false);
      }
    })
  }


  showLoading(value: boolean) {
    if (value == false) {
      setTimeout(() => {
        this.ShowLoadingIndicator = value;
      }, 200);
    }
    else {
      this.ShowLoadingIndicator = value;
    }
  }


  ngOnInit() {
  }

}
