import { Component, OnInit } from '@angular/core';
import { Teacher } from '../../Model/Teacher';
import { TeacherService } from '../../Service/teacher.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-view-teacher',
  templateUrl: './view-teacher.component.html',
  styleUrls: ['./view-teacher.component.scss']
})
export class ViewTeacherComponent implements OnInit {
  public lstteacher: Teacher [] = new Array<Teacher>() ;

  constructor(private teacherservice: TeacherService , private router: Router) { }

  ngOnInit() {
    this.teacherservice.GetAllTeacher().subscribe((res: any) =>  {
      this.lstteacher = res ;
      console.log(this.lstteacher);
    });
  }
  Edit(id) {

    console.log(id);
  }

}
