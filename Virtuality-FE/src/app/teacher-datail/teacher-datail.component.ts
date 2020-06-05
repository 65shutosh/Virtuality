import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../_service/Authentication.service';
import { Teacher } from '../_models/Teacher';
import { AlertifyService } from '../_service/alertify.service';

@Component({
  selector: 'app-teacher-datail',
  templateUrl: './teacher-datail.component.html',
  styleUrls: ['./teacher-datail.component.css']
})
export class TeacherDatailComponent implements OnInit {

  teacherRegModel: Teacher = {
    name: '',
    contactNumber: '',
    address: '',
    zip: 0,
    account: {
      bank: '',
      accountHolderName: '',
      accountNumber: '',
      IFSC: ''
    },
    userId: 0
  };

  constructor(private authService: AuthenticationService, private alertify: AlertifyService) { }

  ngOnInit() {
  }

  register(teacherFormData) {
    this.teacherRegModel.userId = this.authService.decodeToken().nameid;
    this.authService.teacherRegistration(this.teacherRegModel).subscribe(
      res => {
        this.alertify.success('Teacher Registration SuccessFull');
        teacherFormData.resetForm();
        //  console.log(res.status);
      },
      err => {
        this.alertify.error('Teacher Registation Unsuccessfull');
        console.log(err);
      }
    );
  }

}
