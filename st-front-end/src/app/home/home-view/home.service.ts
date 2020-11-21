import { Router } from '@angular/router';
import { ServerService } from './../../server.service';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {DomSanitizer} from '@angular/platform-browser';
import { AthleteService } from 'src/app/athlete/athlete.service';

@Injectable({
  providedIn: 'root'
})
export class HomeService {
  public token;
/***********************************************
 * this data object is only for test porpuses 
 */
  public data = {
  "username":"Dxnium",
  "passwordhash":"hola1234",
  "name":"Daniel",
  "lastname_1":"Umana",
  "lastname_2":"Monge",
  "country":"SJ",
  "state":"SJ",
  "city":"SJ",
  "nationality":"Costa Rican",
  "birthday":10,
  "birthmonth":10,
  "birthyear":10
}
/********************************************** */


  constructor(private server : ServerService,private sanitizer:DomSanitizer,private athlete:AthleteService,private router: Router) {
    
   }
  

/**
 * Register Athlete
 * @param dataForm 
 */
  registerAthlete(dataForm?){
    this.server.httpRegisterAthlete(dataForm)
  }

  /**
 * Register Athlete
 * @param dataForm 
 */
registerOrganizer(dataForm?){
  this.server.httpRegisterOrganizer(dataForm)
}

   /**
   *
   * @param page
   */
  goToPage(pageName:string){
    this.router.navigate([`${pageName}`]);
    console.log("Login form");
  }
/**
 * 
 */
  login(params){
    this.server.httpLogin(params).subscribe(res =>{

      if(res['token'] != "NotRegistered" && res['token'] != "BadPassword"){
        console.log(res);
        
        if(res['id_athlete_fk'] != null){
          this.token = res['token'];
          console.log(res['token']);
          this.athlete.setToken(this.token);
          this.server.setToken(this.token)
          this.goToPage('athlete');
          return;
        }
        this.token = res['token'];
        console.log(res['token']);
        this.athlete.setToken(this.token);
        this.server.setToken(this.token)
        this.goToPage('organizer');
      }

    });
  }


}