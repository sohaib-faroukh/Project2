import { Component, OnInit } from '@angular/core';
import { Router ,NavigationStart,NavigationEnd, Event, NavigationCancel, NavigationError} from '@angular/router';

@Component({
  selector: 'app-admin-layout',
  templateUrl: './admin-layout.component.html',
  styleUrls: ['./admin-layout.component.scss']
})
export class AdminLayoutComponent implements OnInit {

  ngOnInit() {
  }

}
