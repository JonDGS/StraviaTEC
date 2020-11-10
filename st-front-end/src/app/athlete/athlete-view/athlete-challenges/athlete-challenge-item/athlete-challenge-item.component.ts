import {Component, Input, OnInit} from '@angular/core';
import {Challenge} from '../../../../models/challenge.model';

@Component({
  selector: 'app-athlete-challenge-item',
  templateUrl: './athlete-challenge-item.component.html',
  styleUrls: ['./athlete-challenge-item.component.css']
})
export class AthleteChallengeItemComponent implements OnInit {
  @Input() challenge: Challenge;

  constructor() { }

  ngOnInit(): void {
  }

  onJoinChallenge(): void{
    console.log(this.challenge.name + ' joined!');
  }
}
