import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SurveyComponent } from './survey.component';
import { Routes, RouterModule } from '@angular/router';


export const SurveyRoutes: Routes = [
  { path: '', component: SurveyComponent },
]


@NgModule({
  declarations: [SurveyComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(SurveyRoutes),
  ]
})
export class SurveyModule { }

