import { ServerService } from './../../../server.service';
import { HomeService } from './../home.service';
import { Router } from '@angular/router';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { logWarnings } from 'protractor/built/driverProviders';
import { TimeoutError } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

/**
 * This component is used for managing the login feature of the project
 */
export class LoginComponent implements OnInit {
  @ViewChild('loginForm') loginForm: NgForm;
  constructor(private router: Router, private hService : HomeService) { }

  ngOnInit(): void {}

  /**
   * This method sends us to a specified page
   * @param pageName to go to
   */
  goToPage(pageName: string): void {
    this.router.navigate([`${pageName}`]);
    console.log('Login form');
  }

  /**
   * This method is called when a login is made
   */
  onLogin(): void {
    this.hService.login(this.loginForm.value);
    this.loginForm.reset();
  }
}
