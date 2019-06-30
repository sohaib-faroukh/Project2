import { User } from "./User";
import { Question } from "./Question";
import { showNotification } from "../additional/functions";

export class Survey {
    Id: number;
    Name: string;
    Description: string
    ValidiatyMonthlyPeriod: number;
    Status: string;
    Language:string;
    Creator: User = new User();


    CreationDate: Date = null;
    FromDate: Date = null;
    ToDate: Date = null;
    Questions: Question[] = [];

    constructor(error?: string) {
        if (!error) {
            this.Id = null;
            this.Name = "";
            this.Description = "";
            this.Status = "ACTIVE";
            this.Name = "";
            this.ToDate = this.FromDate = null;
            this.ValidiatyMonthlyPeriod = 0;
            this.Questions = new Array<Question>();
        }
        else {
            showNotification(error, "bottom", "center", "danger");
        }

    }

    public validateDates(): boolean {
        let result = true;
        let errorMsg: string = "";

        //today
        let today = new Date().getTime();

        if (this.FromDate && this.ToDate) {
            if (this.FromDate.getTime() < today){
                errorMsg+="- From Date can't be earlier than tody</br>";
                result=false;
            }
            if(this.FromDate.getTime()>this.ToDate.getTime()){
                errorMsg+="- To Date can't be earlier than From Date </br>";
                result=false;     
            }
            if(this.ToDate.getTime()<today){
                errorMsg+="- To Date can't be earlier than today </br>";
                result=false;   
            }

        }
        if(result==false){
            showNotification(`Error : ${errorMsg}`,"bottom","center","danger");
        }
        return result;
    }
}

