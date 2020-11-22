import { ServerService } from './../server.service';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {Athlete} from '../models/athlete.model';
import {Challenge} from '../models/challenge.model';
import {Group} from '../models/group.model';
import {Race} from '../models/race.model';

@Injectable({
  providedIn: 'root'
})

/**
 * This service is used for the management of the athlete view, it stores the shared information
 * among the different components and calls for the http methods of the server.service
 */
export class AthleteService {

  //token
  public token;
  //set token
  setToken(token){
    this.token = token;
  }
  // Used for storing the information of the current user
  currentUser: any;

  /*
    Used for checking if the athlete home page view was changed (/athlete), mainly works for activating the return button
    on the athlete-navbar
   */
  changedView = false;

  // Used for storing the available challenges to display in the athlete/challenges page
  challenges = [
    new Challenge( '1', 'West Challenge', '30 days', 'Running', 'Fondo?', 60, []),
    new Challenge( '2', 'North Challenge', '20 days', 'Swimming', 'Fondo?', 35, []),
    new Challenge( '3', 'South Challenge', '10 days', 'Kayaking', 'Fondo?', 40, [])
  ];

  /*
    This variables are going to be used for displaying the  search results, should be filled
    with the info given by a search. Currently they are being filled manually
   */
  searchType: string;
  availableGroups = [
    new Group('FastBois', '1', 'Jesus'),
    new Group('FastMen', '2', 'Cris')
    ];
  availableAthletes = [
    new Athlete(
      'Alvaro',
      'Vargas',
      'Molina',
      'Costa Rican',
      117730762,
      20,
      '3/4/2000',
      'Costa Rica',
      'Heredia',
      'Belen',
      'avargasm',
      '',
      'abc123'),
    new Athlete(
      'Jon',
      'Dor',
      'ito',
      'Costa Rican',
      117720889,
      20,
      '8/6/2000',
      'Costa Rica',
      'San Jose',
      'Tres Rios',
      'sk8r',
      '',
      '123abc')
  ];
  availableRaces = [
    new Race(
      '1',
      'Mario Circuit',
      '4/4/2021',
      '9000',
      '',
      'Kayak',
      '123'),
    new Race(
      '2',
      'Mew Mew Medows',
      '7/7/2021',
      '5000',
      '',
      'Running',
      '321')
  ];

  //search Data
  public searchData;
  
  /*
    This lists are for the participating activities, should be filled with the info of the currently
    participating groups, races and challenges. For the moment we are filling them with the search lists
   */
  participatingChallenges = this.challenges;
  participatingRaces = this.availableRaces;
  participatingGroups = this.availableGroups;

  constructor(private server:ServerService) {

    
  }

  setSearhData(data){
    this.searchData = data;
  }

  getSearchData(){
    return this.searchData;
  }

  logout(){
    this.server.httplogout(this.token);
  };

  getFollowes(){
   return this.server.getFollowees();
  }

  postActivity(activity){
    this.server.postActivity(activity);
  }

  setCurrenUser(){
    this.server.getInfo().then(res => {
      this.currentUser = res;
    })
  }
}
