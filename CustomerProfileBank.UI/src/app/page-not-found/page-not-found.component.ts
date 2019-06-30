import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-page-not-found',
  templateUrl: './page-not-found.component.html',
  styleUrls: ['./page-not-found.component.scss']
})
export class PageNotFoundComponent implements OnInit {

  constructor(private router:Router,private route:ActivatedRoute) { }

  errorCode:number;

  errorMessage:string="";

  ngOnInit() {

    let res = this.route.snapshot.paramMap.get('error');

debugger

  }

}
