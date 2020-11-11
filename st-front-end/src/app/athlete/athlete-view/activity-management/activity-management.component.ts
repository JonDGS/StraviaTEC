import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-activity-management',
  templateUrl: './activity-management.component.html',
  styleUrls: ['./activity-management.component.css']
})
export class ActivityManagementComponent implements OnInit {
  @ViewChild('activityForm') activityForm: NgForm;

  constructor() { }

  ngOnInit(): void {
  }

  //This will be a conection with http servicer PostActivity
  onSubmit(){
    console.log(this.activityForm);
  }


}
