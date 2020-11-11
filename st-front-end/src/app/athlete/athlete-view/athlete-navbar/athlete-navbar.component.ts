import {Component, OnInit, ViewChild} from '@angular/core';
import {NgForm} from '@angular/forms';
import {AthleteService} from '../../athlete.service';
import {Athlete} from '../../../models/athlete.model';
import {Router} from '@angular/router';

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
  defaultCategory = 'athletes';
  changedView: boolean;

  // DELETE LATER
  searchL: Athlete[];

  constructor(private aService: AthleteService, private router: Router) { }

  ngOnInit(): void {
    this.changedView = this.aService.onChangedView;
  }

  /**
   * Is called when the search form is used
   */
  onSearch(): void{
    // We announce the search
    console.log('Search item: ' + this.searchForm.value.searchItem + ',on ' + this.searchForm.value.category + ' category.');

    // We activate the return button
    this.onAthleteViewChanged();

    // We set the search type
    this.aService.searchType = this.searchForm.value.category;

    // Aca llamamos a una funcion que en base a la busqueda rellena las listas de de availableX del servicio athlete ! ! ! !
    this.searchL = [
      new Athlete(
        'Alvaro',
        'Vargas',
        'Costa Rican',
        117730762,
        20,
        '3/4/2000',
        'Costa Rica',
        'Heredia',
        'Belen',
        'avargasm',
        '',
        'abc123'),
      new Athlete(
        'Jon',
        'Doro',
        'Costa Rican',
        117720889,
        20,
        '8/6/2000',
        'Costa Rica',
        'San Jose',
        'Tres Rios',
        'sk8r',
        '',
        '123abc'
      )];

    this.aService.availableAthletes = this.searchL;

    // We go to the search page
    this.router.navigate(['/athlete/search']);
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
