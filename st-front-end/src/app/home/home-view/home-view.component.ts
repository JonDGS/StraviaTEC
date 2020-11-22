import {  Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home-view',
  templateUrl: './home-view.component.html',
  styleUrls: ['./home-view.component.css']
})

/**
 * This class holds the required components of the home view where the user logins and registers
 */
export class HomeViewComponent implements OnInit {
  loadedAction = 'login';

  constructor() { }

  ngOnInit(): void {}

  /**
   * This method loads the register component
   */
  loadRegister(): void{
    this.loadedAction = 'register';
  }

  /**
   * This method loads the login component
   */
  loadLogin(): void{
    this.loadedAction = 'login';
  }
}
