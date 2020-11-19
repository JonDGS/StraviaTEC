import { Component, OnInit } from '@angular/core';
import {Challenge} from '../../../../models/challenge.model';
import {AthleteService} from '../../../athlete.service';

@Component({
  selector: 'app-participating-challenges',
  templateUrl: './participating-challenges.component.html',
  styleUrls: ['./participating-challenges.component.css']
})

/**
 * This class is used a widget for displaying the challenges the user is currently participating on
 */
export class ParticipatingChallengesComponent implements OnInit {
  currentChallenges: Challenge[];

  constructor(private aService: AthleteService) {
    this.currentChallenges = this.aService.participatingChallenges;
  }

  ngOnInit(): void {
  }

}
