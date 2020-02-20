import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashbordComponent } from './dashbord/dashbord.component';
import { LoginComponent } from './login/login.component';
import { UserComponent } from './user/user.component';
import { ViewUserComponent } from './view-user/view-user.component';
import { StudentComponent } from './student/student.component';
import { ViewStudentComponent } from './view-student/view-student.component';




const routes: Routes = [
  {path: 'Dashbord' , component: DashbordComponent},
  {path: 'Login' , component: LoginComponent},
  {path: 'User' , component: UserComponent},
  { path: '.id/edit', component: ViewUserComponent },
  {path: 'ViewUser' , component: ViewUserComponent},
  {path: 'AddStudent' , component: StudentComponent},
  {path: 'ViewStudent' , component: ViewStudentComponent}



];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
