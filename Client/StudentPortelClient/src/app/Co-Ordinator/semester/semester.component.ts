import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Semester } from 'src/app/Model/Semester';
import { SemesterService } from 'src/app/Service/semester.service';
import { Utility } from 'src/app/Common/Utility';
import { Status } from 'src/app/Common/Enum';


@Component({
  selector: 'app-semester',
  templateUrl: './semester.component.html',
  styleUrls: ['./semester.component.scss']
})
export class SemesterComponent implements OnInit {
  public objsemester: Semester = new Semester();
  public objsemesteredit: Semester = new Semester();
  public lststatus: any;
  public lstSemesterId: number;

  constructor(private semesterservice: SemesterService , private router: Router , private utility: Utility ,
              private ActivateRoute: ActivatedRoute ) { }

  ngOnInit() {
    this.lststatus = this.utility.enumToArray(Status);
    if (this.ActivateRoute.snapshot.params['id'] !== undefined ) {
      this.objsemesteredit.SemesterId = this.ActivateRoute.snapshot.params['id' ];
      this.semesterservice.GetById(this.objsemesteredit).subscribe((res: any) => {
        this.objsemester = res;
        console.log(this.objsemester);

      });
      console.log(this.ActivateRoute.snapshot.params['id']);

    }
  }
   AddSemester() {
     if (this.objsemester.SemesterId > 0) {
       this.semesterservice.UpdateSemester(this.objsemester).subscribe(res => {
        this.router.navigate(['/semester/View']);
        if (res === 1) {
           console.log(res);

         }
         console.log(res);
       });

     } else {
       this.semesterservice.AddSemester(this.objsemester).subscribe(res => {
        this.router.navigate(['/semester/View']);
        if ( res === 1) {
           console.log(res);

         }
        console.log(res);

       });

     }

  }

}
