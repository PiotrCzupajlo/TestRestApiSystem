import { Component , EventEmitter, output, Output} from '@angular/core';

@Component({
  selector: 'app-login',
  imports: [],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
@Output() change_to_register = new EventEmitter<void>();
register_button_click(){
console.log("Nacisnieto przycisk register");
this.change_to_register.emit();


}
}
