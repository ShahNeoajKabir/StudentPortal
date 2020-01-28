import { Component, OnInit } from '@angular/core';
import { NotificationService } from 'src/app/services/notification.service';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { VmLogin } from 'src/app/Models/Login';
import { CryptoService } from 'src/app/services/crypto.service';
import { UserIdleService } from 'angular-user-idle';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public loginForm;
  public isLogin = false;

  constructor(
    private notification: NotificationService,
    private router: Router,
    private authSevice: AuthService,
    private cryptoService: CryptoService,
    private userIdleService: UserIdleService
  ) { }

  ngOnInit() {

    this.userIdleService.stopWatching();

    if (this.authSevice.checkLogged()) {
       this.router.navigate(['dashboard']);
    }
    this.initForm();
  }

  private initForm()
  {
    this.loginForm = new FormGroup({
      userName : new FormControl('', Validators.required),
      password: new FormControl('' , Validators.required)
    })
  }

  public Login(data: any) {
    this.isLogin = true;
    if(data.userName === '' || data.password === '') {
      this.notification.warn('Warning!', 'Username or password is required');
      this.isLogin = false;
    } else {

      this.cryptoService.encrypt(data.password).then((chiperText : string) => {
        this.authSevice.login( new VmLogin(data.userName, chiperText))
          .subscribe((res: void) => {
            this.router.navigate(['dashboard']);
            this.isLogin = false;
          }, error => {
            this.isLogin = false;
            try {
              this.notification.dynamic(error);
            } catch (error) {
              this.notification.error('Failed', 'Internal Server Problem');
            }
          });
      }, error => {
        console.log(error);
      });
    }
  }

}
