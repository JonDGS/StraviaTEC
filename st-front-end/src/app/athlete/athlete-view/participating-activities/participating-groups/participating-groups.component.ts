import { Component, OnInit } from '@angular/core';
import {Group} from '../../../../models/group.model';
import {AthleteService} from '../../../athlete.service';

@Component({
  selector: 'app-participating-groups',
  templateUrl: './participating-groups.component.html',
  styleUrls: ['./participating-groups.component.css']
})
export class ParticipatingGroupsComponent implements OnInit {
  currentGroups: Group[];

  constructor(private aService: AthleteService) { }

  ngOnInit(): void {
    this.currentGroups = this.aService.participatingGroups;
  }

}
