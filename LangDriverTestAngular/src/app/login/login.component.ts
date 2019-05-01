import { Component, OnInit } from '@angular/core';
import { LoginService } from './login.service';
import { Router } from '@angular/router';
import { AppComponent } from '../app.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public login: string = "string";
  public password: string = "string";
  loginError: boolean = false;
  loginErrorMessage: string = 'Password or login is incorrect';
  constructor(private loginService : LoginService, private router : Router, private app:AppComponent) { }

  ngOnInit() {
  }

  private Login(){
    this.loginService.Login(this.login, this.password).subscribe(res => {
        localStorage.setItem('User', JSON.stringify(res));
        this.app.isLoged = true;
        this.app.userName = JSON.parse(localStorage.getItem('User')).email;
        // console.log('-------');
        // console.log(JSON.parse(localStorage.getItem('User')).email);
        // console.log(JSON.parse(localStorage.getItem('User')).inActive);
        this.router.navigate(['editDictionary']);
      }, 
    error => {
      this.loginError = true;
      }
    )
  } 
}
