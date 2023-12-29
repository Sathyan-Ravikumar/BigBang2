import { UserModel } from "./user.model";

export class DocModel
{
    doctorRegister(intern: DocModel) {
      throw new Error('Method not implemented.');
    }
    userRegister(intern: DocModel) {
      throw new Error('Method not implemented.');
    }
    constructor(
        public id:number= 0,
        public userName:string="",
        public email:string="",
        public userPassword:string="",
        public role:string="",
        public user:UserModel=new UserModel()){

        }
  
}