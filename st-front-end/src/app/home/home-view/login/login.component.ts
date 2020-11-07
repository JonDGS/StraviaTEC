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
    console.log(this.loginForm.value.username);
    this.goToPage('athlete');

    this.hService.httpGET().subscribe(res => {
      console.log(res)
    })
  }
}
