import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';


@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {


  private BASE_URL = 'http://localhost:5000/Auth/';
  jwtHelper = new JwtHelperService();
 // decodedToken: any;

  constructor(private http: HttpClient) { }

  // login Authentication
  login(model: any) {
    return this.http.post(this.BASE_URL + 'login', model)
      .pipe(
        map((response: any) => {
          const user = response;
          if (user) {
            localStorage.setItem('token', user.token);
            // this.decodedToken = this.decodeToken();
            // console.log('from login - ');
            // console.log(this.decodedToken);
          }
        }
        )
      );
  }

  // Not Validating here because caller will be validating
  // that if token is available or if user is logged In
  decodeToken() {
    return this.jwtHelper.decodeToken(localStorage.getItem('token'));
  }

  // User Registration
  register(model: any) {
    return this.http.post(this.BASE_URL + 'register', model);
  }


  loggedIn() {
      return !this.jwtHelper.isTokenExpired(localStorage.getItem('token'));
  }

  isTeacher() {
     if ( this.decodeToken().role === 'Teacher') {
      return true;
     }
     return false;
  }
  // user teacher-details registration

}
