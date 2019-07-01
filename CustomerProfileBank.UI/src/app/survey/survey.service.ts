import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { API_BASE_URL } from '../config/config.service';
import { Survey } from '../models/Survey';
import { httpPostHeader, httpPutHeader, httpGetHeader } from '../config/config';
import { debounceTime, distinctUntilChanged, delay } from 'rxjs/operators';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class SurveyService {

  apiUrl: string = null;

  constructor(private http: HttpClient, @Inject(API_BASE_URL) _apiUrl_: string) {
    this.apiUrl = _apiUrl_;
  }

  getAll(): Observable<Survey[]> {

    let url = `${this.apiUrl}/Surveys`;

    console.log("getAll(): ");
    console.log(url);

    return this.http.get<Survey[]>(url, httpGetHeader);
  }

  getById(id: number | string): Observable<Survey> {

    let url = `${this.apiUrl}/Surveys/${+id}`;

    console.log("getById(_id: number | string) : ");
    console.log(url);

    return this.http.get<Survey>(url, httpGetHeader)

  }



  post(item: Survey): Observable<Survey> {

    let url = `${this.apiUrl}/Surveys/post`;

    console.log("post(item: Survey):");
    console.log(url, JSON.stringify(item), JSON.stringify(httpPutHeader));

    return this.http.post<Survey>(url, JSON.stringify(item), httpPostHeader)
      .pipe(
        debounceTime(150),
      );

  }



  put(item: Survey): Observable<Survey> {

    let url = `${this.apiUrl}/Surveys/put/${item.Id}`;

    console.log("put(item: Survey):");
    console.log(url, JSON.stringify(item), JSON.stringify(httpPutHeader));

    return this.http.put<Survey>(url, JSON.stringify(item), httpPutHeader)

      .pipe(
        debounceTime(150),
      );

  }




  deactivate(id: number): Observable<any> {

    let url = `${this.apiUrl}/Surveys/deactivate/${+id}`;

    console.log("deactivate(id: number):");
    console.log(url, JSON.stringify(httpPutHeader));

    return this.http.delete<Survey>(url, httpGetHeader);

  }



  delete(id: number | string): Observable<Survey> {

    let url = `${this.apiUrl}/Surveys/delete/${+id}`;

    console.log("delete(_id: number | string) : ");
    console.log(url);

    return this.http.delete<Survey>(url, httpGetHeader)

  }

  getSurveyToRespond(NationalNumber: string | number) {
    let url = `${this.apiUrl}/Surveys/answer/${+NationalNumber}`;

    console.log("getSurveyToRespond(NationalNumber: number | string) : ");
    console.log(url);

    return this.http.get<Survey>(url, httpGetHeader)

  }



  sendSurveyResponse(response) {
    let url = `${this.apiUrl}/Surveys/sendResponse`;

    console.log("sendSurveyResponse(response) : ");
    console.log(url);

    return this.http.post<any>(url, response, httpGetHeader)

  }



  resolve() {
    return this.getAll();
  }

}




@Injectable({
  providedIn: 'root'
})
export class EditSurveysResolverService implements Resolve<Survey>{

  constructor(private srv: SurveyService, private http: HttpClient) { }

  resolve(route: ActivatedRouteSnapshot) {

    let action: string = route.params.action;

    let id: number = +route.params.id;

    if (action.trim().toLowerCase() == "edit" && id && !isNaN(id)) {
      return this.srv.getById(id)

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
export class ToResponseSurveysResolver implements Resolve<Survey>{

  constructor(private srv: SurveyService, private http: HttpClient) { }

  resolve(route: ActivatedRouteSnapshot) {


    let nationalNumber = +route.params.nationalNumber;


    return this.srv.getSurveyToRespond(nationalNumber)

      // enhance requests experiance
      .pipe(
        debounceTime(150),
        distinctUntilChanged(),
        delay(200)
      );

  }

}

