import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Role } from 'src/app/models/Role';
import { HOST_API_URL, httpPostHeader, httpGetHeader, httpPutHeader } from 'src/app/config/config';
import { map, find, debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Privilege } from 'src/app/models/Privilege';

@Injectable({
  providedIn: 'root'
})
export class RolesService implements Resolve<Role[]>{

  constructor(private http: HttpClient) {
	console.log(HOST_API_URL);
  }

  getAllRoles(): Observable<Role[]> {
    return this.http.get<Role[]>(HOST_API_URL, { headers: httpGetHeader })

      .pipe(map(ele => ele["Roles"]));
  }

  getAllPrivileges(): Observable<Privilege[]> {
    return this.http.get<Privilege[]>(HOST_API_URL, { headers: httpGetHeader })

      .pipe(map(ele => ele["Privileges"]));
  }

  getRoleById(id: number | string): Observable<Role> {
    return this.http.get<Role>(HOST_API_URL, { headers: httpGetHeader })

      .pipe(map(ele => ele["Roles"].find(t => t.id == +id)))
  }

  post(item: Role): Observable<Role> {
    return this.http.post<Role>(HOST_API_URL, JSON.stringify(item), { headers: httpPostHeader })

      .pipe(
        map(() => item),
        debounceTime(500),
      );

  }



  put(item: Role): Observable<Role> {
    return this.http.post<Role>(`${HOST_API_URL}/${item.id}`, JSON.stringify(item), { headers: httpPutHeader })

      .pipe(
        // map(() => item),
        debounceTime(500),
      );

  }

  deactivate(id: number): Observable<any> {
    return this.http.get<Role>(HOST_API_URL, { headers: httpGetHeader })

      .pipe(map(ele => {


        let res = ele["Roles"];
        let ix = res.findIndex(t => t.id == id);
        res[ix].status = 'InActive';
        res[ix] = new Date();

        return res[ix];
      }));
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
      return this.srv.getRoleById(id).pipe(
        debounceTime(500),
        distinctUntilChanged(),
        // delay(5000)
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