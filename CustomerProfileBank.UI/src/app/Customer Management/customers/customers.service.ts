import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { API_BASE_URL } from 'src/app/config/config.service';
import { Customer } from 'src/app/models/Customer';
import { Observable, throwError, of } from 'rxjs';
import { httpGetHeader, httpPutHeader, httpPostHeader } from 'src/app/config/config';
import { debounceTime, distinctUntilChanged, delay, catchError, map } from 'rxjs/operators';
import { Resolve, ActivatedRouteSnapshot, Router, ActivatedRoute } from '@angular/router';
import { showNotification } from 'src/app/additional/functions';

@Injectable({
  providedIn: 'root'
})
export class CustomersService implements Resolve<Customer[]> {

  apiUrl: string = null;

  constructor(private http: HttpClient, @Inject(API_BASE_URL) _apiUrl_: string) {
    this.apiUrl = _apiUrl_;
  }

  getAll(): Observable<Customer[]> {

    let url = `${this.apiUrl}/customers`;

    console.log("CustomersService - getAll() : ");
    console.log(url);

    return this.http.get<Customer[]>(url,  httpGetHeader );
  }
  getById(id: number | string): Observable<Customer> {

    let url = `${this.apiUrl}/customers/${+id}`;

    console.log("CustomersService -  getById(_id: number | string) : ");
    console.log(url);

    return this.http.get<Customer>(url,httpGetHeader );

  }



  post(item: Customer): Observable<Customer> {

    let url = `${this.apiUrl}/customers/post`;

    console.log("CustomersService - post(item: Customer):");
    console.log(url, JSON.stringify(item), JSON.stringify(httpPutHeader ));

    return this.http.post<Customer>(url, JSON.stringify(item),  httpPostHeader )
      .pipe(
        debounceTime(150),
      );

  }



  put(item: Customer): Observable<Customer> {

    let url = `${this.apiUrl}/customers/put/${item.Id}`;

    console.log("CustomersService - put(item: Customer):");
    console.log(url, JSON.stringify(item), JSON.stringify( httpPutHeader ));

    return this.http.put<Customer>(url, JSON.stringify(item), httpPutHeader )

      .pipe(
        debounceTime(150),
      );

  }




  deactivate(id: number): Observable<any> {

    let url = `${this.apiUrl}/customers/deactivate/${+id}`;

    console.log("CustomersService - deactivate(id: number):");
    console.log(url, JSON.stringify({ headers: httpPutHeader }));

    return this.http.put<Customer>(url,  httpGetHeader );

  }


  resolve() {
    return this.getAll();
  }
}






@Injectable({
  providedIn: 'root'
})
export class EditCustomerResolverService implements Resolve<Customer>{

  constructor(private router: Router, private route: ActivatedRoute, private srv: CustomersService, private http: HttpClient) { }

  resolve(route: ActivatedRouteSnapshot) {

    let action: string = route.params.action;

    let id: number = +route.params.id;

    if (action.trim().toLowerCase() == "edit" && id && !isNaN(id)) {
      return this.srv.getById(id)

        // enhance requests experiance
        .pipe(
          debounceTime(150),
          distinctUntilChanged(),
          delay(200),
          catchError(err => {
            console.log(err);
            showNotification(err.message, "bottom", "center", "danger");
            this.router.navigate(['/pageNotFound', { error: err.message, code: err.status }]);
            return of(null);
          })
        );
    }
  }

}