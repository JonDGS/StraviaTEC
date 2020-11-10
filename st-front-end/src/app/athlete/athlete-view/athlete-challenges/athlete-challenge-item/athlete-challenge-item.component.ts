import {Component, Input, OnInit} from '@angular/core';
import {Challenge} from '../../../../models/challenge.model';

@Component({
  selector: 'app-athlete-challenge-item',
  templateUrl: './athlete-challenge-item.component.html',
  styleUrls: ['./athlete-challenge-item.component.css']
})

/**
 * This component is used for displaying an individual challenge and giving the chance to the athlete
 * to join it
 */
export class AthleteChallengeItemComponent implements OnInit {
  @Input() challenge: Challenge;

  constructor() { }

  ngOnInit(): void {
  }

  /**
   * This method is called when a challenge-item join button is clicked
   */
  onJoinChallenge(): void{
    console.log(this.challenge.name + ' joined!');
  }
}

