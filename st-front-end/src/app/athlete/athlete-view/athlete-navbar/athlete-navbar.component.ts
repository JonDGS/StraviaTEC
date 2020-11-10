import {Component, OnInit, ViewChild} from '@angular/core';
import {NgForm} from '@angular/forms';
import {AthleteService} from '../../athlete.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './athlete-navbar.component.html',
  styleUrls: ['./athlete-navbar.component.css']
})
export class NavbarComponent implements OnInit {
  @ViewChild('searchForm') searchForm: NgForm;
  defaultCategory = 'athlete';
  changedView: boolean;

  constructor(private aService: AthleteService) { }

  ngOnInit(): void {
    this.changedView = this.aService.onChangedView;
  }

  onSearch(): void{
    console.log(this.searchForm);
  }

  onAthleteViewChanged(): void {
    this.aService.onChangedView = true;
  }

  onAthleteViewReturned(): void {
    this.aService.onChangedView = false;
  }
}
