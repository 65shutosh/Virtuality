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

  constructor(private authService: AuthenticationService , private alertify: AlertifyService) { }
  ngOnInit(): void {
  }

  login() {
    this.authService.login(this.loginModule).subscribe(
      res => {
        this.alertify.success('loggin successfull');
        // console.log(res);
      },
      err => {
        this.alertify.error('loggin unsuccessfull');
        // console.log(err);
      }
    );
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !!token;
  }

  logOut() {
    localStorage.removeItem('token');
    this.alertify.message('logged out');
    // console.log('log-out successfull');
  }

}
