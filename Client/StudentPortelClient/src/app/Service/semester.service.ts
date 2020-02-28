import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiConstant } from '../Common/ApiConstant';

@Injectable({
  providedIn: 'root'
})
export class SemesterService {

  constructor(private httpclient: HttpClient) { }
  public AddSemester(objsemester: any) {
    return this.httpclient.post(ApiConstant.SemesterApi.AddSemester , objsemester);

  }
  public GetAll() {
    return this.httpclient.get(ApiConstant.SemesterApi.ViewSemester);
  }
  public UpdateSemester(objsemester: any) {
    return this.httpclient.post(ApiConstant.SemesterApi.UpdateSemester, objsemester);
  }
  public GetById(objsemester: any) {
    return this.httpclient.post(ApiConstant.SemesterApi.GetTeacherById, objsemester);
  }
}
