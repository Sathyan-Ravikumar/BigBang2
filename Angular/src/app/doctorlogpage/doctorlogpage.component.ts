import { Component } from '@angular/core';
import { DocterLoginPageservice } from '../Services/dogtorloginpage.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-doctorlogpage',
  templateUrl: './doctorlogpage.component.html',
  styleUrls: ['./doctorlogpage.component.css']
})
export class DoctorlogpageComponent {
  AddDoc!:FormGroup;
  updatedoctor!:FormGroup;
  docid:any;
  doctor!:any;
  isButtonDisabled: boolean;

  
   
  
  doctorName:any=localStorage.getItem('this.internID');

 constructor(private api:DocterLoginPageservice,private formBuilder: FormBuilder){
  this.isButtonDisabled = !!localStorage.getItem("Doctor_id");
 }
userID:number=Number(localStorage.getItem("userid"));

 public id:any = Number(localStorage.getItem("Doctor_id"));
 public appointment:any;
 ngOnInit(): void {

  this.AddDoc = this.formBuilder.group({
    userid:[Number(localStorage.getItem("userid"))],
    doctorName:[localStorage.getItem('this.internID')],
    specialization:[''],
    experience:[''],
    gender:[''],
    email:[''],
    contactNumber:[]
  });
  
  this.getdocid();
   this.getapp();

  // this.postdoc();
   this.putdoc();
  // this.updatedoc();
   
 }


 

public postdoc():void{
  this.api.PostDoctor(this.AddDoc.value).subscribe((result) => {
    alert(' Data Added ');
    this.closePopup();
  })
 }

putdoc(){
 this.updatedoctor=this.formBuilder.group({
  experience: [],
  email:[],
  contactNumber: []
 });
}

 public getdocid():void{
  this.api.finddocid(this.doctorName).subscribe(result=>{
    this.docid=result;
    localStorage.setItem("Doctor_id",(this.docid.doctorid).toString());
   });
 }
//  updatedoc():void{
//   this.api.putDoctor(this.id,this.updatedoctor.value) .subscribe((result) => {
//    this.doctor=result;
//    alert(' Data Updated ');
//    this.closePopup1();
//  });
 
 //}
 public getapp():void{
   this.api.GetAppoitnmentDetails(this.id).subscribe(result=>{
    this.appointment=result
   });
 }





//for popup
 openPopup() {
  let popup = document.getElementById('popup');
  popup?.classList.add('open');
}
closePopup() {
  let popup = document.getElementById('popup');
  popup?.classList.remove('open');
}
openPopup1() {
  let popup = document.getElementById('popup1');
  popup?.classList.add('open');
}
closePopup1() {
  let popup = document.getElementById('popup1');
  popup?.classList.remove('open');
}
}
