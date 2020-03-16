import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/Service/auth/auth.service';


@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss']
})
export class LayoutComponent implements OnInit {

  constructor(public authservice: AuthService) { }

  ngOnInit(): void {
  }

}
