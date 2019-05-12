import { Role } from "./Role";

export class User{
    Id:number;
    HRId:number;
    FirstName:string;
    LastName?:string;
    Alias:string;
    Status:string;
    CreationDate:Date;
    DeactivationDate ?: Date;
    Roles?:Role[]=[];

    constructor(){
        this.FirstName="";
        this.Alias="";
        this.LastName="";
        this.Status="Active";
        this.CreationDate=new Date();
        this.Roles=[];
    }

}