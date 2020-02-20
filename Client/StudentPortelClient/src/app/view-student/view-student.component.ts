import { Component, OnInit } from '@angular/core';
import { StudentService } from '../Service/student.service';
import { Student } from '../Model/Student';

@Component({
  selector: 'app-view-student',
  templateUrl: './view-student.component.html',
  styleUrls: ['./view-student.component.scss']
})
export class ViewStudentComponent implements OnInit {
  public lststudent: Student[] = new Array<Student>(); 
  constructor(private studentservice: StudentService) { }

  ngOnInit() {
    this.studentservice.GetAll().subscribe((res: any) => {
      this.lststudent = res;
       console.log (this.lststudent);

  })

}
}
