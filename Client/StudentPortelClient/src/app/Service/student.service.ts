import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiConstant } from '../Common/ApiConstant';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(private httpclient: HttpClient) { }
 public AddStudent(objstudent: any) {
    return this.httpclient.post(ApiConstant.StudentApi.AddStudent , objstudent);

  }
 public GetAllStudent() {
  return this.httpclient.get(ApiConstant.StudentApi.GetAllStudent);
  }
  public UpdateStudent(objstudent: any) {
    return this.httpclient.post(ApiConstant.StudentApi.UpdateStudent, objstudent);
  }
  public GetStudentById(objstudent: any) {
    return this.httpclient.post(ApiConstant.StudentApi.GetStudentById, objstudent);
  }
}
