import { Activity } from './../../../models/activity.model';
import { Component, OnInit } from '@angular/core';
import { AthleteService } from '../../athlete.service';

@Component({
  selector: 'app-activity-feed',
  templateUrl: './activity-feed.component.html',
  styleUrls: ['./activity-feed.component.css']
})
export class ActivityFeedComponent implements OnInit {

//Api map image key
  apiKey : string = 'Z-68H2MHBYk-Y6CrvdYh37u5eGTqF49qoIGkmjWNczM&w';
//list of activities 
  public activities;

  constructor(private aService:AthleteService) {
    this.generateActivities()
   }

  ngOnInit(): void {
  }

  /**
   * generateActivities 
   * 
   * Just for develoment porpuse 
   * --> GetActivities(){}
   */
  generateActivities(){
   // this.activities = [new Activity(new Date(),"2:00pm","1hr","Running arround the hometown","10km","GPX","Activity",),
  // new Activity(new Date(),"2:00pm","1hr","Run","11km","GPX","Race",)]
    this.aService.getFollowes().subscribe(res => {
      console.log(res);
      
      this.activities = res;
    });
    

}
}