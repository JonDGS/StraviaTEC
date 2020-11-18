import {Component, OnInit, ViewChild} from '@angular/core';
import {Race} from '../../../models/race.model';
import {OrganizerService} from '../../organizer.service';
import {NgForm} from '@angular/forms';

@Component({
  selector: 'app-organizer-races',
  templateUrl: './organizer-races.component.html',
  styleUrls: ['./organizer-races.component.css']
})
export class OrganizerRacesComponent implements OnInit {
  @ViewChild('newRace') raceForm: NgForm;
  races: Race[];

  constructor(private oService: OrganizerService) { }

  ngOnInit(): void {
    this.races = this.oService.myCreatedRaces;
  }

  addRace(): void {
    console.log(this.raceForm);
  }

}
