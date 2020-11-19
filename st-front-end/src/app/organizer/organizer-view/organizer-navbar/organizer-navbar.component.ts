import { Component, OnInit } from '@angular/core';
import {OrganizerService} from '../../organizer.service';

@Component({
  selector: 'app-organizer-navbar',
  templateUrl: './organizer-navbar.component.html',
  styleUrls: ['./organizer-navbar.component.css']
})

/**
 * This component is the navigation bar of the organizer view, it allows to go the organizer settings and return
 * and has a logout button for returning to the home page
 */
export class OrganizerNavbarComponent implements OnInit {
  changedView: boolean;

  constructor(private oService: OrganizerService) { }

  ngOnInit(): void {
    this.changedView = this.oService.changedView;
  }

  /**
   * This method keeps track of the changed state of the organizer home page,
   * in other words it indicates when the athlete home page is not being displayed
   */
  onOrganizerViewChanged(): void {
    this.oService.changedView = true;
  }

  /**
   * This method is called when the organizer home page view is returned
   */
  onOrganizerViewReturned(): void {
    this.oService.changedView = false;
  }

  /**
   * This method is used for the user to logout and return to the home page
   */
  onOrganizerLogout(): void {

  }
}
