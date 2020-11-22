import { ServerService } from './../server.service';
import { Injectable, OnInit } from '@angular/core';
import {Challenge} from '../models/challenge.model';
import {Group} from '../models/group.model';
import {Athlete} from '../models/athlete.model';
import {Race} from '../models/race.model';
import {Organizer} from '../models/organizer.model';

@Injectable({
  providedIn: 'root'
})
export class OrganizerService implements OnInit{
  public currentOrganizer;

  /*
    Used for checking if the organizer home page view was changed (/organizer), mainly works for activating the return button
    on the organizer-navbar
   */
  changedView = false;


  constructor(private server: ServerService) {

  }

  

  // These lists are for showing the created challenges, groups and races
  public myCreatedChallenges;
  public myCreatedGroups;
  public myCreatedRaces;

  ngOnInit(): void {
    this.server.getGroupByToken().then(res => {
      this.myCreatedGroups = res;
    })

    this.server.getInfoOrganizer().catch(res => {
      this.currentOrganizer = res;
    })
  }
  getRaces(){
    return this.server.getRacesByToken();
  }
  logout(){

  }
  /**
   *
   * @param race
   */
  postRace(race){
    this.server.postRace(race);
  }

  postGroup(group){
    this.server.postGroup(group);
  }
  postChallange(challange){
    this.server.postChallange(challange);
  }
}
