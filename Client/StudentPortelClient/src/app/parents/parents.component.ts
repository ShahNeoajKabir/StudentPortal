import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiConstant } from '../Common/ApiConstant';
import { Parents } from '../Model/Parents';
import { ParentsService } from '../Service/parents.service';
import { Status } from '../Common/Enum';
import { Utility } from '../Common/Utility';
import { StudentService } from '../Service/student.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-parents',
  templateUrl: './parents.component.html',
  styleUrls: ['./parents.component.scss']
})
export class ParentsComponent implements OnInit {
  public objparents: Parents = new Parents();
  public objparentsedit: Parents = new Parents();
  public ParentsId: number;

  public lstStatus: any;
  public lstStudent: any;

  constructor(private parentsservice: ParentsService , private utility: Utility, private studentservice: StudentService,
              private activateRoter: ActivatedRoute , private router: Router) { }

  ngOnInit() {
    this.lstStatus = this.utility.enumToArray(Status);
    this.studentservice.GetAllStudent().subscribe((res: any) => {
      console.log(res);

      this.lstStudent = res;
      console.log(this.lstStudent);

    });
    if (this.activateRoter.snapshot.params[ 'id'] !== undefined) {
      this.objparentsedit.ParentsId = this.activateRoter.snapshot.params[ 'id'];
      this.parentsservice.GetParentsById(this.objparentsedit).subscribe((res: any) => {
        this.objparents = res;
        console.log(this.objparents);
      });
      console.log(this.activateRoter.snapshot.params[ 'id']);
    }
  }
  AddParents() {
    console.log(this.objparents);
    if ( this.objparents.ParentsId > 0) {
      this.parentsservice.UpdateParents(this.objparents).subscribe(res => {
        if ( res === 1) {
        this.router.navigate(['/parents/View']);

        console.log(res);

        }
        console.log(res);
      });
    } else {
      this.parentsservice.AddParents(this.objparents).subscribe(res => {
        this.router.navigate(['/parents/View']);

        if ( res === 1) {
          console.log(res);
        }
        console.log(res);
      });
    }

}
}

