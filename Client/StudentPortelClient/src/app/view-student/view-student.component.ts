import { Component, OnInit } from '@angular/core';
import { StudentService } from '../Service/student.service';
import { Student } from '../Model/Student';
import { Router } from '@angular/router';

@Component({
  selector: 'app-view-student',
  templateUrl: './view-student.component.html',
  styleUrls: ['./view-student.component.scss']
})
export class ViewStudentComponent implements OnInit {
  public lststudent: Student[] = new Array<Student>() ;
  constructor(private studentservice: StudentService , private router: Router) { }

  ngOnInit() {
    this.studentservice.GetAllStudent().subscribe((res: any) => {
      this.lststudent = res;
      console.log (this.lststudent);

  });
}

}
