import { Injectable } from '@angular/core';
import { LoginData } from './login-data.model';
import { Http, Response, Headers, RequestMethod, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  loggedIn:boolean = false;
  loginData:LoginData;
  private apiUrl:string = 'http://localhost:51063/api/Login/';

  constructor(private http:Http) { }

  login(){
    var body = JSON.stringify(this.loginData);
    var headerOptions = new Headers({'Content-Type':'application/json'});
    var requestOptions = new RequestOptions({method : RequestMethod.Post, headers : headerOptions});
    return this.http.post(this.apiUrl, body, requestOptions).map(x=> x.json());
  }

}
