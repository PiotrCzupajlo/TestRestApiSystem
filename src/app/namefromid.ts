import { Injectable, numberAttribute } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root',
})
export class Namefromid {
  
  constructor(private http:HttpClient){}

  nameFromId(data:any){


    return this.http.post<{name:string}>("https://localhost:7195/User/get-name-by-id",data);
  }


}
