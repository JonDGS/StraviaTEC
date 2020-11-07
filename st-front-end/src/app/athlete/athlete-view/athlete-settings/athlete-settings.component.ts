import {Component, OnInit, ViewChild} from '@angular/core';
import {Athlete} from '../../../models/athlete.model';
import {AthleteService} from '../../athlete.service';
import {NgForm} from '@angular/forms';

@Component({
  selector: 'app-athlete-settings',
  templateUrl: './athlete-settings.component.html',
  styleUrls: ['./athlete-settings.component.css']
})
export class AthleteSettingsComponent implements OnInit {
  @ViewChild('updateProfileForm') profileForm: NgForm;
  athlete: Athlete;
  aName: string;
  aLastName: string;
  aNationality: string;
  aCountry: string;
  aState: string;
  aCity: string;

  constructor(private aService: AthleteService) { }

  ngOnInit(): void {
    this.athlete = this.aService.currentUser;
    this.aName = this.athlete.name;
    this.aLastName = this.athlete.lastName;
    this.aNationality = this.athlete.nationality;
    this.aCountry = this.athlete.country;
    this.aState = this.athlete.state;
    this.aCity = this.athlete.city;
  }

  onUpdateProfile(): void {
    console.log(this.profileForm);
  }
}
