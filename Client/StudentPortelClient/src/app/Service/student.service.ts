import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiConstant } from '../Common/ApiConstant';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(private httpclient: HttpClient) { }
 public AddStudent(objstudent: any) {
    return this.httpclient.post(ApiConstant.StudentApi.AddStudent ,objstudent);

  }
 public GetAll() {
  return this.httpclient.get(ApiConstant.StudentApi.GetAllStudent);

  }
}
