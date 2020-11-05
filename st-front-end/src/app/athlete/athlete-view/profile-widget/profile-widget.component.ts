import { Component, OnInit } from '@angular/core';
import {Athlete} from '../../../models/athlete.model';
import {AthleteService} from '../../athlete.service';

@Component({
  selector: 'app-profile-widget',
  templateUrl: './profile-widget.component.html',
  styleUrls: ['./profile-widget.component.css']
})
export class ProfileWidgetComponent implements OnInit {
  user: Athlete = this.aService.currentUser;

  constructor(private aService: AthleteService) { }

  ngOnInit(): void {
  }

}
