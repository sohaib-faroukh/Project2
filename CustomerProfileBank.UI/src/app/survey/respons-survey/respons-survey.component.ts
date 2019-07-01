import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SurveyService } from '../survey.service';
import { Survey } from 'src/app/models/Survey';
import { Question, Option } from 'src/app/models/Question';
import { showNotification } from 'src/app/additional/functions';
import { REQUIREDPATTERN } from 'src/app/additional/data';

@Component({
  selector: 'app-respons-survey',
  templateUrl: './respons-survey.component.html',
  styleUrls: ['./respons-survey.component.scss']
})
export class ResponsSurveyComponent implements OnInit {

  public Survey: Survey = new Survey();

  public Questions: Question[] = []

  pattern: string = REQUIREDPATTERN;

  constructor(private srv: SurveyService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    let res = this.route.snapshot.data["Survey"];
    if (res != null) {
      this.Survey = res;

      if (!this.Survey.Questions || this.Survey.Questions.length == 0) {
        showNotification("Error : No Questions in this Survey", "bottom", "center", "danger")
      }
      else {
        this.Questions = this.Survey.Questions;
      }

    }
  }

  answerQuestion(Question: Question, event): void {


    if (event && event.length > 0 && event.includes(null)) {
      Question.answer = null;
    }

    else {
      if (Question.Type.trim().toUpperCase() == 'SINGLESELECT' || Question.Type.trim().toUpperCase() == 'OPEN') {
        Question.answer = event;
      }
      else if (Question.Type.trim().toUpperCase() == 'MULTISELECT') {
        if (Question.answer == null) {
          Question.answer = [];
        }
        Question.answer = event;
      }
    }

  }



  compare(item1, item2) {
    return item1.Id && item2.Id && item1.Id === item2.Id;
  }


  onSubmit() {

    showNotification("Submitted Successfully","bottom","center","success");

    let Answers: any;
    Answers = this.Survey.Questions.map(ele => {
      return { Id: ele.Id, Type: ele.Type, answer: ele.answer }
    });

    console.log("Answers : ---------------------------------------------------------------------------------------");
    console.log(Answers);
    console.log("-------------------------------------------------------------------------------------------------");

  }

}
