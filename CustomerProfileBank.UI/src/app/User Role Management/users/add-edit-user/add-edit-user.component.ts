import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { User } from 'src/app/models/User';
import { Role } from 'src/app/models/Role';
import { state } from '../../component-state';
import { onValueChange, catchConnectionError, showNotification } from 'src/app/additional/functions';
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

  _Roles: Role[] = [];
  Roles: any[] = [];

  valuesChanged: boolean = false;

  constructor(private srv: UsersService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    let RouteData = this.route.snapshot.data;

    if (RouteData["Roles"]) {

      this._Roles = RouteData["Roles"];

      this.Roles = this._Roles.map(ele => {
        if (ele.Status.trim().toUpperCase() == "ACTIVE") {
          return { Id: ele.Id, Name: ele.Name, Description: ele.Description };
        }
      })

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
    else {
      this.router.navigate(['/users']);
    }

  }


  onValueChange() {
    this.valuesChanged = onValueChange(this.currentUser, this.currentUserCopy);
  }

  selectCompareFun(a: any, b: any): boolean {
    return a && b && a.Id == b.Id ? true : false;
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
      default: {
        break;
      }
    }
  }


  // to use for post new  role by calling the service method which connect via HTTP with backend
  post() {
    this.srv.post(this.currentUser).subscribe(
      res => {
        this.valuesChanged = false;
        this.router.navigate(['/users']);
        if (res) {
          showNotification("Added succesfully", "bottom", "center", "success");
          console.log("POSTED : " + JSON.stringify(res));
        }
        else {
          showNotification("Didn't POSTED , no result returned", "bottom", "center", "danger");
          console.log("%c Didn't POSTED , no result returned", 'color:red');
        }
      },
      err => {
        showNotification("Error : "+JSON.stringify(err), "bottom", "center", "danger");
        catchConnectionError(err);
      }
    )
  }



  // to use for update existing role by calling the service method which connect via HTTP with backend
  put() {
    this.srv.put(this.currentUser).subscribe(
      res => {

        this.valuesChanged = false;
        this.router.navigate(['/users']);
        if (res) {
          showNotification("Updated succesfully", "bottom", "center", "success");
          console.log("UPDATED : " + JSON.stringify(res));
        }
        else {
          showNotification("Didn't UPDATED , no result returned", "bottom", "center", "danger");
          console.log("%c Didn't UPDATED , no result", 'color:red');
        }
      },
      err => {
        showNotification("Error : "+JSON.stringify(err), "bottom", "center", "danger");
        catchConnectionError(err);
      }
    )
  }


}
