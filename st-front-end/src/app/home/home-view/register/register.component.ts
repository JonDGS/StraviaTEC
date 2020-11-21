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

    viewType = "athlete"
  constructor(private hService : HomeService) { }
  @ViewChild('userForm') userForm: NgForm;
  ngOnInit(): void {
  }

  onRegister(){

    let date = new Date(this.userForm.value.userBirthday)
    if(this.viewType === "athlete"){
      let object = {
        "name": this.userForm.value.fullName.userFname,
        "passwordhash": this.userForm.value.userPassword,
        "username":this.userForm.value.userName,
        "lastname_1":this.userForm.value.fullName.userLastName,
        "lastname_2":this.userForm.value.fullName.userLastName2,
        "country": this.userForm.value.location.userCountry,
        "state":this.userForm.value.location.userState,
        "city": this.userForm.value.location.userCity,
        "nationality":this.userForm.value.userNationality,
        "birthday": date.getDay(),
        "birthmonth":date.getMonth(),
        "birthyear":date.getFullYear(),
    }
    //console.log(object);
    this.hService.registerAthlete(object);
    alert('Register successfully')  
    this.userForm.reset();
    
      return;
    }else{
      let object = {
        "username": this.userForm.value.userName,
        "photo":null,
        "passwordhash":this.userForm.value.userPassword,
        "city":this.userForm.value.location.userCity,
        "state": this.userForm.value.location.userState,
        "country": this.userForm.value.location.userCountry,
        "name":this.userForm.value.fullName.userFname,
        "lastname_1":this.userForm.value.fullName.userLastName,
        "lastname_2":this.userForm.value.fullName.userLastName2
    }
      //console.log(object);
      this.hService.registerOrganizer(object);  
      alert('Register successfully') 
      this.userForm.reset();
      
    }




  }
/**
 * Change the actual viewType for organizer Form to register
 */
  changeView(view: string){
    this.viewType = view;
  }
}
