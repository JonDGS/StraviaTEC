import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import {OrganizerService} from '../../organizer.service';

@Component({
  selector: 'app-organizer-navbar',
  templateUrl: './organizer-navbar.component.html',
  styleUrls: ['./organizer-navbar.component.css']
})
export class OrganizerNavbarComponent implements OnInit {
  changedView: boolean;

  constructor(private oService: OrganizerService,private router: Router) { }

  ngOnInit(): void {
    this.changedView = this.oService.changedView;
  }

  onOrganizerViewChanged(): void {
    this.oService.changedView = true;
  }

  onOrganizerViewReturned(): void {
    this.oService.changedView = false;
  }

  goToPage(pageName:string){
    this.router.navigate([`${pageName}`]);
    console.log("Login form");
  }

  onOrganizerLogout(): void {
    this.goToPage('');
  }
}
