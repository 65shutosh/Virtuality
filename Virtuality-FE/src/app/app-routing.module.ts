import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { BrowseComponent } from './browse/browse.component';
import { TeacherComponent } from './teacher/teacher.component';
import { TeacherDatailComponent } from './teacher-datail/teacher-datail.component';
import { TeacherNewTopicComponent } from './teacher-new-topic/teacher-new-topic.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { SettingComponent } from './setting/setting.component';
import { WishlistComponent } from './wishlist/wishlist.component';


const routes: Routes = [
  {
    path: 'teacher',
    component: TeacherComponent,
    children: [
      {
        path: 'registration',
        component: TeacherDatailComponent
      },
      {
        path: 'newTopic',
        component: TeacherNewTopicComponent
      }
    ]
  },
  {
    path: 'home',
    component: HomeComponent
  },
  {
    path: 'browse',
    component: BrowseComponent
  },
  {
    path: 'settings',
    component: SettingComponent
  },
  {
    path: 'wishlist',
    component: WishlistComponent
  },
  {
    path: '**',
    component: HomeComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
