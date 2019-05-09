import { User } from "./User";
import { Privilege } from "./Privilege";

export class Role{
    id:number;
    name:string;
    description?:string;
    status:string;
    creationDate:Date;
    Users?:User[]=[];
    Privileges?:Privilege[]=[];
    constructor(){
        this.name="";
        this.description="";
        this.status="Active";
        this.creationDate=new Date();
        this.Users=[];
        this.Privileges=[];
    }
}