import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiConstant } from '../Common/ApiConstant';

@Injectable({
  providedIn: 'root'
})
export class TeacherService {

  constructor(private httpclient: HttpClient) { }
  public AddTeacher(objteacher: any) {
    return this.httpclient.post(ApiConstant.TeacherApi.AddTeacher, objteacher);

  }
  public GetAllTeacher() {
   return this.httpclient.get(ApiConstant.TeacherApi.GetAllTeacher);
  }
  public UpdateTeacher(objteacher: any) {
    return this.httpclient.post(ApiConstant.TeacherApi.UpdateTeacher , objteacher);
  }
  public GetTeacherById(objteacher: any) {
    return this.httpclient.post(ApiConstant.TeacherApi.GetTeacherById , objteacher);

  }
}
