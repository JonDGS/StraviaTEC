import { Component, OnInit } from '@angular/core';
import {Athlete} from '../../../models/athlete.model';
import {AthleteService} from '../../athlete.service';

@Component({
  selector: 'app-profile-widget',
  templateUrl: './profile-widget.component.html',
  styleUrls: ['./profile-widget.component.css']
})

/**
 * This component works as a widget to display the main information of the athlete
 */
export class ProfileWidgetComponent implements OnInit {
  user: Athlete = this.aService.currentUser;

  constructor(private aService: AthleteService) { }

  ngOnInit(): void {
  }
}
