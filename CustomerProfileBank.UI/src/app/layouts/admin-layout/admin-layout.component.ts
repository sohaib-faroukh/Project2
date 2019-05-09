import { Component, OnInit } from '@angular/core';
import { Router ,NavigationStart,NavigationEnd, Event, NavigationCancel, NavigationError} from '@angular/router';

@Component({
  selector: 'app-admin-layout',
  templateUrl: './admin-layout.component.html',
  styleUrls: ['./admin-layout.component.scss']
})
export class AdminLayoutComponent implements OnInit {

  ShowLoadingIndicator:boolean=true;

  constructor(
    private router:Router
    ) { 
    this.router.events.subscribe((_event:Event)=>{

      if(_event instanceof NavigationStart){
        this.ShowLoadingIndicator=true;
      }
      else if(_event instanceof NavigationEnd){
        this.ShowLoadingIndicator=false;
      }
      if (_event instanceof NavigationCancel) {
        this.ShowLoadingIndicator=false;

      }
      if (_event instanceof NavigationError) {
        this.ShowLoadingIndicator=false;
      }
    })
  }

  ngOnInit() {
  }

}
