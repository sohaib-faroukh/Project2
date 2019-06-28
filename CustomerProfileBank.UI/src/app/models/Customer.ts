export class Customer{
    
    Id:number;
    FirstName:string;
    LastName:string;
    Address:string;
    ISPN:string;
    Status:string;

    Hobbies : any[]=[];

    Numbers:string[]=[];
    Services:any[]=[];

    constructor(){
        this.Status="ACTIVE";
        this.Hobbies =[];
        this.Numbers=[];
        this.Services=[];
    }
}