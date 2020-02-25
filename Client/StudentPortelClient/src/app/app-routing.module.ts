import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashbordComponent } from './dashbord/dashbord.component';
import { LoginComponent } from './login/login.component';
import { UserComponent } from './user/user.component';
import { ViewUserComponent } from './view-user/view-user.component';
import { StudentComponent } from './student/student.component';
import { ViewStudentComponent } from './view-student/view-student.component';
import { ParentsComponent } from './parents/parents.component';
import { ViewParentsComponent } from './view-parents/view-parents.component';
import { CourseComponent } from './course/course.component';
import { ViewCourseComponent } from './view-course/view-course.component';
import { TeacherComponent } from './teacher/teacher.component';
import { ViewTeacherComponent } from './view-teacher/view-teacher.component';
import { AppComponent } from './app.component';




const routes: Routes = [
  {path: 'Dashbord' , component: DashbordComponent},
  {path: 'Login' , component: LoginComponent},
  {
    path: 'user',
    component: AppComponent,
    children: [
        { path: ':id/edit', component: UserComponent },
        { path: 'new', component: UserComponent },
        { path: 'View', component: ViewUserComponent }


    ]
},
{
  path: 'student',
  component: AppComponent,
  children: [
      { path: ':id/edit', component: StudentComponent },
      { path: 'new', component: StudentComponent },
      { path: 'View', component: ViewStudentComponent }


  ]
},
{
  path: 'parents',
  component: AppComponent,
  children: [
      { path: ':id/edit', component: ParentsComponent },
      { path: 'new', component: ParentsComponent },
      { path: 'View', component: ViewParentsComponent }


  ]
},
{
  path: 'teacher',
  component: AppComponent,
  children: [
      { path: ':id/edit', component: TeacherComponent },
      { path: 'new', component: TeacherComponent },
      { path: 'View', component: ViewTeacherComponent }


  ]
},
{
  path: 'course',
  component: AppComponent,
  children: [
      { path: ':id/edit', component: CourseComponent },
      { path: 'new', component: CourseComponent },
      { path: 'View', component: ViewCourseComponent }


  ]
},



];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
