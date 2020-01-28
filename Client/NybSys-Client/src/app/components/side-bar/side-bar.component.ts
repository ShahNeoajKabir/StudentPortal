import { Component, OnInit } from '@angular/core';
import { RoutingService } from 'src/app/services/routing.service';
import { Routing } from 'src/app/Models/Routing';
import { TokenService } from 'src/app/services/token.service';
import { AuthService } from 'src/app/services/auth.service';
declare let $: any;
@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.scss']
})
export class SideBarComponent implements OnInit {

  isSettingOpen = false;
    isLogOpen = false;
    isReportOpen = false;
    constructor(public authService: AuthService,
        ) {}

    ngOnInit() {
    //   $('.main-sidebar').pushMenu('collapseScreenSize');
    $(document).ready( function() {
            if ($(window).width() < 514) {
                $('body').addClass('mobile');
            } else {
                $('body').removeClass('mobile');
                }
            });

            $(document).on('click' , '.mobile  .mobile_menu' , function(e) {
                 //  $('body').addClass('sidebar-mini sidebar-collapse');
                $('body').removeClass('sidebar-open');
                // e.stopImmediatePropagation();
            e.preventDefault();
        });
     }
    openSettingMenu() {
        this.isSettingOpen = !this.isSettingOpen;
    }
    openLogMenu() {
        this.isLogOpen = !this.isLogOpen;
    }

    openReportMenu() {
        this.isReportOpen = !this.isReportOpen;
    }

}
