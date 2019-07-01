import { Component, OnInit, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SurveyService } from '../survey.service';
import { Survey } from 'src/app/models/Survey';
import { Question, Option } from 'src/app/models/Question';
import { showNotification } from 'src/app/additional/functions';
import { REQUIREDPATTERN } from 'src/app/additional/data';
import { Customer } from 'src/app/models/Customer';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';


class Response {
  SurveyId: number;
  CustomerId: number;
  Answers: any[]
}




@Component({
  selector: 'app-respons-survey',
  templateUrl: './respons-survey.component.html',
  styleUrls: ['./respons-survey.component.scss']
})
export class ResponsSurveyComponent implements OnInit {

  public Survey: Survey = new Survey();

  public Customer: Customer = new Customer();

  public Questions: Question[] = []

  pattern: string = REQUIREDPATTERN;

  constructor(private srv: SurveyService, private router: Router, private route: ActivatedRoute, public dialog: MatDialog) { }

  ngOnInit() {
    let res = this.route.snapshot.data["Survey"];
    if (res != null) {
      this.Survey = res["survey"];
      this.Customer = res["customer"];

      if (this.Survey != null) {


        if (this.Survey.Questions == null || this.Survey.Questions.length == 0) {
          showNotification("Error : No Questions in this Survey", "bottom", "center", "danger");
        }
        else {
          this.Questions = this.Survey.Questions;
        }
      }
      else {
        showNotification("Error : No More Surveys left for this customer ", "bottom", "center", "danger");
        this.router.navigate(['/pageNotFound']);
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


    let response = new Response();
    response.CustomerId = this.Customer.Id;
    response.SurveyId = this.Survey.Id;

    response.Answers = this.Survey.Questions.filter(item =>

      !(
        item.answer == null
        || item.answer == undefined
        || (item.answer && item.answer.length == 0)
      )

    ).map(ele => {

      return { Id: ele.Id, Type: ele.Type, answer: ele.answer }
    });

    console.log("Response : ---------------------------------------------------------------------------------------");
    console.log(response);
    console.log("-------------------------------------------------------------------------------------------------");



    this.srv.sendSurveyResponse(response).subscribe(
      res => {
        if (res) {
          showNotification("Submitted Successfully", "bottom", "center", "success");
        }

        console.log(res);

      },
      err => {
        showNotification("Error : " + err.statusText, "bottom", "center", "danger");
        console.log(err);
      }
    );



  }




  naviToDialog() {
    this.router.navigate([`/survey/dialog/${this.Customer.NationalNumber}`])
  }



}








