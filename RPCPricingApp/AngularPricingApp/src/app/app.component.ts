import { Component, OnInit } from '@angular/core';
import { LoginService } from './login/shared/login.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [LoginService],
})
export class AppComponent {

  title = 'RPC Pricing App';

  constructor(private loginService:LoginService){
    
  }


}
