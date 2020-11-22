import { Component, OnInit } from '@angular/core';
// @ts-ignore
import Any = jasmine.Any;
import {AthleteService} from '../../athlete.service';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})

/**
 * This component is for showing the searched items of a user search
 */
export class SearchComponent implements OnInit {
  searchType: string;
  searchData: Any[];

  constructor(private aService: AthleteService) {}

  ngOnInit(): void {
    this.searchType = this.aService.searchType;

    switch (this.searchType) {
      case 'athletes': {
        this.aService.getSearchData().then(res => {
          this.searchData = res;
        });
        break;
      }
      case 'groups': {
        this.searchData = this.aService.availableGroups;
        break;
      }
      case 'races': {
        this.searchData = this.aService.availableRaces;
        break;
      }
      default: {
        console.error('The search type didnt match any available type');
      }
    }
  }
}
