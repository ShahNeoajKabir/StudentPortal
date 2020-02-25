import { Component, OnInit } from '@angular/core';
import { Parents } from '../Model/Parents';
import { ParentsService } from '../Service/parents.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-view-parents',
  templateUrl: './view-parents.component.html',
  styleUrls: ['./view-parents.component.scss']
})
export class ViewParentsComponent implements OnInit {
  public lstparents: Parents[] = new Array<Parents>() ;
  constructor(private parentsservice: ParentsService , private router: Router) { }

  ngOnInit() {
    this.parentsservice.GetAllParents().subscribe((res: any) => {
      this.lstparents = res;
      console.log (this.lstparents);
  });

}
}

