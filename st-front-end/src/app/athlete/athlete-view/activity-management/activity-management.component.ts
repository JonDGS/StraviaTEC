import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-activity-management',
  templateUrl: './activity-management.component.html',
  styleUrls: ['./activity-management.component.css']
})
/**
 * This component holds the form for adding a new a activity to the athlete
 */
export class ActivityManagementComponent implements OnInit {
  @ViewChild('activityForm') activityForm: NgForm;

  constructor() { }

  ngOnInit(): void {
  }

  // This will be a connection with http service PostActivity
  /**
   * This function is called when a new activity is added, it should call the http service
   * and post the new activity to the server
   */
  onSubmit(): void{
    console.log(this.activityForm);
  }

}
