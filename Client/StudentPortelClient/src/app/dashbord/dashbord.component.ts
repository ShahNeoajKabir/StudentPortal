import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashbord',
  templateUrl: './dashbord.component.html',
  styleUrls: ['./dashbord.component.scss']
})
export class DashbordComponent implements OnInit {

Designation: string;
UserName: string;
NoOfTeamMember: number;
TotalCostOfAllProjects: number;
PendingTask: number;
UpcommingProject: number;
ProjectCost: number;

CurrentExpenditure: number;
AvailableFunds: number;

  ngOnInit() {
    this.Designation = 'Team Leader';
    this.UserName = 'Bappy';
    this.NoOfTeamMember = 1000;
    this.TotalCostOfAllProjects = 7000;
    this.PendingTask = 1000;
    this.UpcommingProject = 1000;
    this.ProjectCost = 6000;
    this.CurrentExpenditure = 1000;
    this.AvailableFunds = 1000;
  }

}
