import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { VMLogin } from '../Model/VMLogin';
import { ApiConstant } from '../Common/ApiConstant';
@Injectable({
  providedIn: 'root'
})



export class SecurityService {


  constructor(private httpClient: HttpClient) { }
  public AddAccount(obj: VMLogin) {
    return this.httpClient.post(ApiConstant.AccountApi.Login, obj);
  }
}
