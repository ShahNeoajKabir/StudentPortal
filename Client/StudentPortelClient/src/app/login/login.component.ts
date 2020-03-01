import { Component, OnInit } from '@angular/core';
import { VMLogin } from '../Model/VMLogin';
import { SecurityService } from '../Service/security.service';
import { Router } from '@angular/router';
import { AuthService } from '../Service/auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  objLogin: VMLogin = new VMLogin();

  constructor(private Securityservice: SecurityService, private router: Router, private authservice: AuthService) { }

  ngOnInit() {
  }

  Login() {
    this.authservice.login(this.objLogin).subscribe(res => {

      // tslint:disable-next-line:triple-equals
        this.router.navigate(['/Dashbord']);

        console.log(res);

    });
  }

}
