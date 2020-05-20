import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from './_service/Authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  loginModule: any = {
    username: '',
    password: ''
  };

  constructor(private authService: AuthenticationService) { }
  ngOnInit(): void {
  }

  login() {
    this.authService.login(this.loginModule).subscribe(
      res => {
        console.log('loggin successfull');
        console.log(res);
      },
      err => {
        console.log('loggin unsuccessfull');
        console.log(err);
      }
    );
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !!token;
  }

  logOut() {
    localStorage.removeItem('token');
    console.log('log-out successfull');
  }

}
