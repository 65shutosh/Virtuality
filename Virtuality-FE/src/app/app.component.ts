import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from './_service/Authentication.service';
import { AlertifyService } from './_service/alertify.service';

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
  userName: any;

  constructor(public authService: AuthenticationService, private alertify: AlertifyService) { }
  ngOnInit(): void {
    // console.log(this.authService.loggedIn());
    // if (this.authService.loggedIn()) {
    //   this.userName = this.authService.decodeToken().unique_name;
    // }
    //  console.log(this.authService.decodeToken());
    // console.log('after refresh -' + this.userName);
  }

  login() {
    this.authService.login(this.loginModule).subscribe(
      res => {
        // console.log(res);
        this.alertify.success('loggin successfull');
      },
      err => {
        this.alertify.error('loggin unsuccessfull');
        // console.log(err);
      }
    );
  }

  loggedIn() {
    // const token = localStorage.getItem('token');
    // console.log(this.authService.loggedIn());
    // return !!token;
    return this.authService.loggedIn();
  }

  logOut() {
    localStorage.removeItem('token');
    this.alertify.message('logged out');
    // console.log('log-out successfull');
  }

}
