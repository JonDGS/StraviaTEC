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

  constructor(private aService: AthleteService) { }

  ngOnInit(): void {
    this.searchItemType = this.aService.searchType;
  }
}
