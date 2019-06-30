import { HttpHeaders } from "@angular/common/http";

// export const HOST_API_URL:string = "http://localhost/CFB/api/"
export const HOST_API_URL:string = localStorage.getItem("API_URL");


export const httpGetHeader = {
    headers: new HttpHeaders({
        // 'Content-Type':  'application/json'
    }),
    // withCredentials: true,
  }

export const httpPostHeader = {
    headers: new HttpHeaders({
        'Content-Type':  'application/json'
    }),
    // withCredentials: true,
  }




  export const httpPutHeader = {
    headers: new HttpHeaders({
        'Content-Type':  'application/json'
    }),
    // withCredentials: true,
  }

  