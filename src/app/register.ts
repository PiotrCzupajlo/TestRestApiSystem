import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class RegisterService {
  constructor(private http:HttpClient){}

  register(dane_rejestracji:any){

    return this.http.post("https://localhost:7195/User/insert-user",dane_rejestracji);
  }
}
