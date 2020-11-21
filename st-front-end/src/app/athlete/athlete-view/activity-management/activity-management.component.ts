import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AthleteService } from '../../athlete.service';

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

  constructor(private aService:AthleteService) { }

  ngOnInit(): void {
  }

  //This will be a conection with http servicer PostActivity
  onSubmit(){
    let date = new Date(this.activityForm.value.date)
    let activity = {
      "clasification":this.activityForm.value.classification,
      "closing_time":8,
      "starting_time":5,
      "d_day":date.getDay(),
      "d_month":date.getMonth(),
      "d_year":date.getFullYear(),
      "distance":this.activityForm.value.spinner,
      "id_type":this.activityForm.value.type
  }
    this.aService.postActivity(activity);
  }

}
