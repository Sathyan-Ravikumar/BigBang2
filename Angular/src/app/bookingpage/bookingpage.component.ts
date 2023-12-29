import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators, ReactiveFormsModule, ValidatorFn, AbstractControl } from '@angular/forms';
import { BookingServices } from '../Services/Booking.service';

@Component({
  selector: 'app-bookingpage',
  templateUrl: './bookingpage.component.html',
  styleUrls: ['./bookingpage.component.css']
})
export class BookingpageComponent {
  
  bookingForm!: FormGroup;

  constructor(private formBuilder: FormBuilder, private api:BookingServices) { }

  ngOnInit() {
    this.initForm();
  }

  initForm() {
    this.bookingForm = this.formBuilder.group({
      userid:[Number(localStorage.getItem("userid"))],
      doctorid: ['', [Validators.required,Validators.pattern('^(100[1-9]|10[1-9][0-9]|1100)$')]],
      patientName: ['', [Validators.required, Validators.pattern('[a-zA-Z ]*')]],
      patientAge: ['', [Validators.required, Validators.pattern('^(0?[1-9]|[1-9][0-9])$')]],
      patientGender: ['', [Validators.required, Validators.pattern('^(male|female|Male|Female)$')]],
      patientAddress: ['', Validators.required],
      patientNumber: ['', [Validators.required, Validators.pattern('^[6789]\\d{9}$')]],
      specializationPatientNeed: ['', Validators.required],
      visitingDate: ['', [Validators.required,this.dateWithinRangeValidator(10)]],
      appoitmentTime: ['', [Validators.required,this.timeWithinRangeValidator('10:00', '16:00')]]
    });
  }
  //to check the date
  dateWithinRangeValidator(maxDays: number): ValidatorFn {
    return (control: AbstractControl): { [key: string]: any } | null => {
      const selectedDate = new Date(control.value);
      const currentDate = new Date();
      const maxAllowedDate = new Date(currentDate.getFullYear(), currentDate.getMonth(), currentDate.getDate() + maxDays);

      if (selectedDate > maxAllowedDate) {
        return { dateOutOfRange: true };
      }
      
      return null;
    };
  }
  //to check the time
  timeWithinRangeValidator(startTime: string, endTime: string): ValidatorFn {
    return (control: AbstractControl): { [key: string]: any } | null => {
      const selectedTime = control.value;
      const [selectedHour, selectedMinute] = selectedTime.split(':');
      const [startHour, startMinute] = startTime.split(':');
      const [endHour, endMinute] = endTime.split(':');

      const selectedDateTime = new Date();
      selectedDateTime.setHours(Number(selectedHour));
      selectedDateTime.setMinutes(Number(selectedMinute));

      const startDateTime = new Date();
      startDateTime.setHours(Number(startHour));
      startDateTime.setMinutes(Number(startMinute));

      const endDateTime = new Date();
      endDateTime.setHours(Number(endHour));
      endDateTime.setMinutes(Number(endMinute));

      if (selectedDateTime < startDateTime || selectedDateTime > endDateTime) {
        return { timeOutOfRange: true };
      }

      return null;
    };
  }


  isFieldInvalid(fieldName: string) {
    const field = this.bookingForm.get(fieldName);
    return field!.invalid && (field!.dirty || field!.touched);
  }

  bookAppointment() : void{
    {
      this.api.posttheDetails(this.bookingForm.value).subscribe(
        () => {
          alert('Appointment booked successfully!'); 
        },
        (error) => {
          alert('Error while booking appointment: ' + error.message);
          
        }
      );

    
    }
  }

  openPopup() {
    let popup = document.getElementById('popup');
    popup?.classList.add('open');
  }
  closePopup() {
    let popup = document.getElementById('popup');
    popup?.classList.remove('open');
  }
}
