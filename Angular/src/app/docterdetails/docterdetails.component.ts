import { Component } from '@angular/core';
import { DoctorDetailsService } from '../Services/DoctorDetailsPage.service';

@Component({
  selector: 'app-docterdetails',
  templateUrl: './docterdetails.component.html',
  styleUrls: ['./docterdetails.component.css']
})
export class DocterdetailsComponent {
  public doctor:any;
  ngOnInit(): void {
    this.getdocdetails();
  }
  
  constructor(private api:DoctorDetailsService){}

  private getdocdetails():void{
    this.api.getallDoctorDetails().subscribe(result=>{
      this.doctor=result
    })
  }
}
