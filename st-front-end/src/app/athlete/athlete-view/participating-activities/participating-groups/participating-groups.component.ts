import { ServerService } from './../../../../server.service';
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
  currentGroups: any;

  constructor(private aService: AthleteService, private server:ServerService) { }

  ngOnInit(): void {
    this.server.getGroupAthleteByToken().then(res => {
      this.currentGroups = res;
    })
  }

}
