import { Component, OnInit } from '@angular/core';
import { CourseService } from '../Service/course.service';
import { Route } from '@angular/compiler/src/core';
import { Utility } from '../Common/Utility';
import { Course } from '../Model/Course';
import { Status } from '../Common/Enum';
import { Router, ActivatedRoute } from '@angular/router';

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
