import { Component, OnInit } from '@angular/core';
import { Teacher } from '../../Model/Teacher';
import { TeacherService } from '../../Service/teacher.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Utility } from '../../Common/Utility';
import { Status } from '../../Common/Enum';

@Component({
  selector: 'app-teacher',
  templateUrl: './teacher.component.html',
  styleUrls: ['./teacher.component.scss']
})
export class TeacherComponent implements OnInit {
  public objteacher: Teacher = new Teacher();
  public objteacheredit: Teacher = new Teacher();
  public lststatus: any;
  public TeacherId: number;

  constructor(private teacherservice: TeacherService , private router: Router , private utility: Utility ,
              private ActivateRouter: ActivatedRoute) { }

  ngOnInit() {
    this.lststatus = this.utility.enumToArray(Status);
    if (this.ActivateRouter.snapshot.params['id'] !== undefined) {
      this.objteacheredit.TeacherId = this.ActivateRouter.snapshot.params['id'];
      this.teacherservice.GetTeacherById(this.objteacheredit).subscribe( ( res: any) => {
        this.objteacher = res ;
        console.log(this.objteacher);
      });
      console.log(this.ActivateRouter.snapshot.params[ 'id']);

    }
  }
  AddTeacher() {
    console.log(this.objteacher);
    if (this.objteacher.TeacherId > 0) {
      this.teacherservice.UpdateTeacher(this.objteacher).subscribe( res => {
        this.router.navigate(['/student/View']);

        if ( res === 1 ) {
          console.log(res);

        }
        console.log(res);
      });
    } else {
      this.teacherservice.AddTeacher(this.objteacher).subscribe(res => {
        if ( res === 1 ) {
          this.router.navigate(['/student/View']);

          console.log(res);

        }
        console.log(res);
      });
    }


  }

}
