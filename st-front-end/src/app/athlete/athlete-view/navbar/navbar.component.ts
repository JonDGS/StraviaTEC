import {Component, OnInit, ViewChild} from '@angular/core';
import {NgForm} from '@angular/forms';
import {AthleteService} from '../../athlete.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  @ViewChild('searchForm') searchForm: NgForm;
  defaultCategory = 'athlete';
  onSettings: boolean;

  constructor(private aService: AthleteService) { }

  ngOnInit(): void {
    this.onSettings = this.aService.onSettings;
  }

  onSearch(){
    console.log(this.searchForm);
  }

  onAthleteSettingChanged(){
    this.aService.onSettings = !this.aService.onSettings;
  }
}
