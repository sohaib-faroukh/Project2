import { Role } from "./Role";

export class User{
    id:number;
    firstName:string;
    lastName?:string;
    alias:string;
    status:string;
    creationDate:Date;
    deactivationDate ?: Date;
    Roles?:Role[]=[];

    constructor(){
        this.firstName="";
        this.alias="";
        this.lastName="";
        this.status="Active";
        this.creationDate=new Date();
        this.Roles=[];
    }

}