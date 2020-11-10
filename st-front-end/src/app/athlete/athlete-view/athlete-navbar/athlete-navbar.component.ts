import {Component, OnInit, ViewChild} from '@angular/core';
import {NgForm} from '@angular/forms';
import {AthleteService} from '../../athlete.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './athlete-navbar.component.html',
  styleUrls: ['./athlete-navbar.component.css']
})

/**
 * This component is the navigation bar of the athlete view, it allows to change routes between
 * search items, user settings, available challenges and the home-view
 */
export class NavbarComponent implements OnInit {
  @ViewChild('searchForm') searchForm: NgForm;
  defaultCategory = 'athlete';
  changedView: boolean;

  constructor(private aService: AthleteService) { }

  ngOnInit(): void {
    this.changedView = this.aService.onChangedView;
  }

  /**
   * Is called when the search form is used
   */
  onSearch(): void{
    console.log(this.searchForm);
  }

  /**
   * This method keeps track of the changed state of the home view,
   * in other words it indicates when the home page is not being displayed
   */
  onAthleteViewChanged(): void {
    this.aService.onChangedView = true;
  }

  /**
   * This method is called when the home page view is returned
   */
  onAthleteViewReturned(): void {
    this.aService.onChangedView = false;
  }
}
