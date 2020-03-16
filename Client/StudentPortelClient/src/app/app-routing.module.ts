import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { UserComponent } from './user/user.component';
import { ViewUserComponent } from './view-user/view-user.component';
import { ViewStudentComponent } from './Co-Ordinator/view-student/view-student.component';
import { ViewParentsComponent } from './Co-Ordinator/view-parents/view-parents.component';
import { ViewCourseComponent } from './Co-Ordinator/view-course/view-course.component';
import { TeacherComponent } from './Co-Ordinator/teacher/teacher.component';
import { ViewTeacherComponent } from './Co-Ordinator/view-teacher/view-teacher.component';
import { AppComponent } from './app.component';
import { ViewSemesterComponent } from './Co-Ordinator/view-semester/view-semester.component';
import { AuthGuard } from '../app/Service/auth/auth.guard';
import { StudentDashBoardComponent } from './Students/student-dash-board/student-dash-board.component';
import { ViewStudentProfileComponent } from './Students/view-student-profile/view-student-profile.component';
import { StudentRegisteredCourseComponent } from './Students/student-registered-course/student-registered-course.component';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { LayoutComponent } from './Co-Ordinator/layout/layout.component';
import { StudentComponent } from './Co-Ordinator/student/student.component';
import { ParentsComponent } from './Co-Ordinator/parents/parents.component';
import { SemesterComponent } from './Co-Ordinator/semester/semester.component';
import { CourseComponent } from './Co-Ordinator/course/course.component';



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
// {
//   path: 'Dashbord',
//   component: LayoutComponent,
//   children: [

//       { path: '', component: DashbordComponent, canActivate: [AuthGuard] }


//   ]
// },
// {
//   path: 'student',
//   component: LayoutComponent,
//   children: [
//       { path: ':id/edit', component: StudentComponent, canActivate: [AuthGuard] },
//       { path: 'new', component: StudentComponent, canActivate: [AuthGuard] },
//       { path: 'View', component: ViewStudentComponent, canActivate: [AuthGuard] }


//   ]
// },
// {
//   path: 'parents',
//   component: LayoutComponent,
//   children: [
//       { path: ':id/edit', component: ParentsComponent, canActivate: [AuthGuard] },
//       { path: 'new', component: ParentsComponent, canActivate: [AuthGuard] },
//       { path: 'View', component: ViewParentsComponent, canActivate: [AuthGuard] }


//   ]
// },
// {
//   path: 'teacher',
//   component: LayoutComponent,
//   children: [
//       { path: ':id/edit', component: TeacherComponent, canActivate: [AuthGuard] },
//       { path: 'new', component: TeacherComponent, canActivate: [AuthGuard] },
//       { path: 'View', component: ViewTeacherComponent, canActivate: [AuthGuard] }


//   ]
// },
// {
//   path: 'course',
//   component: LayoutComponent,
//   children: [
//       { path: ':id/edit', component: CourseComponent, canActivate: [AuthGuard] },
//       { path: 'new', component: CourseComponent, canActivate: [AuthGuard] },
//       { path: 'View', component: ViewCourseComponent, canActivate: [AuthGuard] }


//   ]
// },
// Co-Ordinator Dashboard

{
  path: 'Co-Ordinator',
  component: LayoutComponent,
  children: [
      { path: ':id/editsemester', component: SemesterComponent, canActivate: [AuthGuard] },
      { path: 'newsemester', component: SemesterComponent, canActivate: [AuthGuard] },
      { path: 'Viewsemester', component: ViewSemesterComponent, canActivate: [AuthGuard] },

      { path: ':id/editcourse', component: CourseComponent, canActivate: [AuthGuard] },
      { path: 'newcourse', component: CourseComponent, canActivate: [AuthGuard] },
      { path: 'Viewcourse', component: ViewCourseComponent, canActivate: [AuthGuard] },

      { path: ':id/editteacher', component: TeacherComponent, canActivate: [AuthGuard] },
      { path: 'newteacher', component: TeacherComponent, canActivate: [AuthGuard] },
      { path: 'Viewteacher', component: ViewTeacherComponent, canActivate: [AuthGuard] },

      { path: ':id/editparents', component: ParentsComponent, canActivate: [AuthGuard] },
      { path: 'newparents', component: ParentsComponent, canActivate: [AuthGuard] },
      { path: 'Viewparents', component: ViewParentsComponent, canActivate: [AuthGuard] },

      { path: ':id/editstudent', component: StudentComponent, canActivate: [AuthGuard] },
      { path: 'newstudent', component: StudentComponent, canActivate: [AuthGuard] },
      { path: 'Viewstudent', component: ViewStudentComponent, canActivate: [AuthGuard] },

      { path: 'ChangePassword', component: ChangePasswordComponent, canActivate: [AuthGuard] }
      // { path: '', component: DashbordComponent, canActivate: [AuthGuard] }



  ]
},

// Student Dashboard
{
  path: 'Student',
  component: StudentDashBoardComponent,
  children: [
      { path: ':id/edit', component: StudentComponent, canActivate: [AuthGuard] },
      { path: 'RegisteredCourse', component: StudentRegisteredCourseComponent, canActivate: [AuthGuard] },
      { path: 'Profile', component: ViewStudentProfileComponent, canActivate: [AuthGuard] },
      { path: 'ChangePassword', component: ChangePasswordComponent, canActivate: [AuthGuard] }



  ]
},

// Co-Ordinator Dashboard
// {
//   path: 'Co-Ordinator',
//   component: StudentDashBoardComponent,
//   children: [
//       { path: ':id/edit', component: StudentComponent, canActivate: [AuthGuard] },
//       { path: 'RegisteredCourse', component: StudentRegisteredCourseComponent, canActivate: [AuthGuard] },
//       { path: 'Profile', component: ViewStudentProfileComponent, canActivate: [AuthGuard] },
//       { path: 'ChangePassword', component: ChangePasswordComponent, canActivate: [AuthGuard] }



//   ]
// },

{ path: '', redirectTo: 'Login', pathMatch: 'full' }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
