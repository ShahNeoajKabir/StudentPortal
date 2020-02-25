import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashbordComponent } from './dashbord/dashbord.component';
import { LoginComponent } from './login/login.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
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
    ViewTeacherComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
