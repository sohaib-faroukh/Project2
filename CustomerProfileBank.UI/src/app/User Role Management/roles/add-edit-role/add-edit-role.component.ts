import { Component, OnInit } from '@angular/core';
import { state } from '../../component-state';
import { Role } from 'src/app/models/Role';
import { ActivatedRoute, Router } from '@angular/router';
import { Privilege } from 'src/app/models/Privilege';
import { RolesService } from '../roles.service';
import { catchConnectionError, onValueChange } from 'src/app/additional/functions';
import { isArray, isObject } from 'util';

@Component({
  selector: 'app-add-edit-role',
  templateUrl: './add-edit-role.component.html',
  styleUrls: ['./add-edit-role.component.scss']
})
export class AddEditRoleComponent implements OnInit {

  action: string
  compoState: state = state.add;

  currentRole: Role = new Role();
  currentRoleCopy: Role = new Role();

  Users: Role[] = [];
  Privileges: Privilege[] = []

  valuesChanged: boolean = false;
  constructor(private srv: RolesService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    let RouteData = this.route.snapshot.data;

    if (RouteData["Users"]) {
      
      debugger;

      this.Users = RouteData["Users"];
    }
    if (RouteData["Privileges"]) {
      this.Privileges = RouteData["Privileges"];
    }

    let ActionRouteParam: string = this.route.snapshot.params["action"];

    if (ActionRouteParam && ActionRouteParam.trim().toLowerCase() == "edit") {

      this.compoState = state.edit;

      this.currentRole = RouteData["Role"];

      Object.assign(this.currentRoleCopy, this.currentRole);

    }

    else if (ActionRouteParam && ActionRouteParam.trim().toLowerCase() == "add") {
      this.compoState = state.add;
      this.currentRole = new Role();
    }
    else {
      this.router.navigate(['/roles']);
    }

  }



  onValueChange() {
    this.valuesChanged=onValueChange(this.currentRole,this.currentRoleCopy);
  }

  // to use for compare tow objects by id property for Select HTML element 
  selectCompareFun(a: any, b: any): boolean {
    return a && b && a.Id == b.Id ? true : false;
  }



  onSubmit() {
    switch (this.compoState) {
      case state.add: {
        break;
      }
      case state.edit: {
        break;
      }
    }
  }


  // to use for post new  role by calling the service method which connect via HTTP with backend
  post() {
    this.srv.post(this.currentRole).subscribe(
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
    this.srv.put(this.currentRole).subscribe(
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
