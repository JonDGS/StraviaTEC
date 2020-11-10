import { Component, OnInit } from '@angular/core';
import {Challenge} from '../../../models/challenge.model';
import {AthleteService} from '../../athlete.service';

@Component({
  selector: 'app-athlete-challenges',
  templateUrl: './athlete-challenges.component.html',
  styleUrls: ['./athlete-challenges.component.css']
})

/**
 * This component is used for displaying the available challenges of the athlete view, this
 * is made by creating a list of athlete-challenges-item components
 */
export class AthleteChallengesComponent implements OnInit {
  challenges: Challenge[];

  constructor(private aService: AthleteService) { }

  ngOnInit(): void {
    this.challenges = this.aService.challenges;
  }
}
