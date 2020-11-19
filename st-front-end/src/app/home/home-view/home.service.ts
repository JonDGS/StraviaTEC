import { ServerService } from './../../server.service';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

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


  constructor(private server : ServerService) { }

  // httpGET(){
  //   return this.http.get(`http://jongs.mynetgear.com:45457/api/athletes`)
  // }

  // httpPost(){
  //   this.http.post(`http://jongs.mynetgear.com:45457/api/athletes`,"").subscribe(
  //     res=>{
  //       console.log(res);
  //     }
  //   );
  // }
/**
 * Register Athlete
 * @param dataForm 
 */
  register(dataForm?){
    this.server.httpRegister(this.data)
  }

  login(){
    this.server.httpLogin()
  }

}