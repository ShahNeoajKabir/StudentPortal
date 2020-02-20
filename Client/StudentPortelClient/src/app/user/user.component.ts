import { Component, OnInit } from '@angular/core';
import { User } from '../Model/User';
import { UserService } from '../Service/user.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {

  public objuser: User = new User();
  constructor(private Userservice: UserService,
    private router: Router,
    private activateRoute: ActivatedRoute,

    ) { }

  ngOnInit() {
    if(this.activateRoute.snapshot.params['id']!=undefined){
      console.log(this.activateRoute.snapshot.params['id'])

    }
  }

  AddUser() {
    console.log(this.objuser);
    this.Userservice.AddUser(this.objuser).subscribe(res => {
      console.log(res);
    } );

  }

}
