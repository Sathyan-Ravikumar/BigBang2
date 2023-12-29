import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DocterdetailsComponent } from './docterdetails.component';

describe('DocterdetailsComponent', () => {
  let component: DocterdetailsComponent;
  let fixture: ComponentFixture<DocterdetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DocterdetailsComponent]
    });
    fixture = TestBed.createComponent(DocterdetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
