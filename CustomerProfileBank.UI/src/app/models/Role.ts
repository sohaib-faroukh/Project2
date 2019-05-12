import { User } from "./User";
import { Privilege } from "./Privilege";

export class Role{
    Id:number;
    Name:string;
    Description?:string;
    Status:string;
    CreationDate:Date;
    Users?:User[]=[];
    Privileges?:Privilege[]=[];
    constructor(){
        this.Name="";
        this.Description="";
        this.Status="Active";
        this.CreationDate=new Date();
        this.Users=[];
        this.Privileges=[];
    }
}