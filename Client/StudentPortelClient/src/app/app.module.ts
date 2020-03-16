import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { UserComponent } from './user/user.component';
import { ViewUserComponent } from './view-user/view-user.component';
import { ViewStudentComponent } from './Co-Ordinator/view-student/view-student.component';
import { ViewParentsComponent } from './Co-Ordinator/view-parents/view-parents.component';
import { ViewCourseComponent } from './Co-Ordinator/view-course/view-course.component';
import { TeacherComponent } from './Co-Ordinator/teacher/teacher.component';
import { ViewTeacherComponent } from './Co-Ordinator/view-teacher/view-teacher.component';
import { ViewSemesterComponent } from './Co-Ordinator/view-semester/view-semester.component';
import { httpInterceptorProviders } from './Common/interceptor';
import { ToastrModule } from 'ngx-toastr';
import { StudentDashBoardComponent } from './Students/student-dash-board/student-dash-board.component';
import { TeacherDashBoardComponent } from './Teachers/teacher-dash-board/teacher-dash-board.component';
import { AccountsDashBoardComponent } from './Accounts/accounts-dash-board/accounts-dash-board.component';
import { AdminDashBoardComponent } from './Admin/admin-dash-board/admin-dash-board.component';
import { ViewStudentProfileComponent } from './Students/view-student-profile/view-student-profile.component';
import { StudentRegisteredCourseComponent } from './Students/student-registered-course/student-registered-course.component';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { DashbordComponent } from './Co-Ordinator/dashbord/dashbord.component';
import { StudentComponent } from './Co-Ordinator/student/student.component';
import { ParentsComponent } from './Co-Ordinator/parents/parents.component';
import { CourseComponent } from './Co-Ordinator/course/course.component';
import { SemesterComponent } from './Co-Ordinator/semester/semester.component';
import { LayoutComponent } from './Co-Ordinator/layout/layout.component';




@NgModule({
  declarations: [
    AppComponent,
    DashbordComponent,
    LoginComponent,
    UserComponent,
    ViewUserComponent,
    StudentComponent,
    ViewStudentComponent,
    ParentsComponent,
    ViewParentsComponent,
    CourseComponent,
    ViewCourseComponent,
    TeacherComponent,
    ViewTeacherComponent,
    SemesterComponent,
    ViewSemesterComponent,
    LayoutComponent,
    StudentDashBoardComponent,
    TeacherDashBoardComponent,
    AccountsDashBoardComponent,
    AdminDashBoardComponent,
    ViewStudentProfileComponent,
    StudentRegisteredCourseComponent,
    ChangePasswordComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
  })

  ],
  providers: [httpInterceptorProviders],
  bootstrap: [AppComponent],
  exports: []

})
export class AppModule { }
