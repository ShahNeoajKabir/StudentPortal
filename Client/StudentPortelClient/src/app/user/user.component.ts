import { Component, OnInit } from '@angular/core';
import { User } from '../Model/User';
import { UserService } from '../Service/user.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Utility } from '../Common/Utility';
import { UserType, Status } from '../Common/Enum';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {

  public objuser: User = new User();
  public objuseredit: User = new User();

  public lstUserType: any;
  public lstStatus: any;
  public UserId: number;


  constructor(private Userservice: UserService, private router: Router, private activateRoute: ActivatedRoute, private utility: Utility,
              // private notificationservice: NotificationService

    ) { }

  ngOnInit() {
    this.lstUserType = this.utility.enumToArray(UserType);
    this.lstStatus = this.utility.enumToArray(Status);

    if (this.activateRoute.snapshot.params[' id'] !== undefined) {

      this.objuseredit.UserId = this.activateRoute.snapshot.params[' id' ];
      this.Userservice.GetUserByID(this.objuseredit).subscribe(( res: any) => {

        this.objuser = res;
        console.log(this.objuser);
     });
      console.log(this.activateRoute.snapshot.params[' id' ] );

    }
  }

  AddUser() {
    console.log(this.objuser);
    if (this.objuser.UserId > 0 ) {
      this.Userservice.UpdateUser(this.objuser).subscribe(res => {
        if (res === 1) {
          console.log(res);
        }
        console.log(res);
      } );
    } else {
      this.Userservice.AddUser(this.objuser).subscribe(res => {
        if (res === 1) {
          console.log(res);
        }
        console.log(res);
      } );
    }

  }

}
