import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {


  private BASE_URL = 'http://localhost:5000/Auth/';

  constructor(private http: HttpClient) { }

  // login Authentication
  login(model: any) {
    return this.http.post(this.BASE_URL + 'login', model)
      .pipe(
        map((response: any) => {
          const user = response;
          if (user) {
            localStorage.setItem('token', user.token);
          }
        }
        )
      );
  }

  // User Registration
  register(model: any) {
    return this.http.post(this.BASE_URL + 'register', model);
  }

  // user teacher-details

}
