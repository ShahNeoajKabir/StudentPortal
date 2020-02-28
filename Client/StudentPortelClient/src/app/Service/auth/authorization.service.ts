import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})

export class AuthorizationService {

  constructor(
      private authService: AuthService
  ) { }

  IsSuperAdmin() {
    if (this.authService.getLoggedUserType() === 1) {
        return true;
    }
    return false;
  }

  IsAdmin() {
    if (this.authService.getLoggedUserType() === 2) {
        return true;
    }
    return false;
  }

  IsPumpOperator() {
    if (this.authService.getLoggedUserType() === 4) {
        return true;
    }
    return false;
  }

  IsDataOperator() {
    if (this.authService.getLoggedUserType() === 5) {
        return true;
    }
    return false;
  }

  IsGovtAdmin() {
    if (this.authService.getLoggedUserType() === 3) {
        return true;
    }
    return false;
  }

}
