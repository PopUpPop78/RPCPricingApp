import { Component, OnInit } from '@angular/core';
import { LoginService } from './shared/login.service';
import { LoginData } from './shared/login-data.model';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginFailedMessage: string = '';

  constructor(private loginService:LoginService) { }

  ngOnInit() {
    this.resetForm();
  }

  onSubmit(form: NgForm){
    this.loginFailedMessage = '';
    this.loginService.login(this.loginService.loginData).subscribe(data=>{
      this.loginService.loggedIn = data;
      if(!data)
        this.loginFailedMessage = 'Login failed for ' + this.loginService.loginData.Username;
    });
  }
  resetForm(form?:NgForm){
    if(form != null)
      form.reset();
    this.loginService.loginData = new LoginData();
  }

}
