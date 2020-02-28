import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpResponse } from '@angular/common/http';
import { RequestMessage } from '../Model/RequestMessage';
import { LoaderService } from './loader.service';
import { finalize, tap } from 'rxjs/operators';
import { AuthService } from '../Service/auth/auth.service';
import { NotificationService } from '../Common/notification.service';
@Injectable({
  providedIn: 'root'
})
export class RequestInterceptorService {

  constructor(private loaderService: LoaderService,
              private auth: AuthService,
              private notification: NotificationService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    const requestMessage =
      new RequestMessage(this.auth.getLoggedUsername(),
        0, req.body, this.auth.getLoggedUserType());
    const customReq = req.clone({
      body: requestMessage
    });
    console.log(customReq);
    this.loaderService.startLoader();
    return next.handle(customReq).pipe(
      tap(event => {
        if (event instanceof HttpResponse) {
          console.log(event);
        }
      }
      , error => {
        this.notification.dynamic(error);
      }
      ),
      finalize(() => {
        this.loaderService.stopLoader();
      }));
  }
}
