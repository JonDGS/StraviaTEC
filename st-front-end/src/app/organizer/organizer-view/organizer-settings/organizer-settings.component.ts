import {Component, OnInit, ViewChild} from '@angular/core';
import {NgForm} from '@angular/forms';
import {Athlete} from '../../../models/athlete.model';
import {Organizer} from '../../../models/organizer.model';
import {OrganizerService} from '../../organizer.service';

@Component({
  selector: 'app-organizer-settings',
  templateUrl: './organizer-settings.component.html',
  styleUrls: ['./organizer-settings.component.css']
})

/**
 * This component is used for changing the organizer user profile
 */
export class OrganizerSettingsComponent implements OnInit {
  @ViewChild('updateProfileForm') profileForm: NgForm;
  organizer: Organizer;
  oName: string;
  oLastName1: string;
  oLastName2: string;
  oCountry: string;
  oState: string;
  oCity: string;

  constructor(private oService: OrganizerService) { }

  ngOnInit(): void {
    this.organizer = this.oService.currentOrganizer;
    this.oName = this.oService.currentOrganizer.name;
    this.oLastName1 = this.oService.currentOrganizer.lastName1;
    this.oLastName2 = this.oService.currentOrganizer.lastName2;
    this.oCountry = this.oService.currentOrganizer.country;
    this.oState = this.oService.currentOrganizer.state;
    this.oCity = this.oService.currentOrganizer.city;
  }

  /**
   * This method is called whenever a user decides to update its information
   */
  onUpdateProfile(): void {
    console.log(this.profileForm);
  }

  /**
   * This method is called when the user decides to delete its account
   */
  onDeleteAccount(): void {
    if (confirm('Are you sure you want to delete your account? The information contained in it will be lost forever')) {
      console.log(this.oService.currentOrganizer.username + ' account is going to be deleted');
    }
  }

}
