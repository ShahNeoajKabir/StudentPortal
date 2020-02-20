import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashbordComponent } from './dashbord/dashbord.component';
import { LoginComponent } from './login/login.component';
import { UserComponent } from './user/user.component';




const routes: Routes = [
  {path: 'Dashbord' , component: DashbordComponent},
  {path: 'Login' , component: LoginComponent},
  {path: 'User' , component: UserComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
