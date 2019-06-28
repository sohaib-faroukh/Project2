import { Routes } from '@angular/router';
import { DashboardComponent } from '../../pages/dashboard/dashboard.component';
import { IconsComponent } from '../../pages/icons/icons.component';
import { MapsComponent } from '../../pages/maps/maps.component';
import { UserProfileComponent } from '../../pages/user-profile/user-profile.component';
import { TablesComponent } from '../../pages/tables/tables.component';
import { UsersComponent } from 'src/app/User Role Management/users/users.component';
import { RolesComponent } from 'src/app/User Role Management/roles/roles.component';
import { BrowseRolesComponent } from 'src/app/User Role Management/roles/browse-roles/browse-roles.component';
import { AddEditRoleComponent } from 'src/app/User Role Management/roles/add-edit-role/add-edit-role.component';
import { BrowseUsersComponent } from 'src/app/User Role Management/users/browse-users/browse-users.component';
import { AddEditUserComponent } from 'src/app/User Role Management/users/add-edit-user/add-edit-user.component';
import { AuthGuard } from 'src/app/Guards/auth.guard';
import { UsersService, EditUsersResolverService } from 'src/app/User Role Management/users/users.service';
import { RolesService, PrivilegesResolver, EditRoleResolverService } from 'src/app/User Role Management/roles/roles.service';
import { SurveyComponent } from 'src/app/survey/survey.component';
import { CustomersComponent } from 'src/app/Customer Management/customers/customers.component';
import { BrowseCustomersComponent } from 'src/app/Customer Management/customers/browse-customers/browse-customers.component';
import { AddEditCustomerComponent } from 'src/app/Customer Management/customers/add-edit-customer/add-edit-customer.component';

export const AdminLayoutRoutes: Routes = [
    { path: 'dashboard', component: DashboardComponent },
    { path: 'user-profile', component: UserProfileComponent },
    { path: 'tables', component: TablesComponent },
    { path: 'icons', component: IconsComponent },
    { path: 'maps', component: MapsComponent },

    {
        path: 'survey',
        // component: SurveyComponent,
        // children: [
        //     {
        //         path: '',
        loadChildren: 'src/app/survey/survey.module#SurveyModule'
        //     }
        // ]
    },


    {
        path: 'customers', component: CustomersComponent, children: [
            {
                path: '', component: BrowseCustomersComponent,
                // canActivate: [AuthGuard],
                // resolve: { Users: UsersService }
            },
            {
                path: ':action', component: AddEditCustomerComponent,
                // canActivate: [AuthGuard],
                // resolve: { Users: UsersService }
            },
            {
                path: ':action/:id', component:AddEditCustomerComponent,
                // canActivate: [AuthGuard],
                // resolve: { Users: UsersService }
            },
        ]
    },


    {
        path: 'users', component: UsersComponent, children: [
            {
                path: '', component: BrowseUsersComponent,
                canActivate: [AuthGuard],
                resolve: { Users: UsersService }
            },
            {
                path: ':action', component: AddEditUserComponent,
                canActivate: [AuthGuard],
                canDeactivate: [AuthGuard],
                resolve: { Roles: RolesService }
            },
            {
                path: ':action/:id', component: AddEditUserComponent,
                canActivate: [AuthGuard],
                canDeactivate: [AuthGuard],
                resolve: { User: EditUsersResolverService, Roles: RolesService }
            },

        ]
    },
    {
        path: 'roles', component: UsersComponent, children: [
            {
                path: '', component: BrowseRolesComponent,
                canActivate: [AuthGuard],
                resolve: { Roles: RolesService }
            },
            {
                path: ':action', component: AddEditRoleComponent,
                canActivate: [AuthGuard],
                canDeactivate: [AuthGuard],
                resolve: { Users: UsersService, Privileges: PrivilegesResolver }
            },
            {
                path: ':action/:id', component: AddEditRoleComponent,
                canActivate: [AuthGuard],
                canDeactivate: [AuthGuard],
                resolve: { Role: EditRoleResolverService, Users: UsersService, Privileges: PrivilegesResolver }
            },

        ]
    },
];
