import { Injectable } from '@angular/core';
import { Http, RequestOptionsArgs, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'src/environments/environment'
import { urls } from './urls';
import 'rxjs/add/operator/map';


@Injectable()
export class BaseHttpService{
  private key: string;
  private readonly unauthorizedMessage = 'Auth token is expired. Please refresh the app.';

  constructor(private http: Http){}

  private getRequestOptionsArgs(options?: RequestOptionsArgs): RequestOptionsArgs {
    if (options == null) {
      options = new RequestOptions();
    }

    if (options.headers == null) {
      options.headers = new Headers();
    }

    options.headers.set('Content-Type', 'application/json');
    options.headers.set('accept', 'application/json');
    // options.headers.set('auth_token', this.key);

    return options;
  }

  private handleUnauthorized(res: Response): Response {
    if (res.status === 401) {
      throw new Error(this.unauthorizedMessage);
    } else if (res.status < 200 || res.status >= 300) {
      throw new Error(`The request has failed ({res.status})`);
    }

    return res;
  }

  protected get(url: string, options?: RequestOptionsArgs): Observable<Response> {
    return this.http.get(environment.baseAddress + urls.baseAPIDomain + url).map(res => this.handleUnauthorized(res));
  }
  protected post(url: string, body: any, options?: RequestOptionsArgs): Observable<Response> {
    return this.http.post(environment.baseAddress + urls.baseAPIDomain + url, body,
      this.getRequestOptionsArgs(options)).map(res => this.handleUnauthorized(res));
  }

  protected put(url: string, body: any, options?: RequestOptionsArgs): Observable<Response> {
    return this.http.put(environment.baseAddress + urls.baseAPIDomain + url, body,
      this.getRequestOptionsArgs(options)).map(res => this.handleUnauthorized(res));
  }

  protected delete(url: string, options?: RequestOptionsArgs): Observable<Response> {
    return this.http.delete(environment.baseAddress + urls.baseAPIDomain + url,
      this.getRequestOptionsArgs(options)).map(res => this.handleUnauthorized(res));
  }
}