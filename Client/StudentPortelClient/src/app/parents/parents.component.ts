import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiConstant } from '../Common/ApiConstant';
import { Parents } from '../Model/Parents';
import { ParentsService } from '../Service/parents.service';
import { Status } from '../Common/Enum';
import { Utility } from '../Common/Utility';
import { StudentService } from '../Service/student.service';

@Component({
  selector: 'app-parents',
  templateUrl: './parents.component.html',
  styleUrls: ['./parents.component.scss']
})
export class ParentsComponent implements OnInit {
  public objparents: Parents = new Parents();
  public lstStatus: any;
  public lstStudent: any;

  constructor(private parentsservice: ParentsService , private utility: Utility, private studentservice: StudentService) { }

  ngOnInit() {
    this.lstStatus = this.utility.enumToArray(Status);
    this.studentservice.GetAllStudent().subscribe((res: any) => {
      console.log(res);

      this.lstStudent = res;
      console.log(this.lstStudent);

    });
  }
  AddParents() {
    console.log(this.objparents);
    this.parentsservice.AddParents(this.objparents).subscribe(res => {
      console.log(res);
    } );

}
}

