import { Component, OnInit } from '@angular/core';
import { Route } from '@angular/compiler/src/core';

import { Router, ActivatedRoute } from '@angular/router';
import { Course } from 'src/app/Model/Course';
import { CourseService } from 'src/app/Service/course.service';
import { Utility } from 'src/app/Common/Utility';
import { Status } from 'src/app/Common/Enum';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.scss']
})
export class CourseComponent implements OnInit {
  public objcourse: Course = new Course();
  public objcourseedit: Course = new Course();
  public CourseId: number;
  public lstStatus: any;


  constructor(private courseservice: CourseService , private router: Router , private utility: Utility ,
              private ActivateRouter: ActivatedRoute) { }

  ngOnInit() {
    this.lstStatus = this.utility.enumToArray(Status);
    if (this.ActivateRouter.snapshot.params[ 'id'] !== undefined) {
      this.objcourseedit.CourseId = this.ActivateRouter.snapshot.params['id'];
      this.courseservice.GetCourseById(this.objcourseedit).subscribe((res: any) => {
        this.objcourse = res;
        console.log(this.objcourse);
      });
      console.log(this.ActivateRouter.snapshot.params['id']);
    }

  }
  AddCourse() {
    console.log(this.objcourse);
    if (this.objcourse.CourseId > 0) {
      this.courseservice.UpdateCourse(this.objcourse).subscribe(res => {
        this.router.navigate(['/course/View']);

        if ( res === 1) {
          console.log(res);

        }
        console.log(res);
      });
    } else {
      this.courseservice.AddCourse(this.objcourse).subscribe(res => {
        this.router.navigate(['/course/View']);

        if ( res === 1 ) {
          console.log(res);

        }
        console.log(res);
      });
    }
}


}
