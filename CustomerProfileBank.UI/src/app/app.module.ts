import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { AdminLayoutComponent } from './layouts/admin-layout/admin-layout.component';
import { AuthLayoutComponent } from './layouts/auth-layout/auth-layout.component';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppRoutingModule } from './app.routing';
import { ComponentsModule } from './components/components.module';
import { AuthGuard } from './guards/auth.guard';
import { ConfigService, API_BASE_URL, ConfigFactory } from './config/config.service';
import { HttpModule } from '@angular/http';
// import {
//   DxDataGridModule,
//   DxBulletModule,
//   DxTemplateModule
// } from 'devextreme-angular';

@NgModule({
  imports: [
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,

    ComponentsModule,
    NgbModule,
    RouterModule,
    AppRoutingModule,
    // DxDataGridModule,
    // DxTemplateModule,
    // DxBulletModule

    HttpModule
  ],
  declarations: [
    AppComponent,
    AdminLayoutComponent,
    AuthLayoutComponent,
  ],
  providers: [
    ConfigService,
    {provide :'CONFIG.JSON',useValue:'assets/config.json'},
    {provide :'BASE-API-VARIABLE',useValue:'API_URL'},
    {
      provide: API_BASE_URL, useFactory: ConfigFactory,
      deps: [ConfigService,'CONFIG.JSON','BASE-API-VARIABLE']
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
