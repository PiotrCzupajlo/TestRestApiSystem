import { Component ,EventEmitter,Output} from '@angular/core';
import { RegisterService } from '../register';
import { FormsModule } from '@angular/forms';
import { consumerAfterComputation } from '@angular/core/primitives/signals';

@Component({
  selector: 'app-register',
  imports: [FormsModule],
  standalone:true,
  templateUrl: './register.html',
  styleUrl: './register.css',
})
export class Register {
constructor(private reg:RegisterService){};
@Output() login_alert = new EventEmitter<void>();
@Output() try_register_event = new EventEmitter<Number>();
name=''
email=''
password=''

login_clicked(){
this.login_alert.emit();

}

try_register(){
const dane = {name:this.name,email:this.email, password: this.password};
console.log("in register func")
this.reg.register(dane).subscribe({
next:(response)=>{
console.log(response);
this.login_alert.emit();


},
error:(exception)=>{
console.error(exception);

}




});

}


}
