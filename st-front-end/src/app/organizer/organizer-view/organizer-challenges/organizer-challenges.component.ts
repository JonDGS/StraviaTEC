import { ServerService } from './../../../server.service';
import {Component, OnInit, ViewChild} from '@angular/core';
import {OrganizerService} from '../../organizer.service';
import {Challenge} from '../../../models/challenge.model';
import {NgForm} from '@angular/forms';
import {Race} from '../../../models/race.model';
import {Sponsor} from '../../../models/sponsor.model';
import {Router} from '@angular/router';

@Component({
  selector: 'app-organizer-challenges',
  templateUrl: './organizer-challenges.component.html',
  styleUrls: ['./organizer-challenges.component.css']
})

/**
 * This class holds all the related information to the challenges of the organizer view. It holds a list of
 * the created challenges of the current organizer, a form for adding a new challenge and section for editing and
 * deleting the challenges
 */
export class OrganizerChallengesComponent implements OnInit {
  @ViewChild('newChallenge') challengeForm: NgForm;
  @ViewChild('updateChallengeForm') updateForm: NgForm;
  challenges: any;
  isUpdateForm;
  challengeToUpdate: Challenge;
  ucName: string;
  ucPeriod: string;
  ucType: string;
  ucActivityType: string;
  ucDistance: number;
  ucSponsors: Sponsor[];



  constructor(private oService: OrganizerService,private server:ServerService) { 
    this.isUpdateForm = false;
  }

  ngOnInit(): void {
    
    this.server.getChallengesOrganizerByToken().then(res => {
      this.challenges = res;
    })
  }

  /**
   * This method is called when  a new challenge is created
   */
  addChallenge(): void {
    let object = {
      "token" :  null,
      "name"  : this.challengeForm.value.name,
      "startdate" :  "2002-11-10",
      "finishdate" :  "2002-11-15",
      "activity_type" : this.challengeForm.value.activityType,
      "challengetype" : this.challengeForm.value.type,
      "distancetravelled" : parseInt(this.challengeForm.value.distance)
    };
    this.oService.postChallange(object);
  }

  /**
   * This method is called when a challenge from the challenge list is deleted
   * @param challenge to delete
   */
  onDeleteChallenge(challenge): void {
    this.server.deleteChallenge(challenge);
  }

  /**
   * This method is called when the update button is called. This method sets the boolean var
   * for showing the update form and also sets a series of variables that fill the update form
   * @param challenge to update
   */
  onUpdateChallenge(challenge: Challenge): void {
    this.challengeToUpdate = challenge;
    this.isUpdateForm = true;
    this.ucName = this.challengeToUpdate.name;
    this.ucPeriod = this.challengeToUpdate.period;
    this.ucType = this.challengeToUpdate.type;
    this.ucActivityType = this.challengeToUpdate.activityType;
    this.ucDistance = this.challengeToUpdate.distance;
    this.ucSponsors = [];
  }

  /**
   * This method is called when the update form is submitted
   */
  updateChallenge(): void {
    this.isUpdateForm = false;
  }
}
