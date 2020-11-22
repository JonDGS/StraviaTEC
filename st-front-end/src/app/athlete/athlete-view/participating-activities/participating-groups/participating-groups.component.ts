import { Component, OnInit } from '@angular/core';
import {Group} from '../../../../models/group.model';
import {AthleteService} from '../../../athlete.service';

@Component({
  selector: 'app-participating-groups',
  templateUrl: './participating-groups.component.html',
  styleUrls: ['./participating-groups.component.css']
})

/**
 * This class is used a widget for displaying the groups the user is currently participating on
 */
export class ParticipatingGroupsComponent implements OnInit {
  currentGroups: Group[];

  constructor(private aService: AthleteService) { }

  ngOnInit(): void {
    this.currentGroups = this.aService.participatingGroups;
  }
}
