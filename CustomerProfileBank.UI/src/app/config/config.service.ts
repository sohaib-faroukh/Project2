import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { httpGetHeader } from './config';
import { catchError } from 'rxjs/operators';
import { catchConnectionError } from '../additional/functions';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {

  constructor(private http:HttpClient) { }

  getConfig():Observable<any>{
    return this.http.get<any>(`assets/config.json`,{headers:httpGetHeader});
  }
}
