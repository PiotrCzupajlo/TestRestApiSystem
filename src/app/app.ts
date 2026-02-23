import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavBar } from './nav-bar/nav-bar';
import { Login } from './login/login';
import { Register } from './register/register';
@Component({
  selector: 'app-root',
  imports: [RouterOutlet,NavBar,Login,Register],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  Title = "Simpleshop";
  protected readonly title = signal('simpleshop');
  loginb = true;
  registerb = false;

  ChangeToRegister(){
  console.log("Otrzymano alert");
    this.loginb=false;
    this.registerb=true;

  }
  ChangeToLogIn(){
    this.loginb=true;
    this.registerb=false;



  }
}
