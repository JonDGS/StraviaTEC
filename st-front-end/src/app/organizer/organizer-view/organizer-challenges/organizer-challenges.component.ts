import {Component, OnInit, ViewChild} from '@angular/core';
import {OrganizerService} from '../../organizer.service';
import {Challenge} from '../../../models/challenge.model';
import {NgForm} from '@angular/forms';

@Component({
  selector: 'app-organizer-challenges',
  templateUrl: './organizer-challenges.component.html',
  styleUrls: ['./organizer-challenges.component.css']
})
export class OrganizerChallengesComponent implements OnInit {
  @ViewChild('newChallenge') challengeForm: NgForm;
  challenges: Challenge[];

  constructor(private oService: OrganizerService) { }

  ngOnInit(): void {
    this.challenges = this.oService.myCreatedChallenges;
  }

  addChallenge(): void {
    console.log(this.challengeForm);
  }
}
