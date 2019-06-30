import { Component, OnInit } from '@angular/core';
import { Survey } from 'src/app/models/Survey';

@Component({
  selector: 'app-add-edit-survey',
  templateUrl: './add-edit-survey.component.html',
  styleUrls: ['./add-edit-survey.component.scss']
})
export class AddEditSurveyComponent implements OnInit {

  Survey:Survey=new Survey();
  constructor() { }

  ngOnInit() {
  }

}
