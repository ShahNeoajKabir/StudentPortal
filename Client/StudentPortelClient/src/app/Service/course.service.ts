import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiConstant } from '../Common/ApiConstant';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  constructor(private httpclient: HttpClient) { }
  public AddCourse(objcourse: any) {
   return this.httpclient.post(ApiConstant.CourseApi.AddCourse , objcourse);

  }
  public GetAll() {
    return this.httpclient.get(ApiConstant.CourseApi.GetAllCourse);
  }
  public UpdateCourse(objcourse: any) {
    return this.httpclient.post(ApiConstant.CourseApi.UpdateCourse, objcourse);
  }
  public GetCourseById(objcourse: any) {
    return this.httpclient.post(ApiConstant.CourseApi.GetCourseById, objcourse);
  }

}
