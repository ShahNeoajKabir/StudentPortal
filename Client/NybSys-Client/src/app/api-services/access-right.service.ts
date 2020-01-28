import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiConstant } from '../common/Constant/APIConstant';

@Injectable({
  providedIn: 'root'
})
export class AccessRightService {

  constructor(private http : HttpClient) { }

  public GetAllAccessRight() {
    return this.http.post(ApiConstant.AccessRight.GetAllAccessRight, "");
  }

  public GetAccessRightByRole(roleName: string) {
    return this.http.post(ApiConstant.AccessRight.GetAllAccessRightByRole, roleName);
  }
}