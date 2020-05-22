import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { RegisterComponent } from './register/register.component';
import { HttpClientModule } from '@angular/common/http';
import { AuthenticationService } from './_service/Authentication.service';
import { RouterModule } from '@angular/router';
import { BrowseComponent } from './browse/browse.component';
import { PaidTopicsComponent } from './paid-topics/paid-topics.component';
import { TopicDetailComponent } from './topic-detail/topic-detail.component';
import { TeacherComponent } from './teacher/teacher.component';
import { TeacherDatailComponent } from './teacher-datail/teacher-datail.component';
import { TeacherNewTopicComponent } from './teacher-new-topic/teacher-new-topic.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { ErrorInterceptorProvider } from './_service/error.interceptor';
import { AlertifyService } from './_service/alertify.service';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

@NgModule({
   declarations: [
      AppComponent,
      RegisterComponent,
      BrowseComponent,
      PaidTopicsComponent,
      TopicDetailComponent,
      TeacherComponent,
      TeacherDatailComponent,
      TeacherNewTopicComponent,
      NotFoundComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      FormsModule,
      HttpClientModule,
      RouterModule,
      BsDropdownModule.forRoot()
   ],
   providers: [
      AuthenticationService,
      ErrorInterceptorProvider,
      AlertifyService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule {

}
