import { Component, OnInit } from '@angular/core';
import { Semester } from '../Model/Semester';
import { Status } from '../Common/Enum';
import { SemesterService } from '../Service/semester.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Utility } from '../Common/Utility';

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
