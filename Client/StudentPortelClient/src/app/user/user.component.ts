import { Component, OnInit } from '@angular/core';
import { User } from '../Model/User';
import { UserService } from '../Service/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {

  public objuser: User = new User();
  constructor(private Userservice: UserService ,

    ) { }

  ngOnInit() {
  }

  AddUser() {
    console.log('Helloa');
    this.Userservice.AddUser(this.objuser).subscribe(res => {
      console.log(res);
    } );

  }

}
