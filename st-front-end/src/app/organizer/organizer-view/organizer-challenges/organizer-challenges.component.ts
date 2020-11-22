import { ServerService } from './../../../server.service';
import {Component, OnInit, ViewChild} from '@angular/core';
import {OrganizerService} from '../../organizer.service';
import {Challenge} from '../../../models/challenge.model';
import {NgForm} from '@angular/forms';
import {Race} from '../../../models/race.model';

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
  challenges: any;

  constructor(private oService: OrganizerService,private server:ServerService) { }

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
    }
    this.oService.postChallange(object);
  }

  /**
   * This method is called when a challenge from the challenge list is deleted
   * @param challenge to delete
   */
  onDeleteChallenge(challenge: Challenge): void {
  }
}
