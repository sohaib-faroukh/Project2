import { Injectable } from '@angular/core';
import { CanActivate, CanActivateChild, CanDeactivate, CanLoad, Route, UrlSegment, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AddEditUserComponent } from '../User Role Management/users/add-edit-user/add-edit-user.component';
import { AddEditRoleComponent } from '../User Role Management/roles/add-edit-role/add-edit-role.component';
import {confirm} from 'devextreme/ui/dialog'
@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate, CanActivateChild, CanLoad,
  CanDeactivate<AddEditUserComponent | AddEditRoleComponent> {


  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {

    let active = true;
    console.log("Can Activate ? " + active)
    return active;
  }
  canActivateChild(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    let active = true;
    console.log("Can Activate Child ? " + active)
    return active;
  }
  canLoad(
    route: Route,
    segments: UrlSegment[]): Observable<boolean> | Promise<boolean> | boolean {
    let active = true;
    console.log("Can Load ? " + active)
    return active;
  }

  async canDeactivate(component: AddEditUserComponent | AddEditRoleComponent, currentRoute: ActivatedRouteSnapshot,
    currentState: RouterStateSnapshot, nextState?: RouterStateSnapshot) {
      
    if(component.valuesChanged==false){
      console.log(`Can Deactivate ${component.constructor.name} ? yes because no changes`);
      return  true ;
    }
    else{
      var res = await confirm("You didn't save your changes<br>Are you sure you want to leave this page ?","Leave Confirm");
      if(res){
        console.log(`Can Deactivate ${component.constructor.name} ? yes because accept confirm`);
        return true;
      }
      else{
        console.log(`Can Deactivate ${component.constructor.name} ? no because reject confirm`);
        return false;
      }
    }

  }


}
