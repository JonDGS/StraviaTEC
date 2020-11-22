import { ServerService } from './../../../server.service';
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
  organizer: any;
  oName: string;
  oLastName1: string;
  oLastName2: string;
  oCountry: string;
  oState: string;
  oCity: string;

  constructor(private oService: OrganizerService, private server: ServerService) { }

  ngOnInit(): void {
    this.server.getInfoOrganizer().then(res => {
      this.organizer = res;
      this.oName = this.organizer.name;
      this.oLastName1 = this.organizer.lastname_1;
      this.oLastName2 = this.organizer.lastname_2;
      this.oCountry = this.organizer.country;
      this.oState = this.organizer.state;
      this.oCity = this.organizer.city;
    })
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
      console.log(this.organizer.username + ' account is going to be deleted');
    }
  }

}
