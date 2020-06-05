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
import { SettingComponent } from './setting/setting.component';
import { WishlistComponent } from './wishlist/wishlist.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { JwtModule } from '@auth0/angular-jwt';

export function tokenGetter() {
   return localStorage.getItem('token');
}

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
      NotFoundComponent,
      SettingComponent,
      WishlistComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      FormsModule,
      HttpClientModule,
      RouterModule,
      BrowserAnimationsModule,
      BsDropdownModule.forRoot(),
      JwtModule.forRoot({
         config: {
            // tslint:disable-next-line:object-literal-shorthand
            tokenGetter: tokenGetter,
            whitelistedDomains: ['localhost:5000'],
            blacklistedRoutes: [
               'localhost:5000/Auth/login',
               'localhost:5000/Auth/register'
            ]
         }
      })
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
