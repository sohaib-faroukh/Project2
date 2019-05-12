import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Role } from 'src/app/models/Role';
import { HOST_API_URL, httpPostHeader, httpGetHeader, httpPutHeader } from 'src/app/config/config';
import { map, find, debounceTime, distinctUntilChanged, delay } from 'rxjs/operators';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Privilege } from 'src/app/models/Privilege';
import { ConfigService, API_BASE_URL } from 'src/app/config/config.service';


@Injectable({
  providedIn: 'root'
})
export class RolesService implements Resolve<Role[]>{

  apiUrl:string=null;

  constructor(private http: HttpClient, @Inject(API_BASE_URL)_apiUrl_ :string) {
    this.apiUrl=_apiUrl_;
   }


  getAllRoles(): Observable<Role[]> {
    
    let url = `${this.apiUrl}/Roles`;
    console.log("getAllRoles() : ");
    console.log(url);
    return this.http.get<Role[]>(url, { headers: httpGetHeader });
  }

  getAllPrivileges(): Observable<Privilege[]> {
    
    let url = `${this.apiUrl}/Privileges`;
    console.log("getAllPrivileges() : ");
    console.log(url);

    return this.http.get<Privilege[]>(url, { headers: httpGetHeader });
  }

  getRoleById(id: number | string): Observable<Role> {
    let url = `${this.apiUrl}/Roles/${+id}`;
    console.log("getRoleById(id: number | string):");
    console.log(url);
    return this.http.get<Role>(url, { headers: httpGetHeader });
  }

  post(item: Role): Observable<Role> {
    let url = `${this.apiUrl}/Roles`;
    console.log("post(role: Role):");
    console.log(url);

    return this.http.post<Role>(url, JSON.stringify(item), { headers: httpPostHeader });
  }



  put(item: Role): Observable<Role> {

    let url = `${this.apiUrl}/Roles/${item.Id}`;
    console.log("put(item: Role):");
    console.log(url);

    return this.http.post<Role>(url, JSON.stringify(item), { headers: httpPutHeader });

  }

  deactivate(id: number | string): Observable<any> {
    
    let url = `${this.apiUrl}/Roles/${+id}`;
    console.log("deactivate(id: number | string):");
    console.log(url);

    return this.http.delete<Role>(url, { headers: httpGetHeader });
  }

  resolve() {
    return this.getAllRoles();
  }

}







@Injectable({
  providedIn: 'root'
})
export class EditRoleResolverService implements Resolve<Role>{

  constructor(private srv: RolesService, private http: HttpClient) { }

  resolve(route: ActivatedRouteSnapshot) {

    let action: string = route.params.action;

    let id: number = +route.params.id;

    if (action.trim().toLowerCase() == "edit" && id && !isNaN(id)) {
      return this.srv.getRoleById(id)
      
      // enhance requests experiance        
      .pipe(
          debounceTime(150),
          distinctUntilChanged(),
          delay(200)
        );
    }
  }

}






@Injectable({
  providedIn: 'root'
})
export class PrivilegesResolver implements Resolve<Privilege[]>{

  constructor(private srv: RolesService, private http: HttpClient) { }

  resolve() {
    return this.srv.getAllPrivileges();
  }
}