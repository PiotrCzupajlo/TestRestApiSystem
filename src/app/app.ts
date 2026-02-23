import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavBar } from './nav-bar/nav-bar';
import { Login } from './login/login';
import { Register } from './register/register';
import { Namefromid } from './namefromid';
import { ChangeDetectorRef } from '@angular/core';
@Component({
  selector: 'app-root',
  imports: [RouterOutlet,NavBar,Login,Register],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  Title = "Simpleshop";
  loginb = true;
  registerb = false;
  user_id=-1 ;
  username="";
  constructor(private namefromid:Namefromid, private cdr:ChangeDetectorRef){}
  ChangeToRegister(){
  console.log("Otrzymano alert");
    this.loginb=false;
    this.registerb=true;

  }
  ChangeToLogIn(){
    this.loginb=true;
    this.registerb=false;
  }
  ChangeToLogged(user_id:number)
 {
  console.log(user_id);
  this.loginb=false;
  this.registerb=false;
  this.user_id = user_id;
  const data = {id : user_id}
  this.namefromid.nameFromId(data).subscribe({
next:(response)=>{
  console.log(user_id);
this.username = response.name;
this.cdr.detectChanges();
console.log(this.username);

},
error:(exception)=>{
console.error(exception);
console.log(user_id);
}



  })
  
 }



}
