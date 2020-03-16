import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/Service/auth/auth.service';

@Component({
  selector: 'app-parents-dashbord',
  templateUrl: './parents-dashbord.component.html',
  styleUrls: ['./parents-dashbord.component.scss']
})
export class ParentsDashbordComponent implements OnInit {

  constructor(public authservice: AuthService) { }

  ngOnInit(): void {
  }

}
