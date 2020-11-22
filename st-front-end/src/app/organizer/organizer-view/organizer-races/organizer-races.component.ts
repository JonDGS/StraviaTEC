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
  @ViewChild('updateRaceForm') updateForm: NgForm;
  public races;
  raceToUpdate: Race;
  isUpdateForm: boolean;
  urName: string;
  urType: string;
  urCost: string;
  urBankAccount: string;


  constructor(private oService: OrganizerService) {
    this.isUpdateForm = false;
  }

  ngOnInit(): void {
    this.oService.getRaces().subscribe(res => {
      console.log(res);

      this.races = res
      console.log(this.races);

    }
    );


  }

  /**
   * This method is called when  a new race is created
   */
  addRace(): void {
    let race = {
      "name": this.raceForm.value.name,
      "date": this.raceForm.value.date,
      "cost": this.raceForm.value.race,
      "gpx": null,
      "country": this.raceForm.value.bankAccount
  }
      this.oService.postRace(race);
  }

  /**
   * This method is called when a race from the race list is deleted
   * @param race to delete
   */
  onDeleteRace(race: Race): void {
  }

  onUpdateRace(race: Race): void {
    this.raceToUpdate = race;
    this.isUpdateForm = true;
    this.urName =  this.raceToUpdate.name;
    this.urType =  this.raceToUpdate.type;
    this.urCost =  this.raceToUpdate.cost;
    this.urBankAccount =  this.raceToUpdate.bankAccount;
  }

  updateRace(): void {
    this.isUpdateForm = false;
  }
}
