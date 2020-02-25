import { Component, OnInit } from '@angular/core';
import { Teacher } from '../Model/Teacher';
import { TeacherService } from '../Service/teacher.service';
import { Router } from '@angular/router';
import { Utility } from '../Common/Utility';
import { Status } from '../Common/Enum';

@Component({
  selector: 'app-teacher',
  templateUrl: './teacher.component.html',
  styleUrls: ['./teacher.component.scss']
})
export class TeacherComponent implements OnInit {
  public objteacher: Teacher = new Teacher();
 public lststatus: any;

  constructor(private teacherservice: TeacherService , private router: Router , private utility: Utility) { }

  ngOnInit() {
    this.lststatus = this.utility.enumToArray(Status);
  }
  AddTeacher() {
    console.log(this.objteacher);
    this.teacherservice.AddTeacher(this.objteacher).subscribe(res => {
      console.log(res);

    });

  }

}
