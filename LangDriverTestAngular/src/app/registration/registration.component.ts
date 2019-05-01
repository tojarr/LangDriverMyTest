import { Component, OnInit } from '@angular/core';
import { RegistrationService } from './registration.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  login:string;
  password:string;
  confirmedPassword:string;
  useremail:string;
  regMessage:string = '';

  constructor(private registrationService: RegistrationService) { }

  ngOnInit() {
  }

  registration(){
    console.log('Registration');
    const body = {login:this.login, password:this.password, email:this.useremail}
    this.registrationService.Registration(body).subscribe(res => this.regMessage = res);
    console.log(this.regMessage);
  }
}
