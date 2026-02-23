import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class Auth {
  constructor(private http:HttpClient){}

login(dane_logowania:any)
{
return this.http.post<{ID:number}>('https://localhost:7195/User/login-user',dane_logowania);


}

}
