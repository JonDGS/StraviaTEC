import { DatePipe } from '@angular/common';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {DomSanitizer} from '@angular/platform-browser';
import { WriteStream } from 'fs';

@Injectable({
  providedIn: 'root'
})


export class ServerService {

  public token;

  constructor(private http:HttpClient,private sanitizer:DomSanitizer) {


   }
   
   /**
    * 
    * login object example
    */
    public loginTest = {
      "username":"Dxnium",
      "passwordHash":"hola1asd234"
  }

    /******************** */
/**
 * Register post 
 */
   httpRegisterAthlete(athlete){
     console.log(athlete);
          this.http.post(`http://jongs.mynetgear.com:27799/api/athletes`,athlete).subscribe(
      res=>{
        console.log(res);
      }
    );
  }

  /**
 * Register post 
 */
httpRegisterOrganizer(organizer){
  console.log(organizer);
       this.http.post(`http://jongs.mynetgear.com:27799/api/Organizers`,organizer).subscribe(
   res=>{
     console.log(res);
   }
 );
}

  /**
   * login with form params 
   * @param params 
   */
  httpLogin(params){
    return this.http.post(`http://jongs.mynetgear.com:27799/api/OnlineUser/LogIn`,params);
  }
setToken(token){
  this.token = token;
}
/**
 * 
 * @param token 
 */
  httplogout(token){
    this.http.delete(`http://jongs.mynetgear.com:27799/api/OnlineUser/LogOut/${token}`).subscribe(res=>console.log(res)
    );
  }

  
  /**
   * load a new image 
   */
  postImage(){
    
  }


  getImagebyToken(){
    return this.http.get(`http://jongs.mynetgear.com:27799/api/athletes/getProfilePicture?token=DCTMDDQKYCSU`,{ responseType: "blob" })
  }


  getFollowees(){
    return this.http.get(`http://jongs.mynetgear.com:27799/api/Follows/GetFollowees/${this.token}`);
  }

  postRace(race){
    this.http.post(`http://jongs.mynetgear.com:27799/api/race/${this.token}`,race).subscribe(res=>console.log(res)
    )
  }

  postChallange(Challange){
    //this.http.post(`http://jongs.mynetgear.com:27799/api/race/${this.token}`,Challange).subscribe(res=>console.log(res))
  }

  postGroup(Group){
    //this.http.post(`http://jongs.mynetgear.com:27799/api/race/${this.token}`,Group).subscribe(res=>console.log(res))
  }

  postActivity(activity){
    this.http.post(`http://jongs.mynetgear.com:27799/api/Activity/${this.token}`,activity).subscribe(res=>console.log(res)
    );
  }

  getRacesByToken(){
    return this.http.get(`http://jongs.mynetgear.com:27799/api/race/${this.token}`)
  }

 async getSearchData(term){
    return await this.http.get(`http://jongs.mynetgear.com:27799/api/athletes/searchTerm?token=${this.token}&term=${term}`).toPromise();
  }

  follow(username){
    let body = {
      "token": this.token,
      "username":username
  }
    this.http.post(`http://jongs.mynetgear.com:27799/api/Follows`,body).subscribe(res => console.log(res)
    );
  }
}
