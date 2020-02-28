import { Component, OnInit } from '@angular/core';
import { Course } from '../Model/Course';
import { CourseService } from '../Service/course.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-view-course',
  templateUrl: './view-course.component.html',
  styleUrls: ['./view-course.component.scss']
})
export class ViewCourseComponent implements OnInit {
  public lstcourse: Course[] = new Array<Course>() ;

  constructor(private courseservice: CourseService , private router: Router) { }

  ngOnInit() {
    this.courseservice.GetAll().subscribe((res: any) => {
      this.lstcourse = res;
      console.log (this.lstcourse);

  });
  }
  Edit(id) {

    console.log(id);
  }

}
