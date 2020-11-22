import { ServerService } from './../../../../server.service';
import {Component, Input, OnInit} from '@angular/core';
import {AthleteService} from '../../../athlete.service';

@Component({
  selector: 'app-search-item',
  templateUrl: './search-item.component.html',
  styleUrls: ['./search-item.component.css']
})

/**
 * This component is used for displaying the individual search item
 */
export class SearchItemComponent implements OnInit {
  searchItemType: string;
  @Input() searchItem: any;

  constructor(private aService: AthleteService, private server:ServerService) { }

  ngOnInit(): void {
    this.searchItemType = this.aService.searchType;
  }

  /**
   * This method is called when a searched user is followed
   * @param username of the followed athlete
   */
  onFollowAthlete(username: string): void{
    console.log('Now following:' + username);
  }

  /**
   * This method is called when a searched group is joined
   * @param name of the joined group
   * @param admin of the joined group
   */
  onJoinGroup(idGroup): void {
    let params = {
      "id_group":idGroup
  }
    this.server.joinGroup(params);
  }

  onJoinRace(idRace): void {
    let params = {
      "id_race":idRace,
      "status":"Pending",
      "receipt":null
  }
    this.server.joinRace(params);
  }
}
