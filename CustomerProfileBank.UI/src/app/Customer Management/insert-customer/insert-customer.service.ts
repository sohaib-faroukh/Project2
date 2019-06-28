import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { API_BASE_URL } from 'src/app/config/config.service';

@Injectable({
  providedIn: 'root'
})
export class InsertCustomerService {

  apiUrl: string="";

  constructor(private http:HttpClient,
    @Inject(API_BASE_URL) _apiUrl_: string) {
    this.apiUrl = _apiUrl_;
  } 

  uploadFileAndNatioNumber(selectedFile:FormData):Observable<any>{

    let url = `${this.apiUrl}/Upload`;
    return this.http.post<any>(url, selectedFile);
    
  }

}
