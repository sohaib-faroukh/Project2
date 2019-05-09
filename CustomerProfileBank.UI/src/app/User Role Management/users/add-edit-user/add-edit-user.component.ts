import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { User } from 'src/app/models/User';
import { Role } from 'src/app/models/Role';
import { state } from '../../component-state';
import { onValueChange, catchConnectionError } from 'src/app/additional/functions';
import { UsersService } from '../users.service';



@Component({
  selector: 'app-add-edit-user',
  templateUrl: './add-edit-user.component.html',
  styleUrls: ['./add-edit-user.component.scss']
})
export class AddEditUserComponent implements OnInit {

  action: string
  compoState: state = state.add;

  currentUser: User = new User();
  currentUserCopy: User = new User();

  Roles: Role[] = [];

  valuesChanged : boolean = false;

  constructor(private srv:UsersService,private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    let RouteData = this.route.snapshot.data;

    if (RouteData["Roles"]) {
      this.Roles = RouteData["Roles"];
    }
    
    let ActionRouteParam: string = this.route.snapshot.params["action"];

    if (ActionRouteParam && ActionRouteParam.trim().toLowerCase() == "edit") {

      this.compoState = state.edit;



      this.currentUser = RouteData["User"];

      // copy the orginal object data to use it to compare and detect real values changes
      Object.assign(this.currentUserCopy, this.currentUser);

    }

    else if (ActionRouteParam && ActionRouteParam.trim().toLowerCase() == "add") {
      this.compoState = state.add;
      this.currentUser = new User();
    }
    else{
      this.router.navigate(['/users']);
    }

  }


  onValueChange() {
    this.valuesChanged=onValueChange(this.currentUser,this.currentUserCopy);
  }

  selectCompareFun(a:any,b:any):boolean{
    return  a && b && a.id == b.id ? true : false; 
  }


  onSubmit() {
    switch (this.compoState) {
      case state.add: {
        this.post();
        break;
      }
      case state.edit: {
        this.put()
        break;
      }
      default:{
        break;
      }
    }
  }


  // to use for post new  role by calling the service method which connect via HTTP with backend
  post() {
    debugger
    this.srv.post(this.currentUser).subscribe(
      res => {
        if (res) {
          console.log("POSTED : " + JSON.stringify(res));
        }
        else {
          console.log("%c Didn't POST , no result", 'color:red');
        }
      },
      err => {
        catchConnectionError(err);
      }
    )
  }



  // to use for update existing role by calling the service method which connect via HTTP with backend
  put() {
    debugger
    this.srv.put(this.currentUser).subscribe(
      res => {
        if (res) {
          console.log("UPDATED : " + JSON.stringify(res));
        }
        else {
          console.log("%c Didn't UPDATE , no result", 'color:red');
        }
      },
      err => {
        catchConnectionError(err);
      }
    )
  }

  
}
