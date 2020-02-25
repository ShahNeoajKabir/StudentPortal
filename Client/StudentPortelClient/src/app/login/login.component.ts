import { Component, OnInit } from '@angular/core';
import { VMLogin } from '../Model/VMLogin';
import { SecurityService } from '../Service/security.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  objLogin: VMLogin = new VMLogin();

  constructor(private Securityservice: SecurityService, private router: Router) { }

  ngOnInit() {
  }

  Login() {
    this.Securityservice.AddAccount(this.objLogin).subscribe(res => {

      // tslint:disable-next-line:triple-equals
      if ( res == 1) {
        this.router.navigate(['/Dashbord']);
      }
      console.log(res);

    });
  }

}
