import { Component, OnInit } from '@angular/core';
import {Challenge} from '../../../../models/challenge.model';
import {AthleteService} from '../../../athlete.service';

@Component({
  selector: 'app-participating-challenges',
  templateUrl: './participating-challenges.component.html',
  styleUrls: ['./participating-challenges.component.css']
})
export class ParticipatingChallengesComponent implements OnInit {
  currentChallenges: Challenge[];

  constructor(private aService: AthleteService) {
    this.currentChallenges = this.aService.participatingChallenges;
  }

  ngOnInit(): void {
  }

}
