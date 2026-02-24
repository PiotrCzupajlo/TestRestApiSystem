import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import  * as signalIr from '@microsoft/signalr'

@Injectable({
  providedIn: 'root',
})
export class SignalIrService {
  private hubconnection!:signalIr.HubConnection;
  public notificationReceived = new Subject<any>();
  public startConnection(){
this.hubconnection = new signalIr.HubConnectionBuilder()
.withUrl('https://localhost:7195/hubs/notifications',{
accessTokenFactory:()=>localStorage.getItem('token') || ''})
.withAutomaticReconnect()
.build();
this.hubconnection.start().then(()=>console.log("połączono z signalir"))
.catch(err => console.error("blad polaczenia",err));
this.registerOnServerEvents();
  }
  private registerOnServerEvents(){
    this.hubconnection.on('ProductCreated',(data)=>{
      this.notificationReceived.next(data);


    })



  }
}
