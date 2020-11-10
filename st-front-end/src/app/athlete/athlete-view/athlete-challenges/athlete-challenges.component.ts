import { Component, OnInit } from '@angular/core';
import {Challenge} from '../../../models/challenge.model';
import {AthleteService} from '../../athlete.service';

@Component({
  selector: 'app-athlete-challenges',
  templateUrl: './athlete-challenges.component.html',
  styleUrls: ['./athlete-challenges.component.css']
})
export class AthleteChallengesComponent implements OnInit {
  challenges: Challenge[];

  constructor(private aService: AthleteService) { }

  ngOnInit(): void {
    this.challenges = this.aService.challenges;
  }

}
