import { Component, OnInit } from '@angular/core';
import { Semester } from '../Model/Semester';
import { SemesterService } from '../Service/semester.service';

@Component({
  selector: 'app-view-semester',
  templateUrl: './view-semester.component.html',
  styleUrls: ['./view-semester.component.scss']
})
export class ViewSemesterComponent implements OnInit {
  public lstsemester: Semester[] = new Array<Semester>();

  constructor( private semesterservice: SemesterService) { }

  ngOnInit() {
    this.semesterservice.GetAll().subscribe((res: any) => {
      this.lstsemester = res;
      console.log(this.lstsemester);

    });

  }
  Edit(id) {

    console.log(id);
  }

}
