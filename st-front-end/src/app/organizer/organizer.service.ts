import { ServerService } from './../server.service';
import { Injectable } from '@angular/core';
import {Challenge} from '../models/challenge.model';
import {Group} from '../models/group.model';
import {Athlete} from '../models/athlete.model';
import {Race} from '../models/race.model';

@Injectable({
  providedIn: 'root'
})
export class OrganizerService {
  /*
    Used for checking if the organizer home page view was changed (/organizer), mainly works for activating the return button
    on the organizer-navbar
   */
  changedView = false;


  constructor(private server:ServerService) {
    
  }

  // These lists are for showing the created challenges, groups and races
  myCreatedChallenges = [
    new Challenge(
      '1',
      'West Challenge',
      '30 days',
      'Running',
      'Fondo?',
      60,
      []),
    new Challenge(
      '2',
      'North Challenge',
      '20 days',
      'Swimming',
      'Fondo?',
      35,
      []),
    new Challenge(
      '3',
      'South Challenge',
      '10 days',
      'Kayaking',
      'Fondo?',
      40,
      [])
  ];
  myCreatedGroups = [
    new Group(
      'FastBois',
      '1',
      'Jesus'),
    new Group(
      'FastMen',
      '2',
      'Cris')
  ];
  public myCreatedRaces;


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
