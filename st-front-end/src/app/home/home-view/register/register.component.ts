import { HomeService } from './../home.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private hService : HomeService) { }
  @ViewChild('userForm') userForm: NgForm;
  ngOnInit(): void {
  }

  onRegister(){
    
    this.hService.httpPost()
  }

}
