import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';

import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { TokenService } from './token.service';
import { VMLogin } from 'src/app/Model/VMLogin';
import { ApiConstant } from 'src/app/Common/ApiConstant';

@Injectable({
  providedIn: 'root'
})

export class AuthService {

  constructor(
    private http: HttpClient,
    private tokenService: TokenService,
    private router: Router
  ) { }


  login(authData: VMLogin) {
    const body = {
      Username: authData.UserName,
      Password: authData.Password
    };
    return this.http.post(ApiConstant.AccountApi.Login, body).pipe(map((res: any) => {
      const loginData = res;
      this.tokenService.SaveToken(loginData.Token);
    }));

  }

  public removeToken() {
    this.tokenService.RemoveToken();
    this.router.navigate(['Login']);
  }

  checkLogged() {
    if (this.tokenService.GetToken()) {
      return !this.tokenService.isTokenExpired();
    } else {
      return false;
    }
  }
  getLoggedUsername() {
    if (this.tokenService.GetToken()) {
      return this.tokenService.GetTokenValue('unique_name');
    }
    return '';
  }

  getLoggedUserType(): number {
    if (this.tokenService.GetToken()) {
      return  Number(this.tokenService.GetTokenValue('user_type'));
    }
    return 0;
  }

  getLoggedEmail() {
    if (this.tokenService.GetToken()) {
      return this.tokenService.GetTokenValue('email');
    }
    return '';
  }
}
