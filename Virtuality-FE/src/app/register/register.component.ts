import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../_service/Authentication.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private authService: AuthenticationService) { }


  registrationModel: any = {
    username: '',
    email: '',
    password: '',
    rpassword: ''
  };

  ngOnInit(): void {
  }




  register(myForm) {
    this.authService.register(this.registrationModel).subscribe(
      res => {
        console.log(res);
        alert('registration successfull');
        myForm.reset();
      },
      err => {
        if (err.status === 400) {
          alert(err.error);
        }
        console.log(err);
        alert('registration unsuccessfull');
      }
    );
  }

}
