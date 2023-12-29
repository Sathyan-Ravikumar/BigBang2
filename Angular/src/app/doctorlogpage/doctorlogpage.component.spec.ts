import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DoctorlogpageComponent } from './doctorlogpage.component';

describe('DoctorlogpageComponent', () => {
  let component: DoctorlogpageComponent;
  let fixture: ComponentFixture<DoctorlogpageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DoctorlogpageComponent]
    });
    fixture = TestBed.createComponent(DoctorlogpageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
