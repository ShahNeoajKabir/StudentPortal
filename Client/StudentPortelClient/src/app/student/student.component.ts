import { Component, OnInit } from '@angular/core';
import { Student } from '../Model/Student';
import { StudentService } from '../Service/student.service';
import { Router } from '@angular/router';
import { Gender, Status } from '../Common/Enum';
import { Utility } from '../Common/Utility';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.scss']
})
export class StudentComponent implements OnInit {
  public objstudent: Student = new Student();
  public lstGender: any;
  public lstStatus: any;


  constructor(private studentservice: StudentService , private router: Router , private utility: Utility) { }

  ngOnInit() {
    this.lstGender = this.utility.enumToArray(Gender);
    this.lstStatus = this.utility.enumToArray(Status);

  }
  AddStudent() {
    console.log(this.objstudent);
    this.studentservice.AddStudent(this.objstudent).subscribe(res => {
      console.log(res);
    } );
}



}
