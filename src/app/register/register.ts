import { Component ,EventEmitter,Output} from '@angular/core';

@Component({
  selector: 'app-register',
  imports: [],
  templateUrl: './register.html',
  styleUrl: './register.css',
})
export class Register {

@Output() login_alert = new EventEmitter<void>();
login_clicked(){
this.login_alert.emit();



}

}
