import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from 'src/app/models/User';
import { HOST_API_URL, httpPostHeader, httpPutHeader, httpGetHeader } from 'src/app/config/config';
import { tap, map, filter, find, debounceTime, distinctUntilChanged, delay } from 'rxjs/operators';
import { Resolve, ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router';
import { ConfigService, API_BASE_URL } from 'src/app/config/config.service';

@Injectable({
  providedIn: 'root'
})
export class UsersService implements Resolve<User[] | User>{
  
  apiUrl:string=null;
  
  constructor(private http: HttpClient,@Inject(API_BASE_URL)_apiUrl_ :string) { 
    this.apiUrl=_apiUrl_;
  }

  getAllUsers(): Observable<User[]> {
    
    let url = `${this.apiUrl}/Users`;

    console.log("getAllUsers(): ");
    console.log(url);

    return this.http.get<User[]>(url, { headers: httpGetHeader });
  }

  getUserById(id: number | string): Observable<User> {

    let url = `${this.apiUrl}/Users/${+id}`;

    console.log("getUserById(_id: number | string) : ");
    console.log(url);

    return this.http.get<User>(url, { headers: httpGetHeader })
  
  }



  post(item: User): Observable<User> {

    let url = `${this.apiUrl}/Users`;

    console.log("post(item: User):");
    console.log(url,JSON.stringify(item),JSON.stringify( { headers: httpPutHeader }));

    return this.http.post<User>(url, JSON.stringify(item), { headers: httpPostHeader })
      .pipe(
        debounceTime(150),
      );

  }



  put(item: User): Observable<User> {

    let url = `${this.apiUrl}/Users/${item.Id}`;

    console.log("put(item: User):");
    console.log(url,JSON.stringify(item),JSON.stringify( { headers: httpPutHeader }));

    return this.http.put<User>(url, JSON.stringify(item), { headers: httpPutHeader })

      .pipe(
        debounceTime(150),
      );

  }




  deactivate(id: number): Observable<any> {

    let url = `${this.apiUrl}/Users/${+id}`;
    
    console.log("deactivate(id: number):");
    console.log(url,JSON.stringify( { headers: httpPutHeader }));

    return this.http.delete<User>(url , { headers: httpGetHeader });

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
      return this.srv.getUserById(id)
      
      // enhance requests experiance
      .pipe(
        debounceTime(150),
        distinctUntilChanged(),
        delay(200)
      );
    }
  }

}