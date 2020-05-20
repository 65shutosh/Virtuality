import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { RegisterComponent } from './register/register.component';
import { TeacherDetailsComponent } from './teacher-details/teacher-details.component';
import { HttpClientModule } from '@angular/common/http';
import { AuthenticationService } from './_service/Authentication.service';
import { RouterModule } from '@angular/router';
import { BrowseComponent } from './browse/browse.component';
import { PaidTopicsComponent } from './paid-topics/paid-topics.component';
import { TopicDetailComponent } from './topic-detail/topic-detail.component';

@NgModule({
   declarations: [
      AppComponent,
      RegisterComponent,
      TeacherDetailsComponent,
      BrowseComponent,
      PaidTopicsComponent,
      TopicDetailComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      FormsModule,
      HttpClientModule,
      RouterModule
   ],
   providers: [
      AuthenticationService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule {

}
