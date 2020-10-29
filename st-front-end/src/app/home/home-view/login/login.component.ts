import { Router, Routes } from '@angular/router';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  @ViewChild('loginForm') loginForm: NgForm;
  constructor(private router: Router) { }

  ngOnInit(): void {
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
  }
}
