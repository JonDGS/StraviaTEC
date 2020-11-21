import { Athlete } from './../../../models/athlete.model';
import { HomeService } from './../home.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @ViewChild('userForm') userForm: NgForm;
  viewType = 'athlete';

  constructor(private hService: HomeService) { }

  ngOnInit(): void {
  }

  /**
   * This method is called whenever the register form is submitted
   */
  onRegister(): void{
    this.hService.register(/**this.userForm.value */);
    alert('User registered');
    this.userForm.reset();
  }

  /**
   * Change the actual viewType for organizer Form to register
   */
  changeView(view: string): void{
    this.viewType = view;
  }
}
