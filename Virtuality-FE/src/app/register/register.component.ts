import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../_service/Authentication.service';
import { AlertifyService } from '../_service/alertify.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private authService: AuthenticationService, private alertify: AlertifyService) { }


  registrationModel: any = {
    username: '',
    email: '',
    password: '',
    rpassword: ''
  };

  ngOnInit(): void {
  }




  register(myForm) {
    if ((this.registrationModel.password).localeCompare(this.registrationModel.rpassword) === 0) {
    this.authService.register(this.registrationModel).subscribe(
      res => {
        console.log(res);
       // alert('registration successfull');
        this.alertify.success('registration successfull');
        myForm.resetForm();
      },
      err => {
        // if (err.status === 400) {
        //   alert(err.error);
        // }
        console.log(err);
        this.alertify.error('registration unsuccessfull');
      }
    );
    } else {
      this.alertify.error(' registration is not processed as passwords do not match');
    }
  }

}
