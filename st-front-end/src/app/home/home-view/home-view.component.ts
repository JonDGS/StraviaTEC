import {  Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home-view',
  templateUrl: './home-view.component.html',
  styleUrls: ['./home-view.component.css']
})
export class HomeViewComponent implements OnInit {
  loadedAction = 'login';

  constructor() { }

  ngOnInit() {}

  loadRegister(): void{
    this.loadedAction = 'register';
  }

  loadLogin(): void{
    this.loadedAction = 'login';
  }
}
