import { Component, OnInit } from '@angular/core';
import { Student } from '../Model/Student';
import { StudentService } from '../Service/student.service';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.scss']
})
export class StudentComponent implements OnInit {
  public objstudent: Student = new Student();

  constructor(private studentservice: StudentService ) { }

  ngOnInit() {
  }
  AddStudent() {
    console.log(this.objstudent);
    this.studentservice.AddStudent(this.objstudent).subscribe(res => {
      console.log(res);
    } );

}
}
