import { Injectable, Injector, InjectionToken } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Http } from '@angular/http';
import { httpGetHeader } from './config';
import { catchError } from 'rxjs/operators';
import { catchConnectionError } from '../additional/functions';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';



export const API_BASE_URL = new InjectionToken<string>("API_BASE_URL");

export function ConfigFactory(configService: ConfigService, file: string, property: string) {
  let con = configService.loadJSON(file)[property]
  return con;
}

@Injectable()
export class ConfigService {

  constructor(private _http: HttpClient, private http: Http, private injector: Injector) { }

  public get router(): Router { //this creates router property on your service.
    return this.injector.get(Router);
  }


    apiUrl: string;




    loadJSON(filePath) {
    const json = this.loadTextFileAjaxSync(filePath, "application/json");

    return JSON.parse(json);
  }

    loadTextFileAjaxSync(filePath, mimeType) {
    
    const xmlhttp = new XMLHttpRequest();
    xmlhttp.open("GET", filePath, false);
    if (mimeType != null) {
      if (xmlhttp.overrideMimeType) {
        xmlhttp.overrideMimeType(mimeType);
      }
    }
    xmlhttp.send();
    if (xmlhttp.status == 200) {
      return xmlhttp.responseText;
    }
    else {
      return null;
    }
  }

}
