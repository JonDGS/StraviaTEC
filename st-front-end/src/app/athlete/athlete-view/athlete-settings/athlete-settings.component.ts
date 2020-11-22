import { ServerService } from './../../../server.service';
import {Component, OnInit, ViewChild} from '@angular/core';
import {Athlete} from '../../../models/athlete.model';
import {AthleteService} from '../../athlete.service';
import {NgForm} from '@angular/forms';

@Component({
  selector: 'app-athlete-settings',
  templateUrl: './athlete-settings.component.html',
  styleUrls: ['./athlete-settings.component.css']
})

/**
 * This component is used for changing the athlete user profile
 */
export class AthleteSettingsComponent implements OnInit {
  @ViewChild('updateProfileForm') profileForm: NgForm;
  athlete: any;
  aName: string;
  aLastName1: string;
  aLastName2: string;
  aNationality: string;
  aCountry: string;
  aState: string;
  aCity: string;

  constructor(private aService: AthleteService, private server:ServerService) { }

  ngOnInit(): void {
    this.server.getInfo().then(res => {
      this.athlete = res;
      this.aName = this.athlete.name;
      this.aLastName1 = this.athlete.lastname_1;
      this.aLastName2 = this.athlete.lastname_2;
      this.aNationality = this.athlete.nationality;
      this.aCountry = this.athlete.country;
     this.aState = this.athlete.state;
      this.aCity = this.athlete.city;
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
      console.log(this.aService.currentUser.username + ' account is going to be deleted');
    }
  }
}
