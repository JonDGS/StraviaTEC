import {Component, OnInit, ViewChild} from '@angular/core';
import {OrganizerService} from '../../organizer.service';
import {Challenge} from '../../../models/challenge.model';
import {NgForm} from '@angular/forms';
import { FnParam } from '@angular/compiler/src/output/output_ast';

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
    
    let object = {
      "token" :  null,
      "name"  : this.challengeForm.value.name,
      "startdate" : this.challengeForm.value.period,
      "finishdate" : this.challengeForm.value.period,
      "activity_type" : this.challengeForm.value.activityType,
      "challengetype" : this.challengeForm.value.type,
      "distancetravelled" : this.challengeForm.value.distance
    }
    this.oService.postChallange(object);
  }
}
