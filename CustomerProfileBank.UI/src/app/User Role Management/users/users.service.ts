import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from 'src/app/models/User';
import { HOST_API_URL, httpPostHeader, httpPutHeader, httpGetHeader } from 'src/app/config/config';
import { tap, map, filter, find, debounceTime, distinctUntilChanged, delay } from 'rxjs/operators';
import { Resolve, ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class UsersService implements Resolve<User[] | User>{

  constructor(private http: HttpClient) { 
	console.log(HOST_API_URL);
  }

  getAllUsers(): Observable<User[]> {
    return this.http.get<User[]>(HOST_API_URL)

      .pipe(map(ele => ele["Users"]));

  }

  getUserById(id: number | string): Observable<User> {
    return this.http.get<User>(HOST_API_URL, { headers: httpGetHeader })
      .pipe(map(ele => ele["Users"].find(t => t.id == id)));//.find(t => t.id == id)
  }



  post(item: User): Observable<User> {
    return this.http.post<User>(HOST_API_URL, JSON.stringify(item), { headers: httpPostHeader })

      .pipe(
        map(() => item),
        debounceTime(500),
      );

  }



  put(item: User): Observable<User> {
    return this.http.post<User>(`${HOST_API_URL}/${item.id}`, JSON.stringify(item), { headers: httpPutHeader })

      .pipe(
        // map(() => item),
        debounceTime(500),
      );

  }




  deactivate(id: number): Observable<any> {
    return this.http.get<User>(HOST_API_URL, { headers: httpGetHeader })

      .pipe(map(ele => {


        let res = ele["Users"];
        let ix = res.findIndex(t => t.id == id);
        res[ix].status = 'InActive';
        res[ix].deactivationDate = new Date();

        return res[ix];
      }));
  }

  resolve() {
    return this.getAllUsers();
  }

}




@Injectable({
  providedIn: 'root'
})
export class EditUsersResolverService implements Resolve<User>{

  constructor(private srv: UsersService, private http: HttpClient) { }

  resolve(route: ActivatedRouteSnapshot) {

    let action: string = route.params.action;

    let id: number = +route.params.id;

    if (action.trim().toLowerCase() == "edit" && id && !isNaN(id)) {
      return this.srv.getUserById(id).pipe(
        debounceTime(500),
        distinctUntilChanged(),
        // delay(5000)
      );

    }
  }

}