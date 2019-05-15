import { HttpHeaders } from "@angular/common/http";

// export const HOST_API_URL:string = "http://localhost/CFB/api/"
export const HOST_API_URL:string = localStorage.getItem("API_URL");

export const httpPostHeader = new HttpHeaders({
    'Content-Type':  'application/json'
})


export const httpGetHeader = new HttpHeaders({
    'Content-Type':  'application/json'
})


export const httpPutHeader = new HttpHeaders({
    'Content-Type':  'application/json'
})
