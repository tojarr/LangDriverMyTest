import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule} from '@angular/forms';
//import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { from } from 'rxjs';
import { LoginComponent } from './login/login.component';
import { routing } from './app.routing';
import { EditDictionaryComponent } from './edit-dictionary/edit-dictionary.component';
import { HttpModule } from '@angular/http';
import { BaseHttpService } from './core/basehttp.service';
import { EditDictionaryService } from './edit-dictionary/edit-dictionary.service';
import { LoginService } from './login/login.service';
import { RegistrationComponent } from './registration/registration.component';
import {RegistrationService} from './registration/registration.service'

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    EditDictionaryComponent,
    RegistrationComponent
  ],
  imports: [
    BrowserModule,
    // AppRoutingModule,
    HttpModule,
    FormsModule,
    routing
  ],
  providers: [BaseHttpService, 
              EditDictionaryService,
              LoginService,
              RegistrationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
