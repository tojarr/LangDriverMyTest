import { Injectable } from '@angular/core';
import { BaseHttpService } from '../core/basehttp.service';
import { urls } from '../core/urls';

@Injectable()
export class RegistrationService extends BaseHttpService {
    Registration(body){
        console.log('RegistrationService');
        return this.post(urls.regUrl, body).map(response => response.json());
    }
}