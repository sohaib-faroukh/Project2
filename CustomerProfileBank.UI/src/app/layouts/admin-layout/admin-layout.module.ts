import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http'; import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ClipboardModule } from 'ngx-clipboard';

import { AdminLayoutRoutes } from './admin-layout.routing';
import { DashboardComponent } from '../../pages/dashboard/dashboard.component';
import { IconsComponent } from '../../pages/icons/icons.component';
import { MapsComponent } from '../../pages/maps/maps.component';
import { UserProfileComponent } from '../../pages/user-profile/user-profile.component';
import { TablesComponent } from '../../pages/tables/tables.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { UsersComponent } from 'src/app/User Role Management/users/users.component';
import { DxBulletModule, DxDataGridModule, DxTemplateModule } from 'devextreme-angular';
import { RolesComponent } from 'src/app/User Role Management/roles/roles.component';
import { BrowseUsersComponent } from 'src/app/User Role Management/users/browse-users/browse-users.component';
import { BrowseRolesComponent } from 'src/app/User Role Management/roles/browse-roles/browse-roles.component';
import { AddEditRoleComponent } from 'src/app/User Role Management/roles/add-edit-role/add-edit-role.component';
import { AddEditUserComponent } from 'src/app/User Role Management/users/add-edit-user/add-edit-user.component';
import { UsersService } from 'src/app/User Role Management/users/users.service';
import { RolesService } from 'src/app/User Role Management/roles/roles.service';




import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatProgressSpinnerModule, MatIconModule } from '@angular/material';
import { KeyValuePipe } from 'src/app/pipes/keyValueFilter.pipe';
// import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
// import { ToastrModule } from 'ngx-toastr';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(AdminLayoutRoutes),
    FormsModule,
    HttpClientModule,
    NgbModule,
    ClipboardModule,
    DxDataGridModule,
    DxTemplateModule,
    DxBulletModule,

    // BrowserAnimationsModule,
    MatInputModule,
    MatSelectModule,
    MatProgressSpinnerModule,
    MatIconModule
  ],
  declarations: [
    DashboardComponent,
    UserProfileComponent,
    TablesComponent,
    IconsComponent,
    MapsComponent,
    UsersComponent,
    RolesComponent,
    BrowseUsersComponent,
    BrowseRolesComponent,
    AddEditRoleComponent,
    AddEditUserComponent,
    KeyValuePipe,
  ],

  providers: [
    UsersService,
    RolesService,
    // AuthGuard 
  ]
})

export class AdminLayoutModule { }
