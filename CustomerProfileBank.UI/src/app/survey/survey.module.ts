import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SurveyComponent } from './survey.component';
import { Routes, RouterModule } from '@angular/router';
import { BrowseSurveysComponent } from './browse-surveys/browse-surveys.component';
import { AddEditSurveyComponent } from './add-edit-survey/add-edit-survey.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ClipboardModule } from 'ngx-clipboard';
import {
  DxDataGridModule, DxTemplateModule, DxBulletModule, DxSelectBoxModule,
  DxCheckBoxModule,
  DxButtonModule,
  DxGalleryModule,
  DxPopoverModule,
  DxListModule,
  DxTreeListModule,
  DxDataGridComponent,

} from 'devextreme-angular';



import {

  MatButtonModule,
  MatInputModule,
  MatRippleModule,
  MatTooltipModule,
  MatNativeDateModule,
  MatIconModule,
  MatProgressSpinnerModule,
  MatProgressBarModule,
  MatListModule,
  MatCheckboxModule,
  MatSelectModule,
  MatPaginatorModule,
  MatRadioModule,
  MatTableModule,
  MatSortModule,
  MatFormFieldModule,
  MatDividerModule,
  MatMenuModule,
  MatStepperModule,
  MatDatepickerModule,
} from '@angular/material';



import { SurveyService } from './survey.service';
import { CdkTableModule } from '@angular/cdk/table';



export const SurveyRoutes: Routes = [
  // {
  // path: '', component: SurveyComponent, children: [
  { path: '', component: BrowseSurveysComponent, resolve: { Surveys: SurveyService } },

  { path: ':action', component: AddEditSurveyComponent, resolve: {} },

  { path: ':action/:id', component: AddEditSurveyComponent, resolve: {} },

  // ]
  // },
]


@NgModule({
  declarations: [
    // SurveyComponent,
    BrowseSurveysComponent,
    AddEditSurveyComponent,
  ],

  imports: [

    CommonModule,
    RouterModule.forChild(SurveyRoutes),

    FormsModule,
    HttpClientModule,
    NgbModule,
    ClipboardModule,

    DxDataGridModule,
    DxTemplateModule,
    DxBulletModule,
    DxSelectBoxModule,
    DxCheckBoxModule,
    DxButtonModule,
    DxGalleryModule,
    DxPopoverModule,
    DxListModule,
    DxTreeListModule,

    // BrowserAnimationsModule,
    MatInputModule,
    MatSelectModule,
    MatProgressSpinnerModule,
    MatIconModule,
    MatTableModule,
    MatSortModule,
    MatButtonModule,
    MatRippleModule,
    MatInputModule,
    MatTooltipModule,
    MatListModule,
    MatPaginatorModule,
    MatRadioModule,



    MatDatepickerModule,
    MatNativeDateModule,
    MatIconModule,
    MatProgressSpinnerModule,
    MatProgressBarModule,
    MatCheckboxModule,
    MatSelectModule,
    MatFormFieldModule,
    MatDividerModule,
    MatMenuModule,
    CdkTableModule,
    // MatIconModule,
    MatStepperModule,

  ]
})
export class SurveyModule { }

