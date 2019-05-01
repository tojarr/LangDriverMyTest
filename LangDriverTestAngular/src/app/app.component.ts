import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'LangDriverTestAngular';
  isLoged:boolean = false;
  isAdmin:boolean;
  userName: string;
  constructor(){}

  logOut(){
    this.isLoged = false;
    localStorage.clear();
  }
}
