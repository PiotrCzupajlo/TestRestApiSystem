import { Component , EventEmitter, output, Output} from '@angular/core';
import { Auth } from '../auth';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-login',
  imports: [FormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
@Output() change_to_register = new EventEmitter<void>();
@Output() change_to_logged = new EventEmitter<number>();
email=''
password=''
register_button_click(){
console.log("Nacisnieto przycisk register");
this.change_to_register.emit();
}
constructor(private Auth:Auth){}

LogIn_Clicked(){
const dane = {email:this.email,password:this.password};
this.Auth.login(dane).subscribe({
next:(response)=>{
  console.log('succes',response)
  this.change_to_logged.emit(response.ID)
},
error:(exception)=>{
console.error('Login failed',exception);

}




});



}
}
