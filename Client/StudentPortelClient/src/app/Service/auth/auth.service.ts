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
  //  return this.http.post(ApiConstant.AccountApi.Login, body).pipe(map((res: any) => {
  //                       const loginData = res;
  //                         this.tokenService.SaveToken(loginData.Token);
  //  }));

  }

  // public CloseSession(sessionId: number): Observable<string> {
  //     return this.authHttp.post(ConstantAPI.AuthAPI.CloseSession, this.requestMessageService.GetRequestMessageWithOutObj(sessionId))
  //       .map(res => res.json());
  // }

  /* Method for logout and remove token
  * @Parameter No parameter
  * @Return Boolean
  */

  // logout() {
  //  return this.authHttp.post(ConstantAPI.AuthAPI.Logout, this.requestMessageService.GetRequestMessageWithOutObj("logout"))
  //     .map(res => res.json());
  // }

  public removeToken() {
    this.tokenService.RemoveToken();
    this.router.navigate(['Login']);
  }

  /* Method for registration in the system
  * @Parameter No parameter
  * @Return Boolean
  */
  // registration(data: any) {
  //     return this.http.post(this.serverPath + '/api/account/registration', data);
  // }

  /* Method for change password
  * @Parameter newPassword, confirmPassword
  * @Return Response message from serve
  */
  // changePassword(changePasswordData: ChangePassword) {
  //   return this.http.post(ApiConstant.AuthenticationApi.ChangePassword, changePasswordData);
  // }

  /* Method for request reset password when forgot password
  * @Parameter user email
  * @Return Response string
  */
  // forgotPassword(data) {
  //   return this.http.post(this.serverPath + '', data).map(response => response.json());
  // }

  /* Method for Reset password
  * @Parameter email, new password, confirm password
  * @Return Response string
  */
  // resetPassword(data: ResetPassword) {
  //   return this.http.post(ApiConstant.AuthenticationApi.ResetPassword, data);
  // }

  /* Method for Checked that claimed user is authenticate or not ?
  * @Parameter No parameter
  * @Return Boolean
  */
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
