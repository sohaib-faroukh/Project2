import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-dialog-box',
  templateUrl: './dialog-box.component.html',
  styleUrls: ['./dialog-box.component.scss']
})
export class DialogBoxComponent implements OnInit {

  constructor(private router: Router, private route: ActivatedRoute) { }


  NationalNumber: string = "";

  ngOnInit() {
    let res = this.route.snapshot.params.nationalNumber;
    if (res != null && res.trim() != "") {
      this.NationalNumber = res;
    }
    else {
      this.router.navigate(["**",{Message:"Can't ",Code:404}]);
    }

  }


  navigate(bool) {
    switch (bool) {
      case true: {
        this.router.navigate([`/survey/surveyResponse/${this.NationalNumber}`]);
        break;
      }
      case false: {
        this.router.navigate(['/']);
        break;

      }
    }
  }
}
