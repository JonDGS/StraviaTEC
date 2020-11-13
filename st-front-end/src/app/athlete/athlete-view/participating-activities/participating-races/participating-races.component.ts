import { Component, OnInit } from '@angular/core';
import {Race} from '../../../../models/race.model';
import {AthleteService} from '../../../athlete.service';

@Component({
  selector: 'app-participating-races',
  templateUrl: './participating-races.component.html',
  styleUrls: ['./participating-races.component.css']
})
export class ParticipatingRacesComponent implements OnInit {
  currentRaces: Race[];

  constructor(private aService: AthleteService) {
    this.currentRaces = this.aService.participatingRaces;
  }

  ngOnInit(): void {
  }

}
