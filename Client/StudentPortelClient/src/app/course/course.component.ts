import { Component, OnInit } from '@angular/core';
import { CourseService } from '../Service/course.service';
import { Route } from '@angular/compiler/src/core';
import { Utility } from '../Common/Utility';
import { Course } from '../Model/Course';
import { Status } from '../Common/Enum';
import { Router } from '@angular/router';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.scss']
})
export class CourseComponent implements OnInit {
  public objcourse: Course = new Course();
  public lstStatus: any;


  constructor(private courseservice: CourseService , private router: Router , private utility: Utility) { }

  ngOnInit() {
    this.lstStatus = this.utility.enumToArray(Status);

  }
  AddCourse() {
    console.log(this.objcourse);
    this.courseservice.AddCourse(this.objcourse).subscribe(res => {
      console.log(res);
    } );
}


}
