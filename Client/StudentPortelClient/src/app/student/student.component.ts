import { Component, OnInit } from '@angular/core';
import { Student } from '../Model/Student';
import { StudentService } from '../Service/student.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Gender, Status } from '../Common/Enum';
import { Utility } from '../Common/Utility';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.scss']
})
export class StudentComponent implements OnInit {
  public objstudent: Student = new Student();
  public objstudentedit: Student = new Student();
  public StudentId: number;
  public lstGender: any;
  public lstStatus: any;


  constructor(private studentservice: StudentService , private router: Router , private utility: Utility ,
              private ActivateRouter: ActivatedRoute) { }

  ngOnInit() {
    this.lstGender = this.utility.enumToArray(Gender);
    this.lstStatus = this.utility.enumToArray(Status);
    if (this.ActivateRouter.snapshot.params[ 'id'] !== undefined) {
      this.objstudentedit.StudentId = this.ActivateRouter.snapshot.params[ 'id'];
      this.studentservice.GetStudentById(this.objstudentedit).subscribe((res: any) => {
        this.objstudent = res;
        console.log(this.objstudent);

      });
      console.log(this.ActivateRouter.snapshot.params[ 'id']);

    }

  }
  AddStudent() {
    console.log(this.objstudent);
    if (this.objstudent.StudentId > 0) {
      this.studentservice.UpdateStudent(this.objstudent).subscribe(res => {
        if (res === 1) {
          console.log(res);
        }
        console.log(res);
      });

    } else {
      this.studentservice.AddStudent(this.objstudent).subscribe(res => {
        if (res === 1) {
          console.log(res);
        }
        console.log(res);
      });
    }
}



}
