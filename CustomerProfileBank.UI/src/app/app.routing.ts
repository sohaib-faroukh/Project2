import { NgModule } from '@angular/core';
import { CommonModule, } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';

import { AdminLayoutComponent } from './layouts/admin-layout/admin-layout.component';
import { AuthLayoutComponent } from './layouts/auth-layout/auth-layout.component';
import { InsertCustomerComponent } from './Customer Management/insert-customer/insert-customer.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { SurveyComponent } from './survey/survey.component';
const routes: Routes = [
  {
    path: '',
    redirectTo: 'insertCustomer',
    pathMatch: 'full',
  },
  {
    path: 'insertCustomer',
    component: InsertCustomerComponent

  },
  {
    path: '',
    component: AdminLayoutComponent,
    children: [
      {
        path: '',
        loadChildren: './layouts/admin-layout/admin-layout.module#AdminLayoutModule'
      }
    ]
  },
  {
    path: 'surveys',
    component: SurveyComponent,
    children: [
      {
        path: '',
        loadChildren: './survey/survey.module#SurveyModule'
      }
    ]
  }, {
    path: '',
    component: AuthLayoutComponent,
    children: [
      {
        path: '',
        loadChildren: './layouts/auth-layout/auth-layout.module#AuthLayoutModule'
      }
    ]
  },

  {
    path: '**',
    redirectTo: 'pageNotFound'
  },
  {
    path: 'pageNotFound', component: PageNotFoundComponent,data : {}
  }

];

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    RouterModule.forRoot(routes)
  ],
  exports: [
  ],
})
export class AppRoutingModule { }
