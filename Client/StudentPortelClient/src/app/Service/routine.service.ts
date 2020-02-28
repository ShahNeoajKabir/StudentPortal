import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiConstant } from '../Common/ApiConstant';

@Injectable({
  providedIn: 'root'
})
export class RoutineService {

  constructor(private httpclient: HttpClient) { }
  public AddRoutine(objroutine: any) {
    return this.httpclient.post(ApiConstant.RoutineApi.AddRoutine , objroutine);
  }
  public GetAll() {
    return this.httpclient.get(ApiConstant.RoutineApi.ViewRoutine);
  }
  public UpdateRoutine(objroutine: any) {
    return this.httpclient.post(ApiConstant.RoutineApi.UpdateRoutine, objroutine);
  }
  public GetById(objroutine: any) {
    return this.httpclient.post(ApiConstant.RoutineApi.GetRoutineById, objroutine);
  }
}
