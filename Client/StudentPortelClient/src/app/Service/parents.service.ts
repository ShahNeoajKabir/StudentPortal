import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiConstant } from '../Common/ApiConstant';

@Injectable({
  providedIn: 'root'
})
export class ParentsService {

  constructor(private httpclient: HttpClient) { }
  public AddParents(objparentrs: any) {
    return this.httpclient.post(ApiConstant.ParentsApi.AddParents, objparentrs);

  }
  public GetAllParents() {
    return this.httpclient.get(ApiConstant.ParentsApi.GetAllParents);
    }
}
