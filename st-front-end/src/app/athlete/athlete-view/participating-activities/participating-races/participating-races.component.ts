import { ServerService } from './../../../../server.service';
import { Component, OnInit } from '@angular/core';
import {Race} from '../../../../models/race.model';
import {AthleteService} from '../../../athlete.service';

@Component({
  selector: 'app-participating-races',
  templateUrl: './participating-races.component.html',
  styleUrls: ['./participating-races.component.css']
})

/**
 * This class is used a widget for displaying the races the user is currently participating on
 */
export class ParticipatingRacesComponent implements OnInit {
  currentRaces: any;

  constructor(private aService: AthleteService, private server:ServerService) {
    this.server.getRacesAtheleByToken().then( res => {
      this.currentRaces = res;
    })
  }

  ngOnInit(): void {
  }
}
