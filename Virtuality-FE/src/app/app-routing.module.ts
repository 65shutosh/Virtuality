import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TeacherDetailsComponent } from './teacher-details/teacher-details.component';
import { HomeComponent } from './home/home.component';


const routes: Routes = [
  {
    path: 'teachersDetail',
    component: TeacherDetailsComponent
  },
  {
    path: 'home',
    component: HomeComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
