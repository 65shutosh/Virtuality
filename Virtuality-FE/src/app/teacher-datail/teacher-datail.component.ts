import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../_service/Authentication.service';
import { Teacher } from '../_models/Teacher';

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

  constructor(private authService: AuthenticationService) { }

  ngOnInit() {
  }

register( teacherFormData ) {
  this.teacherRegModel.userId = this.authService.decodeToken().nameid;
  this.authService.teacherRegistration(this.teacherRegModel).subscribe(
    res => {
      console.log('res');
    //  console.log(res.status);
    },
    err => {
      console.log('ERR');
      console.log(err);
    }
  );
}

}
