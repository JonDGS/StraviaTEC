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
  challenges: Challenge[];

  constructor(private oService: OrganizerService) { }

  ngOnInit(): void {
    this.challenges = this.oService.myCreatedChallenges;
  }

  /**
   * This method is called when  a new challenge is created
   */
  addChallenge(): void {
    console.log(this.challengeForm);
  }

  /**
   * This method is called when a challenge from the challenge list is deleted
   * @param challenge to delete
   */
  onDeleteChallenge(challenge: Challenge): void {
  }
}
