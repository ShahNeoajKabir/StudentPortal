import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../Model/User';
import { ApiConstant } from '../Common/ApiConstant';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient: HttpClient) { }
  public AddUser(obj: User) {
    return this.httpClient.post(ApiConstant.UserApi.AddUser, obj);
  }
}
