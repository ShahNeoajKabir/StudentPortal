import { ForbiddenComponent } from './../../components/forbidden/forbidden.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';


const routes: Routes = [
    {
        path: '',
        component: DashboardComponent,
        data: {
            breadcrumb: 'Dashboard'
        }
    },
    {
        path: 'Others',
        data: {
            title: 'Dashboard'
        },
        children: [
            {
                path: '',
                loadChildren: './Others/others.module#OthersModule'
            }
        ]
    },
    {
        path: 'user',
        data: {
            title: 'Dashboard'
        },
        children: [
            {
                path: '',
                loadChildren: './Users/user.module#UserModule'
            }
        ]
    },
    {
        path: 'report',
        data: {
            title: 'Dashboard'
        },
        children: [
            {
                path: '',
                loadChildren: './Report/report.module#ReportModule'
            }
        ]
    },
    {
        path: 'access-right',
        data: {
            title: 'Dashboard'
        },
        children: [
            {
                path: '',
                loadChildren: './AccessRight/access-right.module#AccessRightModule'
            }
        ]
    },
    {
        path: 'forbidden',
        component: ForbiddenComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class DashboardRoutingModule { }
