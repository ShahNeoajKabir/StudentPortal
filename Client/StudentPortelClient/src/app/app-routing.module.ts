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
import { SemesterComponent } from './semester/semester.component';
import { ViewSemesterComponent } from './view-semester/view-semester.component';
import { AuthGuard } from '../app/Service/auth/auth.guard';
import { LayoutComponent } from './layout/layout.component';



const routes: Routes = [
  {path: 'Login' , component: LoginComponent},
  {
    path: 'user',
    component: LayoutComponent,
    children: [
        { path: ':id/edit', component: UserComponent, canActivate: [AuthGuard] },
        { path: 'new', component: UserComponent, canActivate: [AuthGuard] },
        { path: 'View', component: ViewUserComponent, canActivate: [AuthGuard] }
    ]
},
{
  path: 'Dashbord',
  component: LayoutComponent,
  children: [

      { path: '', component: DashbordComponent, canActivate: [AuthGuard] }


  ]
},
{
  path: 'student',
  component: LayoutComponent,
  children: [
      { path: ':id/edit', component: StudentComponent, canActivate: [AuthGuard] },
      { path: 'new', component: StudentComponent, canActivate: [AuthGuard] },
      { path: 'View', component: ViewStudentComponent, canActivate: [AuthGuard] }


  ]
},
{
  path: 'parents',
  component: LayoutComponent,
  children: [
      { path: ':id/edit', component: ParentsComponent, canActivate: [AuthGuard] },
      { path: 'new', component: ParentsComponent, canActivate: [AuthGuard] },
      { path: 'View', component: ViewParentsComponent, canActivate: [AuthGuard] }


  ]
},
{
  path: 'teacher',
  component: LayoutComponent,
  children: [
      { path: ':id/edit', component: TeacherComponent, canActivate: [AuthGuard] },
      { path: 'new', component: TeacherComponent, canActivate: [AuthGuard] },
      { path: 'View', component: ViewTeacherComponent, canActivate: [AuthGuard] }


  ]
},
{
  path: 'course',
  component: LayoutComponent,
  children: [
      { path: ':id/edit', component: CourseComponent, canActivate: [AuthGuard] },
      { path: 'new', component: CourseComponent, canActivate: [AuthGuard] },
      { path: 'View', component: ViewCourseComponent, canActivate: [AuthGuard] }


  ]
},
{
  path: 'semester',
  component: LayoutComponent,
  children: [
      { path: ':id/edit', component: SemesterComponent, canActivate: [AuthGuard] },
      { path: 'new', component: SemesterComponent, canActivate: [AuthGuard] },
      { path: 'View', component: ViewSemesterComponent, canActivate: [AuthGuard] }


  ]
},

{ path: '', redirectTo: 'Login', pathMatch: 'full' }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
