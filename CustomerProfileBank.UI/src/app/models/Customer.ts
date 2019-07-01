import { showNotification } from "../additional/functions";

export class Customer {

    Id: number;
    FirstName: string;
    LastName: string;
    NationalNumber: string;
    Address: string;
    City: string;
    ISPN: string;
    Status: string;

    Description: string;

    Hobbies: any[] = [];

    Numbers: string[] = [];
    Services: any[] = [];

    constructor(public error?: string) {
        if (!error) {


            this.Status = "ACTIVE";
            this.LastName = "";
            this.FirstName = "";
            this.NationalNumber = "";
            this.Address = "";
            this.City = "";
            this.Description = "";

            this.Hobbies = [];
            this.Numbers = [];
            this.Services = [];
        }
        else{
            showNotification(error,"bottom","center","danger");
            
        }
    }
}