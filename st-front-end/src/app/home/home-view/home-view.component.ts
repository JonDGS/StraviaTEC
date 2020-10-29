import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home-view',
  templateUrl: './home-view.component.html',
  styleUrls: ['./home-view.component.css']
})
export class HomeViewComponent implements OnInit {
  loadedAction: string = 'login';

  constructor() { }

  ngOnInit(): void {
  }

  loadRegister(){
    this.loadedAction = 'register';
  }

  loadLogin(){
    this.loadedAction = 'login';
  }
}
