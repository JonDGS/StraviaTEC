import {Component, OnInit, ViewChild} from '@angular/core';
import {Race} from '../../../models/race.model';
import {OrganizerService} from '../../organizer.service';
import {NgForm} from '@angular/forms';

@Component({
  selector: 'app-organizer-races',
  templateUrl: './organizer-races.component.html',
  styleUrls: ['./organizer-races.component.css']
})

/**
 * This class holds all the related information to the races of the organizer view. It holds a list of
 * the created races of the current organizer, a form for adding a new race and section for editing and
 * deleting the races
 */
export class OrganizerRacesComponent implements OnInit {
  @ViewChild('newRace') raceForm: NgForm;
  races: Race[];

  constructor(private oService: OrganizerService) { }

  ngOnInit(): void {
    this.races = this.oService.myCreatedRaces;
  }

  /**
   * This method is called when  a new race is created
   */
  addRace(): void {
    console.log(this.raceForm);
  }

}
