import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../Service/auth/auth.service';

@Component({
  selector: 'app-student-dash-board',
  templateUrl: './student-dash-board.component.html',
  styleUrls: ['./student-dash-board.component.scss']
})
export class StudentDashBoardComponent implements OnInit {

  constructor(public authservice: AuthService) { }

  ngOnInit(): void {
  }

}
