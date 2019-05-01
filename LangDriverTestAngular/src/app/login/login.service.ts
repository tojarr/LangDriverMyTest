import { Injectable } from '@angular/core';

import { Observable } from 'rxjs/Observable';
import '../rxjs-extensions';

import { urls } from '../core/urls';
import { BaseHttpService } from '../core/basehttp.service';

@Injectable()
export class LoginService extends BaseHttpService {

    Login(login:string, password:string){
        const body = {login: login, password: password};
         return this.post(urls.loginDomain , body).map(response => response.json());
       }
}