import { Component, OnInit } from '@angular/core';
import { UserService } from '../Service/user.service';
import { User } from '../Model/User';

@Component({
  selector: 'app-view-user',
  templateUrl: './view-user.component.html',
  styleUrls: ['./view-user.component.scss']
})
export class ViewUserComponent implements OnInit {
    public lstuser: User[] = new Array<User>();
  constructor(private userservice: UserService) { }

  ngOnInit() {
   this.userservice.GetAll().subscribe((res: any) => {
     this.lstuser = res;
     console.log(this.lstuser);
    });

  }
  Edit(id) {

    console.log(id);
  }

}
