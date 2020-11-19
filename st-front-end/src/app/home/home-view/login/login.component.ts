import { HomeService } from './../home.service';
import { Router } from '@angular/router';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  @ViewChild('loginForm') loginForm: NgForm;
  constructor(private router: Router, private hService : HomeService) { }

  ngOnInit(){
    
  }
  /**
   *
   * @param page
   */
  goToPage(pageName:string){
    this.router.navigate([`${pageName}`]);
    console.log("Login form");
  }

  onLogin(){
    this.goToPage('athlete');
    this.hService.login();
  }
}
