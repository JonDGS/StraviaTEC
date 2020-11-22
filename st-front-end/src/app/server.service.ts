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
    Challange['token']= this.token;
    console.log(Challange);
    
    this.http.put(`http://jongs.mynetgear.com:27799/api/Challenges/CreateChallenge`,Challange).subscribe(res=>console.log(res))
  }

  postGroup(Group){
    this.http.post(`http://jongs.mynetgear.com:27799/api/Group/${this.token}`,Group).subscribe(res=>console.log(res))
  }

  postActivity(activity){
    this.http.post(`http://jongs.mynetgear.com:27799/api/Activity/${this.token}`,activity).subscribe(res=>console.log(res)
    );
  }

  async getRacesByToken(){
    return await this.http.get(`http://jongs.mynetgear.com:27799/api/race/${this.token}`).toPromise();
  }

  async getGroupByToken(){
    return await this.http.get(`http://jongs.mynetgear.com:27799/api/Group/${this.token}`).toPromise();
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

  async getInfo(){
    return await this.http.get(`http://jongs.mynetgear.com:27799/api/athletes/${this.token}`).toPromise();
  }

  async getInfoOrganizer(){
    return await this.http.get(`http://jongs.mynetgear.com:27799/api/Organizers/${this.token}`).toPromise();
  }

  async getChallanges(){
    return await this.http.get(`http://jongs.mynetgear.com:27799/api/Challenges/Challenges`).toPromise();
  }

  joinChallange(id_challange){
    let params = {
      "id_challenge":id_challange,
      "status":"Pending",
      "receipt":null
  }
    this.http.post(`http://jongs.mynetgear.com:27799/api/AthleteEnrollment/ChallengeEnrollment/${this.token}`,params).subscribe(res => console.log(res));
  }

  /**
   * Deletes
   */
   deleteRace(idRace){
      this.http.delete(`http://jongs.mynetgear.com:27799/api/race/${idRace}`).subscribe(res => console.log(res))
   }
   deleteGroup(idGroup){
      this.http.delete(`http://jongs.mynetgear.com:27799/api/Group/${idGroup}`).subscribe(res => console.log(res))
   }
}
