import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../_service/Authentication.service';

@Component({
  selector: 'app-teacher',
  templateUrl: './teacher.component.html',
  styleUrls: ['./teacher.component.css']
})
export class TeacherComponent implements OnInit {


  isTeacher: boolean ;
  constructor(private authenticationService: AuthenticationService) { }


  ngOnInit() {
    this.isTeacher =  this.authenticationService.isTeacher();
  }

}
