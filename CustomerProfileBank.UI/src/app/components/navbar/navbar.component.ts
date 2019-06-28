import { Component, OnInit, ElementRef } from '@angular/core';
import { Location, LocationStrategy, PathLocationStrategy } from '@angular/common';
import { Router } from '@angular/router';
import { RouteInfo, ROUTES } from 'src/app/additional/data';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  public focus;
  public listTitles: RouteInfo[];
  public location: Location;
  constructor(location: Location, private element: ElementRef, private router: Router) {
    this.location = location;
  }

  ngOnInit() {
    this.listTitles = ROUTES.filter(listTitle => listTitle);
  }
  getTitle() {

    var returnedTitle: string = null;
    var titlee = this.location.prepareExternalUrl(this.location.path());
    
    if (titlee.charAt(0) === '#') {
      titlee = titlee.slice(2);
    }
    for (var item = 0; item < this.listTitles.length; item++) {
      if (!this.listTitles[item].items) {
        if (this.listTitles[item].path === titlee) {
          returnedTitle = this.listTitles[item].title;
          break;
        }
        else {
          continue;
        }
      }
      else {
        if (this.listTitles[item].items.length > 0) {
          for (var subItem = 0; subItem < this.listTitles[item].items.length; subItem++) {
            if (this.listTitles[item].items[subItem].path === titlee) {
              returnedTitle = this.listTitles[item].items[subItem].title;
              break;
            }
          }
        }
        else {
          continue;
        }
      }
    }
    return returnedTitle != null || returnedTitle !== "" ? returnedTitle : 'Dashboard';
  }

}
